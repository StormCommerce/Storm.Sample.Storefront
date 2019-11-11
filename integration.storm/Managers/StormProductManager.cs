using Integration.Storm.Model.Product;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Extensions;
using Model.Commerce.Managers;
using Model.Commerce.Product;
using Model.Commerce.Product.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/

namespace Integration.Storm.Managers
{
    public class StormProductManager : IProductManager
    {
        private IProductBuilder<StormProductItem, StormProduct> _productBuilder;
        private IBuyableExtension _buyableExtension;
        private IStormConnectionManager _connectionManager;
        private IConfiguration _configuration;

        private int PageSize = 50;

        public StormProductManager(IStormConnectionManager connectionManager,  IProductBuilder<StormProductItem,StormProduct> productBuilder, IBuyableExtension buyableExtension, IConfiguration configuration)
        {
            _productBuilder = productBuilder;
            _buyableExtension = buyableExtension;
            _connectionManager = connectionManager;
            _configuration = configuration;

            PageSize = Convert.ToInt32(_configuration["Storm:DefaultPageSize"]);
        }

        public IProductList FindByCategory(IUser currentUser, IProductListInputModel query)
        {

            // Find the list of products
            string url = "ProductService.svc/rest/ListProducts2?";

            url += addUserUrlDetails(currentUser);

            url += "&statusSeed=" + _configuration["Storm:StatusSeed"];

            if ( query.CategoryIds != null ) {
                url += "&categorySeed=" + string.Join(",", query.CategoryIds);
            }

            if( query.FlagIds != null )
            {
                url += "&flagSeed=" + string.Join(",", query.FlagIds); 
            }
            if( !string.IsNullOrEmpty(query.Query))
            {
                url += "&searchString=" + System.Web.HttpUtility.UrlEncode(query.Query);
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

        public IList<IProductFilter> FindAllFilters(IUser currentUser, IProductListInputModel query)
        {
            // Find the list of products
            string url = "ProductService.svc/rest/ListProductFilters2?";

            url += addUserUrlDetails(currentUser);

            url += "&statusSeed=" + _configuration["Storm:StatusSeed"];

            if (query.CategoryIds != null)
            {
                url += "&categorySeed=" + string.Join(",", query.CategoryIds);
            }

            if (query.FlagIds != null)
            {
                url += "&flagSeed=" + string.Join(",", query.FlagIds);
            }
            if (!string.IsNullOrEmpty(query.Query))
            {
                url += "&searchString=" + System.Web.HttpUtility.UrlEncode(query.Query);
            }

           
            var filterList = _connectionManager.GetResult<List<StormFilter>>(url);

            List<IProductFilter> result = new List<IProductFilter>();
           
            Dictionary<string, ProductDto> variants = new Dictionary<string, ProductDto>();
            foreach ( var item in filterList )
            {

                var dto = new ProductFilterDto();

                dto.Items = new List<IProductFilterItem>();
                dto.Name = item.Type;
                dto.Type = item.Name;

                if( item.Name.Equals("parf"))
                {
                    foreach (var entry in item.Items)
                    {
                        dto = new ProductFilterDto();
                        dto.Items = new List<IProductFilterItem>();
                        dto.Name = entry.Name;
                        dto.Type = entry.Id;
                        if( entry.Items != null ) { 
                            foreach( var valuef in entry.Items)
                            {
                                var dtoi = new ProductFilterItem();
                                dtoi.Count = valuef.Count ?? 0;
                                dtoi.Id = valuef.Id;
                                dtoi.Name = valuef.Name;
                                dtoi.Type = valuef.Type;
                                dtoi.Value = valuef.Value;
                                dto.Items.Add(dtoi);
                            }
                        } 
                        else if( entry.FalseCount.HasValue )
                        {
                            var dtoi = new ProductFilterItem();
                            dtoi.Count = entry.Count ?? 0;
                            dtoi.Name = "True";
                            dto.Items.Add(dtoi);

                            dtoi = new ProductFilterItem();
                            dtoi.Count = entry.FalseCount ?? 0;
                            dtoi.Name = "False";
                            dto.Items.Add(dtoi);
                        }
                        result.Add(dto);
                    }

                }
                else if (item.Name.Equals("ohf"))
                {
                    result.Add(dto);
                    var dtoi = new ProductFilterItem();
                    dtoi.Count = item.Items[0].Count ?? 0;
                    dtoi.Name = "Onhand";
                    dto.Items.Add(dtoi);
                }
                else { 
                    foreach( var entry in item.Items )
                    {
                        var dtoi = new ProductFilterItem();
                        dtoi.Count = entry.Count??0;
                        dtoi.Id = entry.Id;
                        dtoi.Name = entry.Name;
                        dtoi.Type = entry.Type;
                        dtoi.Value = entry.Value;
                        dto.Items.Add(dtoi);
                    }
                    result.Add(dto);
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
