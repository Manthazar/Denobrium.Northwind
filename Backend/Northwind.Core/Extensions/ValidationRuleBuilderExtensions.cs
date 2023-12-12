using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Northwind.Core.Extensions
{
    public static class ValidationRuleBuilderExtensions
    {
        /// <summary>
        /// Validates that the provided string is formally a valid sql connection string and the connection can be established.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        internal static IRuleBuilder<T, string> IsValidSqlConnectionString<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder.SetValidator(new SqlStringValidator<T>()).SetValidator(new SqlConnectionValidator<T>());

            return builder;
        }

        private class SqlStringValidator<T> : PropertyValidator<T, string>
        {
            public override string Name => "Sql connection string format validator";

            protected override string GetDefaultMessageTemplate(string errorCode)
              => "The connection string is not in a valid format.";

            public override bool IsValid(ValidationContext<T> context, string value)
            {
                try
                {
                    new SqlConnectionStringBuilder(value);
                }
                catch (Exception ex)
                {
                    context.AddFailure(context.PropertyPath!, ex.Message);
                }

                // This is a bit tricky here. Since we do not want to expose the used connection string (i.e. secret) to the caller of the validator, we must return true here.
                // note that we already may have added a validation failure.
                return true;
            }
        }

        private class SqlConnectionValidator<T> : PropertyValidator<T, string>
        {
            public override string Name => "Sql connection validator";

            protected override string GetDefaultMessageTemplate(string errorCode)
                => "The connection to the sql server could not be established. See related errors";

            public override bool IsValid(ValidationContext<T> context, string value)
            {
                try
                {
                    using (var connection = new SqlConnection(value))
                    {
                        try
                        {
                            connection.Open();

                            if (connection.State != ConnectionState.Open)
                            {
                                context.AddFailure(context.PropertyPath!, "The connection could not be established (no further details available, good luck).");
                            }
                        }
                        catch (Exception ex)
                        {
                            context.AddFailure(context.PropertyPath!, ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.AddFailure(context.PropertyPath!, ex.Message);
                }

                // This is a bit tricky here. Since we do not want to expose the used connection string (i.e. secret) to the caller of the validator, we must return true here.
                // note that we already may have added a validation failure.
                return true;
            }
        }

    }
}
