using Microsoft.Toolkit.Uwp.UI.Controls;
using Northwind.BackOffice.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Northwind.Backoffice.Pages.CustomerList
{
    public sealed partial class CustomerList : UserControl
    {
        public CustomerList()
        {
            this.InitializeComponent();
            this.DataContext = new CustomerListViewModel();
        }

        /// <summary>
        /// Manual implementation of sorting, since the UWP version of collection view source does not support sortdirections or filters :-/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersGrid_Sorting(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridColumnEventArgs e)
        {
            var dg = (DataGrid)sender;
            var sortTag = e.Column.Tag.ToString();

            var sortDirection = DataGridSortDirection.Ascending;

            if (e.Column.SortDirection != null && e.Column.SortDirection == DataGridSortDirection.Ascending)
            {
                // If the column is already sorted, flip the sort direction;
                sortDirection = DataGridSortDirection.Descending;
            }

            //Use the Tag property to pass the bound column name for the sorting implementation
            if (sortTag == "CustomerCode")
            {
                Sort((c) => c.CustomerCode, sortDirection, dg, e);
            }
            else if (sortTag == "CompanyName")
            {
                Sort((c) => c.CompanyName, sortDirection, dg, e);
            }

            foreach (var column in dg.Columns)
            {
                if (column.Tag?.ToString() != sortTag)
                {
                    column.SortDirection = null;
                }
            }
        }

        private static void Sort(Func<CustomerInfo, string> keySelector, DataGridSortDirection sortDirection, DataGrid dg, DataGridColumnEventArgs e)
        {
            var items = (IEnumerable<CustomerInfo>)dg.ItemsSource;

            if (sortDirection == DataGridSortDirection.Ascending)
            {
                var sorted = items.OrderBy(keySelector);
                dg.ItemsSource = new ObservableCollection<CustomerInfo>(sorted);
            }
            else
            {
                var sorted = items.OrderByDescending(keySelector);
                dg.ItemsSource = new ObservableCollection<CustomerInfo>(sorted);
            }

            e.Column.SortDirection = sortDirection;
        }
    }
}
