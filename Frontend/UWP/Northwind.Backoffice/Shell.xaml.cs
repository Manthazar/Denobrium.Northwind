using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            //if (args.InvokedItem is SampleCategory category)
            //{
            //    if (SamplePickerGrid.Visibility != Visibility.Collapsed && _selectedCategory == category)
            //    {
            //        // The NavView fires this event twice when the current selected item is clicked
            //        // This makes sure the event get's processed correctly
            //        var nop = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => HideSamplePicker());
            //    }
            //    else
            //    {
            //        _selectedCategory = category;
            //        ShowSamplePicker(category.Samples, true);

            //        // Then Focus on Picker
            //        dispatcherQueue.EnqueueAsync(() => SamplePickerGridView.Focus(FocusState.Keyboard));
            //    }
            //}
        }

        #endregion
    }
}
