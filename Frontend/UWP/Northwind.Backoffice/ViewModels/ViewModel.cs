using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Northwind.Backoffice.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private bool isBusy = false;
        private string title = string.Empty;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backing, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backing, value))
            {
                return false;
            }

            backing = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal virtual void OnAppearing()
        {
        }

        internal virtual void OnDisappearing()
        {
        }

        #endregion
    }

    public class ViewModel<T> : ViewModel
    {
        //protected IDataStore<T> DataStore
        //{
        //    get
        //    {
        //        Guard.TypeIsAssignableFrom<RealmObject>(typeof(T), nameof(T));

        //        return DependencyService.Resolve<IDataStore<T>>();
        //    }
        //}

        //protected DataCatalog Catalog => DataCatalog.Current;
    }
}
