using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backoffice.Data;
using System.Xml.Linq;

namespace Northwind.Backoffice.Models
{
    internal sealed class CustomerInfoModel : ObservableObject
    {
        private string id;
        private string companyName;
        private string contactName;
        private string code;
        private string address;
        private string city;
        private string postalCode;
        private string region;
        private string country;

        public CustomerInfoModel(CustomerInfo source)
        {
            Guard.IsNotNull(source, nameof(source));

            id = source.CustomerId;
            companyName = source.CompanyName;
            contactName = GetName(source);
            code = source.CustomerCode;
            address = source.Address;
            city = source.City;
            postalCode = source.PostalCode;
            region = source.Region;
            country = source.Country;
        }

        private string GetName(CustomerInfo source)
        {
            string name = null;

            if (string.IsNullOrEmpty(source.ContactTitle) == false) { name += source.ContactTitle + " "; }
            if (string.IsNullOrEmpty(source.ContactName) == false) { name += source.ContactName; }

            return name;
        }

        public string CustomerId
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string CustomerCode
        {
            get => code;
            set => SetProperty(ref code, value);
        }

        public string CompanyName
        {
            get => companyName;
            set => SetProperty(ref companyName, value);
        }

        public string ContactName
        {
            get => contactName;
            set => SetProperty(ref contactName, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string Region
        {
            get => region;
            set => SetProperty(ref region, value);
        }

        public string PostalCode
        {
            get => postalCode;
            set => SetProperty(ref postalCode, value);
        }

        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
    }
}
