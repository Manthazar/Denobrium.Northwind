using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using Northwind.BackOffice.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.ProductList
{
    internal class ProductListViewModel : ListViewModel<ProductInfoModel>
    {
        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();

            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new ProductDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            Items = items;

            IsBusy = false;
        }

        protected override Task OnAppearingAsync() => LoadItemsAsync();

        private Task<ObservableCollection<ProductInfoModel>> AdaptAsync(IEnumerable<ProductInfo> data)
        {
            var collection = new ObservableCollection<ProductInfoModel>(data.Select(d => new ProductInfoModel(d)));
            return Task.FromResult(collection);
        }
    }
}
