using CommunityToolkit.Mvvm.Messaging;
using Northwind.Backoffice.Messages;
using Northwind.Backoffice.Pages.Customers;
using Northwind.Backoffice.Pages.Employees;
using Northwind.Backoffice.Pages.Home;
using Northwind.Backoffice.Pages.Orders;
using Northwind.Backoffice.Pages.Products;
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

            WeakReferenceMessenger.Default.Register<NavigationRequestedMessage>(this, (r, m) =>
            {
                OnNavigationRequested((Shell) r, m.NavigationPath);
            });
        }

        private static void OnNavigationRequested(Shell shell, string navigationName) 
        {
            var contentFrame = shell.contentFrame;

            switch (navigationName)
            {
                case "Home":
                    contentFrame.Navigate(typeof(HomePage));
                    break;

                case "Customers":
                    contentFrame.Navigate(typeof(CustomersPage));
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

        #region Event Handling

        private void Shell_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(HomePage));
        }


        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            OnNavigationRequested(this, (string)args.InvokedItem);
        }

        #endregion
    }
}
