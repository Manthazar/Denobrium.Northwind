using CommunityToolkit.Mvvm.Input;
using Northwind.Backoffice.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Northwind.Backoffice.ViewModels
{
    internal class QueryViewModel<T> : ViewModel<T>
    {
        private IEnumerable<T> items;
        private T selectedItem;
        private bool hasItems;

        public QueryViewModel()
        {
            items = null;

            LoadItemsCommand = new Command(async () => await OnLoadItemsAsync(), () => LoadItems_CanExecute());
            ItemTappedCommand = new RelayCommand<T>(async (i) => await OnItemTapped(i), (i) => OnItemTapped_CanExecute(i));
        }

        #region Command Overloads

        public virtual void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default;
        }

        protected virtual void OnItemSelected(T item)
        {
        }

        protected virtual bool LoadItems_CanExecute() => true;

        protected virtual Task OnLoadItemsAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnItemTapped(T item)
        {
            return Task.CompletedTask;
        }

        protected virtual bool OnItemTapped_CanExecute(T item) => true;

        #endregion

        /// <summary>
        /// Gets the items of the viewmodel.
        /// </summary>
        public IEnumerable<T> Items
        {
            get => items;
            protected set
            {
                SetProperty(ref items, value);
                if (items.Count() > 0)
                {
                    HasItems = true;
                }
                else
                {
                    HasItems = false;
                }
            }
        }

        /// <summary>
        /// Determines whether the view model has noteable items (to show).
        /// </summary>
        public bool HasItems
        {
            get => hasItems;
            protected set
            {
                SetProperty(ref hasItems, value);
                OnPropertyChanged(nameof(HasNoItems));
            }
        }

        /// <summary>
        /// Determines whether the view model has no noteable items (to show).
        /// </summary>
        public bool HasNoItems
        {
            get => !hasItems;
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
