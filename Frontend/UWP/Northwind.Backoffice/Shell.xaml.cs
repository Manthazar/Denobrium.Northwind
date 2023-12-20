using Northwind.Backoffice.Pages.CustomerList;
using Northwind.Backoffice.Pages.Employees;
using Northwind.Backoffice.Pages.HomePage;
using Northwind.Backoffice.Pages.Orders;
using Northwind.Backoffice.Pages.ProductList;
using Northwind.Backoffice.Pages.Suppliers;
using Windows.UI.Xaml.Controls;

namespace Northwind.Backoffice
{
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();
            this.Loaded += Shell_Loaded;
        }

        private void Shell_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(HomePage));
        }

        #region Event Handling

        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var navigationName = (string)args.InvokedItem;
            switch (navigationName)
            {
                case "Home":
                    contentFrame.Navigate(typeof(HomePage));
                    break;

                case "Customers":
                    contentFrame.Navigate(typeof(CustomerListPage));
                    break;

                case "Products":
                    contentFrame.Navigate(typeof(ProductsPage));
                    break;

                case "Employees":
                    contentFrame.Navigate(typeof(EmployeesPage));
                    break;

                case "Suppliers":
                    contentFrame.Navigate(typeof(SuppliersPage));
                    break;

                case "Orders":
                    contentFrame.Navigate(typeof(OrdersPage));
                    break;
            }
        }

        #endregion
    }
}
