using Northwind.Backoffice.Pages.CustomerList;
using Northwind.Backoffice.Pages.HomePage;
using Windows.UI.Xaml.Controls;

namespace Northwind.Backoffice
{
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();
        }

        #region Event Handling

        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var navigationName = (string)args.InvokedItem;
            if (navigationName == "Customers")
            {
                contentFrame.Navigate(typeof(CustomerListPage));
            } 
            else if (navigationName == "Home")
            {
                contentFrame.Navigate(typeof(HomePage));
            }
        }

        #endregion
    }
}
