using CommunityToolkit.Mvvm.Messaging;
using Northwind.Backoffice.DataStores;
using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using Northwind.BackOffice.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.Pages.CustomerList
{
    internal class CustomerListViewModel : ListViewModel<CustomerInfoModel>
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
