using Windows.UI.Xaml.Controls;


namespace Northwind.Backoffice.Pages.Customers
{
    public sealed partial class CustomerList : UserControl
    {
        private readonly CustomerListViewModel viewModel;

        public CustomerList()
        {
            this.InitializeComponent();
            this.Loaded += CustomerList_Loaded;
            this.DataContext = this.viewModel  = new CustomerListViewModel();
        }

        private void CustomerList_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.OnAppearing();
        }
    }
}
