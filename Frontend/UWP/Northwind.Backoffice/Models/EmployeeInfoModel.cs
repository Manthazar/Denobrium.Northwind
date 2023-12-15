using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backofficce.ApiClient.Data;

namespace Northwind.Backoffice.Models
{
    internal class EmployeeInfoModel : ObservableObject
    {
        private readonly EmployeeInfo info;

        public EmployeeInfoModel(EmployeeInfo info)
        {
            Guard.IsNotNull(info, nameof(info));

            this.info = info;
        }

        public string Id
        {
            get => info.Id;
            set => SetProperty(info.Id, value, info, (p, _) => p.Id = value);
        }

        public string LastName
        {
            get => info.LastName;
            set => SetProperty(info.LastName, value, info, (p, _) => p.LastName = value);
        }

        public string FirstName
        {
            get => info.FirstName;
            set => SetProperty(info.FirstName, value, info, (p, _) => p.FirstName = value);
        }

        public byte[] Photo
        {
            get => info.Photo;
        }
    }
}