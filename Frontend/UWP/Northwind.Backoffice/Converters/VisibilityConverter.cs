using System;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Northwind.BackOffice.Converters
{
    /// <summary>
    /// Represents a visibility converter which returns true on non null instances and not empty collections.
    /// </summary>
    internal class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility result;

            if (value is IList list)
            {
                result = list.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            else if (value is string text)
            {
                result = string.IsNullOrWhiteSpace(text) == false ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                result = value != null ? Visibility.Visible : Visibility.Collapsed;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
