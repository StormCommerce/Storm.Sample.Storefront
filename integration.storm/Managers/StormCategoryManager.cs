using Integration.Storm.Model.Product.Category;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Managers;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Managers
{
    public class StormCategoryManager : ICategoryManager
    {

        private IStormConnectionManager _stormConnectionManager;

        public StormCategoryManager(IStormConnectionManager stormConnectionManager)
        {
            _stormConnectionManager = stormConnectionManager;
        }

        public IList<ICategory> FindAll(IUser currentUser)
        {
            // URL ProductService.svc/rest/ListCategoryItems?format=json
            string url = $"ProductService.svc/rest/ListCategoryItems";

            // This method is supposed to be stored in cache so that it will not retrieve
            // categories from Storm each time.
            var allCategories = _stormConnectionManager.GetResult<List<StormCategory>>(url);

            IList<ICategory> result = new List<ICategory>();

            foreach( var stormcat in allCategories )
            {
                // This will add all categories recursively since the ToDto()
                // method will run on children.
                result.Add(stormcat.ToDto());
            }

            return result;
        }



    }
}
