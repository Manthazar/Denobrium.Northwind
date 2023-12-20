using CommunityToolkit.Mvvm.Input;
using Northwind.Backoffice.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Northwind.Backoffice.ViewModels
{
    internal class ListViewModel<T> : ViewModel<T>
    {
        private IEnumerable<T> items;
        private T selectedItem;

        public ListViewModel()
        {
            items = new ObservableCollection<T>();

            LoadItemsCommand = new Command(async () => await LoadItems(), () => LoadItems_CanExecute());
            ItemTappedCommand = new RelayCommand<T>(async (i) => await ItemTapped(i), (i) => ItemTapped_CanExecute(i));

            AddItemCommand = Command.UnavailableCommand;
            EditItemCommand = new RelayCommand<T>(async (i) => await Edit(i), (i) => Edit_CanExecute(i));
            RemoveItemCommand = Command.UnavailableCommand;
        }

        #region View Events

        internal override void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;
            SelectedItem = default;

            OnAppearingAsync();
        }

        protected virtual Task OnAppearingAsync() => Task.CompletedTask;

        #endregion

        #region Command Overloads

        private Task Edit(T item)
        {
            return Task.CompletedTask;
        }

        private bool Edit_CanExecute(T item)
        {
            return false;
        }

        protected virtual void OnItemSelected(T item)
        {
        }

        protected virtual bool LoadItems_CanExecute() => true;

        protected virtual Task LoadItems()
        {
            return Task.CompletedTask;
        }

        protected virtual Task ItemTapped(T item)
        {
            return Task.CompletedTask;
        }

        protected virtual bool ItemTapped_CanExecute(T item) => true;

        #endregion

        #region Properties

        protected CancellationTokenSource CancellationTokenSource {get;set;}

        public IEnumerable<T> Items
        {
            get => items;
            protected set => SetProperty(ref items, value);
        }

        public T SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnItemSelected(value);
            }
        }

        public ICommand LoadItemsCommand { get; }

        public ICommand AddItemCommand { get; }

        public ICommand RemoveItemCommand { get; }

        public ICommand EditItemCommand { get; }

        public ICommand ItemTappedCommand { get; }

        #endregion
    }
}
