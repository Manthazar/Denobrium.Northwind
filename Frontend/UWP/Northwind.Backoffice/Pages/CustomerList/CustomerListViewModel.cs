using CommunityToolkit.Mvvm.Messaging;
using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.ViewModels;
using Northwind.BackOffice.Data;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.CustomerList
{
    internal class CustomerListViewModel : ListViewModel<CustomerInfo>
    {
        public CustomerListViewModel()
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LoadItemsAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private async Task LoadItemsAsync()
        {
            if (CancellationTokenSource != null)
            {
                CancellationTokenSource.Cancel();
            }

            CancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var store = new CustomerDataStore();
            var items = await store.GetAllAsync(CancellationTokenSource.Token);

            Items = new ObservableCollection<CustomerInfo>(items);

            IsBusy = false;
        }
    }
}
