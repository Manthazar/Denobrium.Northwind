using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backoffice.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Northwind.Backoffice.ViewModels
{
    internal abstract class SuggestionsHandler<T> : ObservableObject
        where T : class
    {
        private IEnumerable<SuggestionModel> suggestions;

        protected readonly IReadOnlyCollection<SuggestionModel> noSuggestionAvailable;


        public SuggestionsHandler()
        {
            noSuggestionAvailable = new ReadOnlyCollection<SuggestionModel>(new List<SuggestionModel> {
                        new SuggestionModel("No suggestions available")
                    });
        }

        /// <summary>
        /// Finds suggestions based on the provided keyword and populates 
        /// </summary>
        /// <returns></returns>
        internal abstract Task FindSuggestionsAsync(string keyword);

        /// <summary>
        /// The source of the items, that is typically the loaded collection without any in memory filtering.
        /// </summary>
        public IEnumerable<SuggestionModel> Suggestions
        {
            get => suggestions;
            protected set => SetProperty(ref suggestions, value);
        }
    }
}
