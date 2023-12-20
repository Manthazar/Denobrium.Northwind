using Windows.UI.Xaml.Controls;


namespace Northwind.Backoffice.Pages.Suppliers
{
    public sealed partial class SuppliersGrid: UserControl
    {
        private readonly SupplierListViewModel viewModel;

        public SuppliersGrid()
        {
            this.InitializeComponent();
            this.Loaded += SupplierGrid_Loaded;

            this.DataContext = this.viewModel = new SupplierListViewModel();
        }

        private void SupplierGrid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.OnAppearing();
        }
    }
}
