using Northwind.Backoffice.Pages.CustomerList;
using Northwind.Backoffice.Pages.HomePage;
using System;
using Windows.UI.Xaml.Controls;

namespace Northwind.Backoffice
{
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();
        }

        #region Event Handling

        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var navigationName = (string)args.InvokedItem;
            if (navigationName == "Customers")
            {
                contentFrame.Navigate(typeof(CustomerListPage));
            } 
            else if (navigationName == "Home")
            {
                contentFrame.Navigate(typeof(HomePage));
            }
        }

        //private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        //{
        //    //if (args.InvokedItem is SampleCategory category)
        //    //{
        //    //    if (SamplePickerGrid.Visibility != Visibility.Collapsed && _selectedCategory == category)
        //    //    {
        //    //        // The NavView fires this event twice when the current selected item is clicked
        //    //        // This makes sure the event get's processed correctly
        //    //        var nop = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => HideSamplePicker());
        //    //    }
        //    //    else
        //    //    {
        //    //        _selectedCategory = category;
        //    //        ShowSamplePicker(category.Samples, true);

        //    //        // Then Focus on Picker
        //    //        dispatcherQueue.EnqueueAsync(() => SamplePickerGridView.Focus(FocusState.Keyboard));
        //    //    }
        //    //}
        //}

        #endregion
    }
}
