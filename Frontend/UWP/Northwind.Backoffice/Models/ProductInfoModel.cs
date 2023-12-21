using CommunityToolkit.Mvvm.ComponentModel;
using Northwind.Backoffice.Data;

namespace Northwind.Backoffice.Models
{
    internal class ProductInfoModel : ObservableObject
    {
        private readonly ProductInfo productInfo;

        public ProductInfoModel(ProductInfo productInfo)
        {
            Guard.IsNotNull(productInfo, nameof(productInfo));

            this.productInfo = productInfo;
        }

        public string Id
        {
            get => productInfo.Id;
            set => SetProperty(productInfo.Id, value, productInfo, (p, _) => p.Id = value);
        }

        public string Name
        {
            get => productInfo.Name;
            set => SetProperty(productInfo.Name, value, productInfo, (p, _) => p.Name = value);
        }

        public string CategoryName
        {
            get => productInfo.CategoryName;
            set => SetProperty(productInfo.CategoryName, value, productInfo, (p, _) => p.CategoryName = value);
        }

        public string SupplierCompanyName
        {
            get => productInfo.SupplierCompanyName;
            set => SetProperty(productInfo.SupplierCompanyName, value, productInfo, (p, _) => p.SupplierCompanyName = value);
        }

        public string QuanityPerUnit
        {
            get => productInfo.QuanityPerUnit;
            set => SetProperty(productInfo.QuanityPerUnit, value, productInfo, (p, _) => p.QuanityPerUnit = value);
        }

        public short? UnitsInStock
        {
            get => productInfo.UnitsInStock;
            set => SetProperty(productInfo.UnitsInStock, value, productInfo, (p, _) => p.UnitsInStock = value);
        }

        public short? UnitsOnOrder
        {
            get => productInfo.UnitsOnOrder;
            set => SetProperty(productInfo.UnitsOnOrder, value, productInfo, (p, _) => p.UnitsOnOrder = value);
        }

        public bool IsDiscontinued
        {
            get => productInfo.IsDiscontinued;
            set => SetProperty(productInfo.IsDiscontinued, value, productInfo, (p, _) => p.IsDiscontinued = value);
        }
    }
}
