using Windows.UI.Xaml.Controls;


namespace Northwind.Backoffice.Pages.Employees
{
    public sealed partial class EmployeesGrid : UserControl
    {
        private readonly EmployeeQueryViewModel viewModel;

        public EmployeesGrid()
        {
            this.InitializeComponent();
            this.Loaded += ProductGrid_Loaded;

            this.DataContext = this.viewModel = new EmployeeQueryViewModel();
        }

        private void ProductGrid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.OnAppearing();
        }
    }
}
