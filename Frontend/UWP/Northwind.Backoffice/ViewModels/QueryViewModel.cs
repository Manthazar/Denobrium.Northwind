using Northwind.Backoffice.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Northwind.Backoffice.ViewModels
{
    [Obsolete("Replaced by SuggestionsViewModel which is embedded into others because this adds a lot of confusion into code.")]
    internal class QueryViewModel<T> : ListViewModel<T>
    {
        private string keyword;
        private IEnumerable<T> itemsSource;
        private IEnumerable<T> keywordItems;

        public QueryViewModel()
        {
            RunQueryCommand = new Command(async () => await OnRunQueryAsync(), () => RunQuery_CanExecute());
        }

        protected virtual bool RunQuery_CanExecute()
        {
            return true;
        }

        protected virtual Task OnRunQueryAsync()
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// The keyword for which an (in-memory) search should be attempted.
        /// </summary>
        public string Keyword
        {
            get => keyword;
            set => SetProperty(ref keyword, value);
        }

        /// <summary>
        /// The source of the items, that is typically the loaded collection without any in memory filtering.
        /// </summary>
        public IEnumerable<T> ItemsSource
        {
            get => itemsSource;
            protected set => SetProperty(ref itemsSource, value);
        }

        // <summary>
        /// The source of the items, that is typically the loaded collection without any in memory filtering.
        /// </summary>
        public IEnumerable<T> KeywordItems
        {
            get => keywordItems;
            protected set => SetProperty(ref keywordItems, value);
        }


        public ICommand RunQueryCommand { get; }
    }
}
