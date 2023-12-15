using Windows.UI.Xaml.Controls;

namespace Northwind.Backoffice.Pages.Employees
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeesPage : Page
    {
        private readonly EmployeeListViewModel viewModel;

        public EmployeesPage()
        {
            this.InitializeComponent();
            this.Loaded += ProductGrid_Loaded;

            this.DataContext = this.viewModel = new EmployeeListViewModel();
        }

        private void ProductGrid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.OnAppearing();
        }
    }
}
