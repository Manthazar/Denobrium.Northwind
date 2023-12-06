namespace Northwind.Backoffice.ViewModels
{
    internal class ItemViewModel<T> : ViewModel<T>
    {
        private T item;

        /// <summary>
        /// Gets the root item of this view model.
        /// </summary>
        public T Item
        {
            get => item;
            set => SetProperty(ref item, value);
        }
    }
}
