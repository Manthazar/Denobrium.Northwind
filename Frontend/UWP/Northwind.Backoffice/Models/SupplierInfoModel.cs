using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backofficce.ApiClient.Data;

namespace Northwind.Backoffice.Models
{
    internal class SupplierInfoModel : ObservableObject
    {
        private readonly SupplierInfo info;

        public SupplierInfoModel(SupplierInfo info)
        {
            Guard.IsNotNull(info, nameof(info));

            this.info = info;
        }

        public string Id
        {
            get => info.Id;
        }

        public string CompanyName
        {
            get => info.CompanyName;
        }

        public string ContactName
        {
            get => info.ContactName;
        }

        public string ContactTitle
        {
            get => info.ContactTitle;
        }

        public string Country
        {
            get => info.Country;
        }

        public string Phone
        {
            get => info.Phone;
        }

        public string Fax
        {
            get => info.Fax;
        }

        public string HomePage
        {
            get => info.HomePage;
        }
    }
}