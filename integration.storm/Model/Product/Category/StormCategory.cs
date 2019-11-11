using Model.Commerce.Dto.Product;
using Model.Commerce.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Model.Product.Category
{
  
    public class StormCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Level { get; set; }
        public bool IsDisplayOnly { get; set; }
        public string Key { get; set; }
        public List<StormCategory> Children { get; set; }
        public string Code { get; set; }
        public string Synonyms { get; set; }

        public CategoryDto ToDto()
        {
            CategoryDto dto = new CategoryDto();
            dto.Code = this.Code;
            dto.Name = this.Name;
            dto.ExternalId = this.CategoryId.ToString();
            dto.ParentId = this.ParentId?.ToString();
            dto.Level = this.Level;
            
            if( this.Children != null )
            {
                dto.Children = new List<ICategory>();
                foreach( var child in this.Children )
                {
                    dto.Children.Add(child.ToDto());
                }
            }
            return dto;
        }


    }

}
