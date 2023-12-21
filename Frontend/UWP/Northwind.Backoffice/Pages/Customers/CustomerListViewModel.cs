using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using Northwind.Backoffice.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.Customers
{
    internal class CustomerListViewModel : ListViewModel<CustomerInfoModel>
    {
        protected override Task OnAppearingAsync() => LoadItemsAsync();

        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new CustomerDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            Items = items;

            IsBusy = false;
        }

        private Task<ObservableCollection<CustomerInfoModel>> AdaptAsync(IEnumerable<CustomerInfo> data)
        {
            var collection = new ObservableCollection<CustomerInfoModel>(data.Select(d => new CustomerInfoModel(d)));
            return Task.FromResult(collection);
        }
    }
}
