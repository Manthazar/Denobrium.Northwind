using System;
using System.Reflection.Metadata;

namespace Northwind.Backoffice.Models
{
    public class SuggestionModel
    {
        public SuggestionModel(object item, string text)
        {
            Guard.IsNotNullOrWhiteSpace(text, nameof(text));

            Item = item;
            Text = text;
        }

        public SuggestionModel(string noDataText)
        {
            Guard.IsNotNullOrWhiteSpace(noDataText, nameof(noDataText));

            Text = noDataText;
        }

        public object Item { get; }

        /// <summary>
        /// Gets or sets the textual representation of the item when it is suggested
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The auto suggest box is a bit weird: on one hand it allow an item template, but then when a suggestion is accepted, it does ToString() on it...
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Microsoft says, we should show 'no result availble' or similar on mismatches. However, when this suggestion is selected, we do NOT want to see that in our search box...
            return Item != null ? Text : string.Empty;
        }
    }
}
