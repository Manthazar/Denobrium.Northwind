using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Northwind.Core;
using Northwind.Core.Services;
using Northwind.Core.Services.Internal;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : Controller
    {
        private readonly INorthwindConfigurationProvider provider;

        public ConfigurationsController(INorthwindConfigurationProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Validates the configuration of the backend.
        /// </summary>
        /// <remarks>
        /// When it comes to return codes and the real use of this service, the question is whether an invalid configuration should be quitted with an error code or not.
        /// - Doing so may be considered formally invalid  because it is not the service which is failing, but the config and it forces CI tools.
        ///   On the other hand: CI tools will have an easy time to understand whether there is an issue or not.
        /// - Not doing so is formally more correct, but CI tools will have to look into the returned (json) message to understand that there is no issue.
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("validate")]
        public async Task<ValidationResult> ValidateAllAsync(CancellationToken cancellationToken)
        {
            if (provider == null)
            {
                return new ValidationResult() { Errors = new List<ValidationFailure> { new("", "The configuration provider is not available. Cannot validate configuration.") } };
            }

            var validator = new NorthwindConfigurationValidator();
            var validationResult = await validator.ValidateAsync(provider.Configuration, options =>
            {
                options.IncludeAllRuleSets();
            }, cancellationToken);

            return validationResult!;
        }

        /// <summary>
        /// Validates the configuration aspect with the specified name.
        /// </summary>
        /// <remarks>
        /// Particularly useful, if we are interested primarily into integration configuration options (such as middleware bindings/ databases etc). Allows distinction between critical and problematic errors within CI).
        /// <para/>
        /// When it comes to return codes and the real use of this service, the question is whether an invalid configuration should be quitted with an error code or not.
        /// - Doing so may be considered formally invalid  because it is not the service which is failing, but the config and it forces CI tools.
        ///   On the other hand: CI tools will have an easy time to understand whether there is an issue or not.
        /// - Not doing so is formally more correct, but CI tools will have to look into the returned (json) message to understand that there is no issue.
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("validate/rulesets/{rulesetName}")]
        public async Task<IActionResult> ValidateAsync(String rulesetName, CancellationToken cancellationToken)
        {
            WebGuard.IsNotNullOrWhiteSpace(rulesetName, nameof(rulesetName));

            if (provider == null)
            {
                var result = new ValidationResult() { Errors = new List<ValidationFailure> { new("", "The configuration provider is not available. Cannot validate configuration.") } };
                return new ObjectResult(result);
            }

            var validator = new NorthwindConfigurationValidator();
            var validationResult = await validator.ValidateAsync(provider.Configuration, options =>
            {
                options.IncludeRuleSets(rulesetName);
            }, cancellationToken);

            if (validationResult.RuleSetsExecuted.Length == 0)
            {
                var result = new ValidationResult() { Errors = new List<ValidationFailure> { new("", $"The provided rule set name '{rulesetName}' is invalid. Explore the result of validate-all to understand the possible rule set names.") } };
                return new BadRequestObjectResult(result);
            }

            return new ObjectResult(validationResult!);
        }
    }
}
