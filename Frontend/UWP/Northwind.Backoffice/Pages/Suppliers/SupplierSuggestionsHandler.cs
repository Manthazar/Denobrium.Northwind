using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.Suppliers
{
    internal class SupplierSuggestionsHandler<T> : SuggestionsHandler<SupplierInfoModel>
        where T : class
    {
        internal ListViewModel<SupplierInfoModel> owner;

        public SupplierSuggestionsHandler(ListViewModel<SupplierInfoModel> owner)
        {
            Guard.IsNotNull(owner, nameof(owner));

            this.owner = owner;
        }

        internal override Task FindSuggestionsAsync(string keyword)
        {
            var itemsSource = owner.Items;

            if (itemsSource == null || itemsSource.Any() == false)
            {
                Suggestions = noSuggestionAvailable;
                return Task.CompletedTask;
            }
            else if (keyword == null || keyword.Length <= 2)
            {
                Suggestions = Enumerable.Empty<SuggestionModel>();
                return Task.CompletedTask;
            }
            else 
            {
                var suggestedItems = itemsSource.Where(i => i.CompanyName.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));

                if (suggestedItems.Any())
                {
                    Suggestions = suggestedItems.Select(i => new SuggestionModel(i, i.CompanyName)).OrderBy(s => s.Text).ToList();
                }
                else
                {
                     Suggestions = noSuggestionAvailable;
                }

                return Task.CompletedTask;
            }
        }

        internal void Refresh()
        {
        }
    }
}