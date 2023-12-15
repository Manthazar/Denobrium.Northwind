using CommunityToolkit.Mvvm.Input;
using Northwind.Backoffice.Commands;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Northwind.Backoffice.ViewModels
{
    internal class ListViewModel<T> : ViewModel<T>
    {
        private ObservableCollection<T> items;
        private T selectedItem;

        public ListViewModel()
        {
            items = new ObservableCollection<T>();

            LoadItemsCommand = new Command(async () => await OnLoadItems(), () => LoadItems_CanExecute());
            ItemTappedCommand = new RelayCommand<T>(async (i) => await OnItemTapped(i), (i) => OnItemTapped_CanExecute(i));
        }

        internal override void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;
            SelectedItem = default;

            OnAppearingAsync();
        }

        protected virtual Task OnAppearingAsync() => Task.CompletedTask;

        #region Command Overloads

        protected virtual void OnItemSelected(T item)
        {
        }

        protected virtual bool LoadItems_CanExecute() => true;

        protected virtual Task OnLoadItems()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnItemTapped(T item)
        {
            return Task.CompletedTask;
        }

        protected virtual bool OnItemTapped_CanExecute(T item) => true;

        #endregion

        protected CancellationTokenSource CancellationTokenSource {get;set;}

        public ObservableCollection<T> Items
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

        public ICommand ItemTappedCommand { get; }
    }
}
