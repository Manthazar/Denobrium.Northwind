using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backoffice.Data;
using System.Windows.Input;

namespace Northwind.Backoffice.Models
{
    internal class SupplierInfoModel : ObservableObject
    {
        private readonly SupplierInfo info;

        public SupplierInfoModel(SupplierInfo info, ICommand openCommand, ICommand copyCommand)
        {
            Guard.IsNotNull(info, nameof(info));

            this.info = info;
            this.OpenWebpageCommand = openCommand;
            this.CopyToClipboardCommand = copyCommand;

            SplitHomePageSegments(info.HomePage);
        }

        /// <summary>
        /// Splits the encoded home page string into segments of name and address.
        /// </summary>
        /// <example>
        /// mysite#https://go.acme.com#
        /// #https://go.acme.com#
        /// </example>
        /// <param name="homePage"></param>
        private void SplitHomePageSegments(string homePage)
        {
            if (string.IsNullOrWhiteSpace(homePage) == false)
            {
                var segments = homePage.Split('#');

                if (segments.Length == 3)
                {
                    HomePageName = string.IsNullOrWhiteSpace(segments[0]) ? "Link" : segments[0]; // a name is not provided in all cases.
                    HomePageUri = segments[1];
                }
                else
                {
                    // if the number of segments is not 3, it means that the format of the link has changed or is invalid.
                    // Since this is a presentation feature, we are not failing here, but we should notify/ log.
                }
            }
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

        public string HomePageName { get; private set; }

        public string HomePageUri { get; private set; }

        public ICommand OpenWebpageCommand { get; }
        
        public ICommand CopyToClipboardCommand { get; }
    }
}