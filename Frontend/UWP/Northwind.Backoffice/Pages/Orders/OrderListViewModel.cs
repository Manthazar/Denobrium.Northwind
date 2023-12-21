using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.ViewModels;
using Northwind.Backoffice.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.Orders
{
    internal class OrderListViewModel : ListViewModel<OrderInfo>
    {
        public OrderListViewModel()
        {
        }

        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new OrderDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            Items = items;

            IsBusy = false;
        }

        private Task<ObservableCollection<OrderInfo>> AdaptAsync(IEnumerable<OrderInfo> data)
        {
            var collection = new ObservableCollection<OrderInfo>(data);
            return Task.FromResult(collection);
        }

        protected override Task OnAppearingAsync() => LoadItemsAsync();
    }
}
