using Integration.Storm.Model.Product.Category;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Managers;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Managers
{
    public class StormCategoryManager : ICategoryManager
    {

        private IStormConnectionManager _stormConnectionManager;
        private IConfiguration _configuration;

        public StormCategoryManager(IStormConnectionManager stormConnectionManager, IConfiguration configuration)
        {
            _stormConnectionManager = stormConnectionManager;
            _configuration = configuration;
        }

        public async Task<IList<ICategory>> FindAll(IUser currentUser)
        {
            // URL ProductService.svc/rest/ListCategoryItems?format=json
            string url = $"ProductService.svc/rest/ListCategoryItems";

            // This method is supposed to be stored in cache so that it will not retrieve
            // categories from Storm each time.
            var allCategories = await _stormConnectionManager.GetResult<List<StormCategory>>(url);

            IList<ICategory> result = new List<ICategory>();

            foreach( var stormcat in allCategories )
            {
                // This will add all categories recursively since the ToDto()
                // method will run on children.
                result.Add(stormcat.ToDto());
            }

            return filterRootCategory(result);
        }

        private IList<ICategory> filterRootCategory(IList<ICategory> source)
        {
            var rootCategoryId = _configuration["Storm:RootCategoryId"];
            if (string.IsNullOrEmpty(rootCategoryId)) return source;

            foreach( var cat in source )
            {
                if( rootCategoryId.Equals(cat.ExternalId))
                {
                    return cat.Children;
                }
            }

            return source;
        }

    }
}
