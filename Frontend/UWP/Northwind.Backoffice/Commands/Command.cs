using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Northwind.Backoffice.Commands
{
    internal class Command : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> canExecute;

        public Command(Action action, Func<bool> canExecute) : base ()
        {
            Guard.IsNotNull(action, nameof(action));

            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute();
            }
            else
            {
                return true;
            }
        }

        [DebuggerStepThrough]
        public void Execute(object parameter)
        {
            action();
        }

        /// <inheritdoc/>
        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Static

        public static ICommand UnavailableCommand { get; } = new Command(() => { }, () => false);

        #endregion

    }
}
