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
    }
}
