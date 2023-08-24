using Integration.Storm.Model.Application;
using Integration.Storm.Model.Product;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Managers;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Storm.Managers
{
    public class StormApplicationManager: IApplicationManager
    {
        private IStormConnectionManager _connectionManager;

        public StormApplicationManager(IStormConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task<List<IManufacturer>> FindAllManufacturers(IUser currentUser)
        {

            // Find the list of products
            string url = "ProductService.svc/rest/ListManufacturers?format=json";

            url += addUserUrlDetails(currentUser);
            
            var manufacturerList = await _connectionManager.GetResult<ItemListResult<StormManufacturer>>(url);

            List<IManufacturer> list = new List<IManufacturer>();

            foreach( var mfr in manufacturerList.Items )
            {
                ManufacturerDto dto = new ManufacturerDto();
                dto.ExternalId = mfr.Id.ToString();
                dto.Code = mfr.UniqueName;
                dto.Name = mfr.Name;
                dto.ImageUrl = mfr.LogoKey;
                list.Add(dto);
            }

            return list;
        }

        public async Task<List<IAttribute>> FindAllParametricsWithValues(IUser currentUser)
        {
            // Find the list of products
            string url = "ProductService.svc/rest/ListParametricInfo?format=json";

            url += addUserUrlDetails(currentUser);
            var parametricsList = await _connectionManager.GetResult<List<StormParametricInfo>>(url);

            url = "ProductService.svc/rest/ListParametricValues2?format=json";
            url += addUserUrlDetails(currentUser);
            var parametricsValueList = await _connectionManager.GetResult<List<StormParametric>>(url);
            Dictionary<int, StormParametric> valueIds = new Dictionary<int, StormParametric>();
            foreach( var value in parametricsValueList )
            {
                valueIds[value.Id] = value;
            }


            List<IAttribute> list = new List<IAttribute>();

            foreach (var parm in parametricsList)
            {

                AttributeDto attributeDto = new AttributeDto();
                attributeDto.ExternalId = parm.Id.ToString();
                attributeDto.Code = parm.Code;
                attributeDto.Uom = parm.Uom;
                attributeDto.Name = parm.Name;

                list.Add(attributeDto);

                // List value type
                if( parm.Type == 1 )
                {
                    attributeDto.Values = new List<AttributeValueDto>();
                    AddParametricChildren(parm.Id, parm.Name, "L" + parm.Id, parm.Type.Value, attributeDto.Values, valueIds, currentUser);
                }  // Multi value type
                else if( parm.Type == 2)
                {
                    attributeDto.Values = new List<AttributeValueDto>();
                    AddParametricChildren(parm.Id, parm.Name, "L" + parm.Id, parm.Type.Value, attributeDto.Values, valueIds, currentUser);
                } // Boolean
                else if( parm.ValueType == 4 )
                {

                    attributeDto.Values = new List<AttributeValueDto>();

                    {
                        AttributeValueDto dto = new AttributeValueDto();
                        dto.Name = parm.Name + " Ja";
                        dto.ExternalId = parm.Id.ToString();
                        dto.Hidden = parm.IsHidden ?? false;
                        
                        dto.QueryCode = "V" + parm.Id + "_1-1";
                        attributeDto.Values.Add(dto);
                    }

                    {
                        AttributeValueDto dto = new AttributeValueDto();
                        dto.Name = parm.Name + " Nej";
                        dto.ExternalId = parm.Id.ToString();
                        dto.Hidden = parm.IsHidden ?? false;

                        dto.QueryCode = "V" + parm.Id + "_0-0";
                        attributeDto.Values.Add(dto);
                    }
                }

            }

            return list;
        }

        private async Task AddParametricChildren(int listId, string name, string prefix, int type, List<AttributeValueDto> list, Dictionary<int, StormParametric> map, IUser currentUser)
        {
            
            // Find the list of ids
            string url = "ProductService.svc/rest/ListParametricValues?format=json";

            url += addUserUrlDetails(currentUser);

            url += $"&id={listId}";
            url += $"&type={type}";

            var parametricsList = await _connectionManager.GetResult<List<StormParametric>>(url);

            foreach (var child in parametricsList)
            {
                AttributeValueDto dto = new AttributeValueDto();
                dto.Name = name + " " + child.Name;
                dto.ExternalId = child.Id.ToString();
                dto.Code = map[Convert.ToInt32(child.Id)].Code;
                dto.Uom = child.Uom;
                dto.Hidden = child.IsHidden ?? false;
                dto.GroupCode = child.GroupName;
                dto.GroupExternalId = child.GroupId!=null? child.GroupId.Value.ToString(): null;
                dto.QueryCode = prefix + listId + "_" + dto.ExternalId;
                list.Add(dto);
            }
        }


        private string addUserUrlDetails(IUser currentUser)
        {
            string url = string.Empty;

            if (!string.IsNullOrEmpty(currentUser.CurrencyCode))
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
