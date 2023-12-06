using Microsoft.Toolkit.Uwp.UI.Controls;
using Northwind.BackOffice.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Northwind.Backoffice.Pages.CustomerList
{
    public sealed partial class CustomerList : UserControl
    {
        public CustomerList()
        {
            this.InitializeComponent();
            this.DataContext = new CustomerListViewModel();
        }
    }
}
