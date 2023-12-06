using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Northwind.Backoffice.Pages.CustomerList
{
    public sealed partial class CustomerList : UserControl
    {
        public CustomerList()
        {
            this.InitializeComponent();
            this.ViewModel = new CustomerListViewModel();
            this.DataContext = ViewModel;
        }

        internal CustomerListViewModel ViewModel
        {
            get { return (CustomerListViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        private static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(CustomerListViewModel), typeof(CustomerList), new PropertyMetadata(0));


    }
}
