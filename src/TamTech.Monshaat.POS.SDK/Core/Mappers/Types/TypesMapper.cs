using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Types;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Types
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


        public static TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models.CreateTypeModel MapToCreateTypeModel(this TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Types.TypeVM item)
        {
            return new TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models.CreateTypeModel
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

        public static TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Types.TypeVM MapToTypeVM(this TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models.TypeDto item)
        {
            return new  TypeVM
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



        public static TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models.UpdateTypeModel MapToUpdateTypeModel(this  TypeVM item)
        {
            return new TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models.UpdateTypeModel
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
