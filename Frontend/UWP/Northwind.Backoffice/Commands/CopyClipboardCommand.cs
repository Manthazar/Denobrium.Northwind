using System;
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;

namespace Northwind.Backoffice.Commands
{
    internal class CopyClipboardCommand : ICommand
    {
        private static Lazy<CopyClipboardCommand> lazy = new Lazy<CopyClipboardCommand>();
        public static ICommand Singleton => lazy.Value;


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return parameter is string;
        }

        public void Execute(object parameter)
        {
            if (parameter is string text)
            {
                var dataPackage = new DataPackage();
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
                dataPackage.SetText(text);

                Clipboard.SetContent(dataPackage);
            }
        }
    }
}
