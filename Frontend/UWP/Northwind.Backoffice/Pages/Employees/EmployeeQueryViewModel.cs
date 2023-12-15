using Northwind.Backofficce.ApiClient.Data;
using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.Employees
{
    internal class EmployeeListViewModel : QueryViewModel<EmployeeInfoModel>
    {
        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new EmployeeDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            ItemsSource = Items = items;

            IsBusy = false;
        }

        protected override Task OnRunQueryAsync()
        {
            if (Keyword != null && Keyword.Length > 2 && ItemsSource.Any())
            {
                // When the keyword is sufficient long, we want the items of the grid/ hex showing the same set as the search popup.
                Items = KeywordItems = ItemsSource.Where(i => i.FullName.Contains(Keyword, System.StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                // When the keyword is too short, we want to see all items in the grid/ hex, but nothing in the search popup.
                Items = ItemsSource;
                KeywordItems = null;
            }

            return Task.CompletedTask;
        }

        protected override Task OnAppearingAsync() => LoadItemsAsync();

        private Task<ObservableCollection<EmployeeInfoModel>> AdaptAsync(IEnumerable<EmployeeInfo> data)
        {
            var collection = new ObservableCollection<EmployeeInfoModel>(data.Select(d => new EmployeeInfoModel(d)));
            return Task.FromResult(collection);
        }
    }
}
