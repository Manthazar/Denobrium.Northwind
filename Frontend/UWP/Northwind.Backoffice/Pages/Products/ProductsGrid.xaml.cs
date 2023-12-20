using Windows.UI.Xaml.Controls;


namespace Northwind.Backoffice.Pages.Products
{
    public sealed partial class ProductGrid : UserControl
    {
        private readonly ProductListViewModel viewModel;

        public ProductGrid()
        {
            this.InitializeComponent();
            this.Loaded += ProductGrid_Loaded;

            this.DataContext = this.viewModel = new ProductListViewModel();
        }

        private void ProductGrid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.OnAppearing();
        }
    }
}
