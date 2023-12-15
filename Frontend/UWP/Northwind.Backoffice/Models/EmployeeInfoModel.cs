using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backofficce.ApiClient.Data;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.AI.MachineLearning.Preview;
using Windows.UI.Xaml.Media.Imaging;

namespace Northwind.Backoffice.Models
{
    internal class EmployeeInfoModel : ObservableObject
    {
        private readonly EmployeeInfo info;
        private BitmapImage photoSource;

        public EmployeeInfoModel(EmployeeInfo info)
        {
            Guard.IsNotNull(info, nameof(info));

            this.info = info;
        }

        public string Id
        {
            get => info.Id;
        }

        public string LastName
        {
            get => info.LastName;
        }

        public string FirstName
        {
            get => info.FirstName;
        }

        public string FullName
        {
            get => $"{info.LastName.ToUpper()}, {info.FirstName}";
        }

        public byte[] Photo
        {
            get => info.Photo;
        }

        public BitmapImage PhotoSource
        {
            get
            {
                if (photoSource == null)
                {
                    photoSource = CreatePhotoSource();
                }

                return photoSource;
            }
        }

        private BitmapImage CreatePhotoSource()
        {
            if (Photo != null && Photo.Length > 0)
            {
                var stream = Photo.AsBuffer().AsStream().AsRandomAccessStream();

                var bitMap = new BitmapImage();
                stream.Seek(0);
                bitMap.SetSourceAsync(stream);

                return bitMap;
            }
            else
            {
                return null;
            }
            
        }
    }
}