using Windows.UI.Xaml.Controls;


namespace Northwind.Backoffice.Pages.Orders
{
    public sealed partial class OrdersPage : Page
    {
        private readonly OrderListViewModel viewModel;

        public OrdersPage()
        {
            this.InitializeComponent();

            this.DataContext = this.viewModel = new OrderListViewModel();
            this.Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.viewModel.OnAppearing();
        }
    }
}
