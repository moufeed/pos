using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Extensions.AutoMapper.Types
{
    public static class TypesMapper
    {

        public static Dictionary<string, object> MapToDictionary(this Dictionary<string, bool> Dictionary)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (Dictionary.Count > 0)
            {
                foreach (var item in Dictionary)
                {
                    result.Add(item.Key, item.Value);
                }
                return result;
            }
            else
            {
                return result;
            }
        }


        public static Dictionary<string, bool> MapToDictionary(this Dictionary<string, object> Dictionary)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            if (Dictionary.Count > 0)
            {
                foreach (var item in Dictionary)
                {
                    result.Add(item.Key, (bool)item.Value);
                }
                return result;
            }
            else
            {
                return result;
            }
        }


        public static TamTechSDK.Common.Services.TypesService.Models.CreateTypeModel MapToCreateTypeModel(this TamTechSDK.Web.Models.Admin.Types.TypeVM item)
        {
            return new TamTechSDK.Common.Services.TypesService.Models.CreateTypeModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                ParentId = item.ParentId,
                Options = item.Options?.MapToDictionary(),
                IsOfficial = item.IsOfficial

            };
        }

        public static TamTechSDK.Web.Models.Admin.Types.TypeVM MapToTypeVM(this TamTechSDK.Common.Services.TypesService.Models.TypeDto item)
        {
            return new Models.Admin.Types.TypeVM
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Options = item.Options?.MapToDictionary(),
                IsOfficial = item.IsOfficial,
                Id = item.Id

            };
        }



        public static TamTechSDK.Common.Services.TypesService.Models.UpdateTypeModel MapToUpdateTypeModel(this Models.Admin.Types.TypeVM item)
        {
            return new TamTechSDK.Common.Services.TypesService.Models.UpdateTypeModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Options = item.Options?.MapToDictionary(),
                Id = item.Id
            };
        }
    }
}
