using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.ViewModels;
using Northwind.BackOffice.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.CustomerList
{
    internal class CustomerListViewModel : ListViewModel<CustomerInfo>
    {
        public CustomerListViewModel()
        {
            Task.Run(() => LoadItemsAsync());
        }

        private async Task LoadItemsAsync()
        {
            IsBusy = true;
            
            var store = new CustomerDataStore();
            var items = await store.GetAllAsync();

            Items = new ObservableCollection<CustomerInfo>(items);

            IsBusy = false;
        }
    }
}
