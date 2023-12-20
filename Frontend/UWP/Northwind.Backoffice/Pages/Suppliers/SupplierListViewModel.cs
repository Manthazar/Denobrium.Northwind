using Northwind.Backofficce.ApiClient.Data;
using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.Suppliers
{
    internal class SupplierListViewModel : ListViewModel<SupplierInfoModel>
    {
        public SupplierListViewModel()
        {
            SuggestionsHandler = new SupplierSuggestionsHandler<SupplierInfoModel>(this);
        }

        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new SupplierDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            Items = items;

            Items.ToDictionary((k) => k.Id);
            SuggestionsHandler.Refresh();

            IsBusy = false;
        }

        private Task<ObservableCollection<SupplierInfoModel>> AdaptAsync(IEnumerable<SupplierInfo> data)
        {
            var collection = new ObservableCollection<SupplierInfoModel>(data.Select(d => new SupplierInfoModel(d)));
            return Task.FromResult(collection);
        }

        public SupplierSuggestionsHandler<SupplierInfoModel> SuggestionsHandler { get; }

        protected override Task OnAppearingAsync() => LoadItemsAsync();
    }
}
