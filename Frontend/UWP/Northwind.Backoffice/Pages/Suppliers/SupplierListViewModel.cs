using CommunityToolkit.Mvvm.Input;
using Northwind.Backofficce.ApiClient.Data;
using Northwind.Backoffice.Commands;
using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Northwind.Backoffice.Pages.Suppliers
{
    internal class SupplierListViewModel : ListViewModel<SupplierInfoModel>
    {
        public SupplierListViewModel()
        {
            SuggestionsHandler = new SupplierSuggestionsHandler<SupplierInfoModel>(this);
            OpenWebpageCommand = new AsyncRelayCommand<string>(OpenWebpage_Execute, OpenWebpageCommand_CanExecute);
        }

        private async Task OpenWebpage_Execute(string uriString)
        {
            // Create a Uri object from a URI string 
            var uri = new Uri(uriString);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private bool OpenWebpageCommand_CanExecute(string uriString) => Uri.IsWellFormedUriString(uriString, UriKind.Absolute);

        private async Task LoadItemsAsync()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new SupplierDataStore();
            var data = await store.GetAllAsync(CancellationTokenSource.Token);
            var items = await AdaptAsync(data);

            Items = items;

            SuggestionsHandler.Refresh();

            IsBusy = false;
        }

        private Task<ObservableCollection<SupplierInfoModel>> AdaptAsync(IEnumerable<SupplierInfo> data)
        {
            var collection = new ObservableCollection<SupplierInfoModel>(data.Select(d => 
                                    new SupplierInfoModel(d, OpenWebpageCommand, CopyClipboardCommand.Singleton)));

            return Task.FromResult(collection);
        }

        protected override Task OnAppearingAsync() => LoadItemsAsync();

        public SupplierSuggestionsHandler<SupplierInfoModel> SuggestionsHandler { get; }

        public ICommand OpenWebpageCommand { get; }
    }
}
