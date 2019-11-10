using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface ICategory
    {
        string ExternalId { get; set; }
        string ParentId { get; set; }
        int Level { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        List<ICategory> Children { get; set; }
    }
}
