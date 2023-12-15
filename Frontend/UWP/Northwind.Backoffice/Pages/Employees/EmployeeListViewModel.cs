using Northwind.Backofficce.ApiClient.Data;
using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using Northwind.BackOffice.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.Employees
{
    internal class EmployeeListViewModel : ListViewModel<EmployeeInfoModel>
    {
        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();

            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new EmployeeDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            Items = items;
            SelectedItem = items.FirstOrDefault();

            IsBusy = false;
        }

        protected override Task OnAppearingAsync() => LoadItemsAsync();

        private Task<ObservableCollection<EmployeeInfoModel>> AdaptAsync(IEnumerable<EmployeeInfo> data)
        {
            var collection = new ObservableCollection<EmployeeInfoModel>(data.Select(d => new EmployeeInfoModel(d)));
            return Task.FromResult(collection);
        }
    }
}
