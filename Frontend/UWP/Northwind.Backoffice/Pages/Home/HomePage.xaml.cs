using CommunityToolkit.Mvvm.Messaging;
using Northwind.Backoffice.Messages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Northwind.Backoffice.Pages.Home
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Tile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var tile = (FrameworkElement)sender;
            var tag = tile.Tag;

            WeakReferenceMessenger.Default.Send<NavigationRequestedMessage>(new NavigationRequestedMessage()
            {
                NavigationPath = tag.ToString(),
            });
        }
    }
}
