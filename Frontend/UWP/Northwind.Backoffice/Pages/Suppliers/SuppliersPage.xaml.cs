using Northwind.Backoffice.Models;
using Northwind.Backoffice.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Northwind.Backoffice.Pages.Suppliers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SuppliersPage : Page
    {
        private readonly SupplierListViewModel viewModel;

        public SuppliersPage()
        {
            this.InitializeComponent();

            this.DataContext = this.viewModel = new SupplierListViewModel();
            this.Loaded += SuppliersPage_Loaded;
        }

        private void SuppliersPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.viewModel.OnAppearing();
        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            viewModel.SuggestionsHandler.FindSuggestionsAsync(sender.Text).GetAwaiter().GetResult();
        }

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var suggested = (SuggestionModel)args.ChosenSuggestion;

            // TODO: open the detail of the selected suggestion.
        }
    }
}
