using System;
using System.IO;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Northwind.BackOffice.Converters
{
    internal class ByteArrayImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null)
            {
                return null;
            }
            else if (value is byte[] bytes)
            {
                var stream = new MemoryStream(bytes).AsRandomAccessStream();
                var bitMap = new BitmapImage();
                bitMap.SetSource(stream);

                return bitMap;
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
