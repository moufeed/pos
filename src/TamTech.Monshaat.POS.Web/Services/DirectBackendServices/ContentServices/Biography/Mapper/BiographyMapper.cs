using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Biography.Mapper
{
    public static class BiographyMapper
    {
        public static TamTech.ContentService.Services.Biographies.Models.UpdateBiographyModel MapToBackUpdateBiographyModel(this TamTechSDK.Common.Services.ContentService.Biography.Models.UpdateBiographyModel item)
        {
            return new ContentService.Services.Biographies.Models.UpdateBiographyModel
            {
                GroupId = item.GroupId,
                Lang = item.Lang,
                Biographies = item.Biographies?.Select(el => el.MapToBackBiographyModel()).ToList()
            };
        }



        public static TamTech.ContentService.Services.Biographies.Models.BiographyModel MapToBackBiographyModel(this TamTechSDK.Common.Services.ContentService.Biography.Models.BiographyModel item)
        {
            return new ContentService.Services.Biographies.Models.BiographyModel
            {
                Description = item.Description,
                GenericField = item.GenericField,
                Id = item.Id,
                Key = item.Key,
                Value = item.Value
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Biography.Models.BiographyDto MapToFrontBiographyDto(this TamTech.ContentService.Services.Biographies.Models.BiographyDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Biography.Models.BiographyDto
            {
                Description = item.Description,
                GenericField = item.GenericField,
                Id = item.Id,
                Key = item.Key,
                Value = item.Value,
                GroupId = item.GroupId,
                Lang = item.Lang
            };
        }
    }

}
