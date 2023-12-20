using Windows.UI.Xaml.Controls;

namespace Northwind.Backoffice.Pages.Suppliers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SuppliersPage : Page
    {
        //private readonly SupplierListViewModel viewModel;

        public SuppliersPage()
        {
            this.InitializeComponent();

            //this.DataContext = this.viewModel = new SupplierListViewModel();
        }
    }
}
