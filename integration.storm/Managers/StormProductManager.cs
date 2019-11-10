using Integration.Storm.Model.Product;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Extensions;
using Model.Commerce.Managers;
using Model.Commerce.Product;
using Model.Commerce.Product.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Managers
{
    public class StormProductManager : IProductManager
    {
        private IProductBuilder<StormProductItem, StormProduct> _productBuilder;
        private IBuyableExtension _buyableExtension;
        private IStormConnectionManager _connectionManager;

        private int PageSize = 50;

        public StormProductManager(IStormConnectionManager connectionManager,  IProductBuilder<StormProductItem,StormProduct> productBuilder, IBuyableExtension buyableExtension)
        {
            _productBuilder = productBuilder;
            _buyableExtension = buyableExtension;
            _connectionManager = connectionManager;
        }

        public IProductList FindByCategory(IUser currentUser, IProductListInputModel query)
        {

            // Find the list of products
            string url = "ProductService.svc/rest/ListProducts2?";

            url += addUserUrlDetails(currentUser);

            if ( query.CategoryIds != null ) {
                url += "&categorySeed=" + string.Join(",", query.CategoryIds);
            }

            if( query.FlagIds != null )
            {
                url += "&flagSeed=" + string.Join(",", query.FlagIds); 
            }

            url += "&pageNo=" + (query.PageNumber > 0 ? query.PageNumber : 1);
            url += "&pageSize=" + (query.PageSize>0?query.PageSize:PageSize);
            url += "&asVariants=1";

            var productList = _connectionManager.GetResult<StormProductList>(url);

            ProductListDto result = new ProductListDto();
            result.ProductCount = productList.ItemCount;
            result.PageSize = PageSize;
            result.PageNumber = (query.PageNumber > 0 ? query.PageNumber : 1); 
            result.Products = new List<IProduct>();

            Dictionary<string, ProductDto> variants = new Dictionary<string, ProductDto>();
            foreach( var item in productList.Items )
            {
                ProductDto p = (ProductDto)_productBuilder.BuildFromItem(item);
                
                if( !string.IsNullOrEmpty(p.GroupByKey))
                {
                    if( variants.ContainsKey(p.GroupByKey))
                    {
                        variants[p.GroupByKey].Variants.Add((VariantDto)p.PrimaryVariant);
                    } else
                    {
                        variants[p.GroupByKey] = p;
                        result.Products.Add(p);
                    }

                }
                else
                {
                    result.Products.Add(p);

                }

            }

            return result;
        }

        public IProduct FindByPartNo(IUser currentUser, string partNo)
        {
            // Find the list of products
            string url = "ProductService.svc/rest/GetProductByPartNo?";

            url += addUserUrlDetails(currentUser);

            url += "&partNo=" + partNo;

            var product = _connectionManager.GetResult<StormProduct>(url);
            
            var p = _productBuilder.BuildFromProduct(product);
                
            return p;
        }

        public IProduct FindByUrl(IUser currentUser, string uniqueName)
        {
            // Find the list of products
            string url = "ProductService.svc/rest/GetProductByUniqueName?";

            url += addUserUrlDetails(currentUser);

            url += "&uniqueName=" + uniqueName;

            var product = _connectionManager.GetResult<StormProduct>(url);

            var p = _productBuilder.BuildFromProduct(product);

            return p;
        }

        public IProductList Query(IUser currentUser, string query)
        {
            throw new NotImplementedException();
        }


        private string addUserUrlDetails(IUser currentUser)
        {
            string url = string.Empty;

            if (!string.IsNullOrEmpty(currentUser.ExternalId))
            {
                url += "&customerId=" + currentUser.ExternalId;
            }
            if (currentUser.Company != null && !string.IsNullOrEmpty(currentUser.Company.ExternalId))
            {
                url += "&companyId=" + currentUser.Company.ExternalId;
            }

            if( !string.IsNullOrEmpty(currentUser.CurrencyCode))
            {
                url += "&currencyId=" + currentUser.CurrencyCode;
            }

            if (!string.IsNullOrEmpty(currentUser.LanguageCode))
            {
                url += "&cultureCode=" + currentUser.LanguageCode;
            }

            return url;

        }
    }
}
