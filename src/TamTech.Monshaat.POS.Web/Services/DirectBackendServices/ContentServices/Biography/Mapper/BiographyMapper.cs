using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Biography.Mapper
{
    public static class BiographyMapper
    {
        public static TamTech.ContentService.Services.Biographies.Models.UpdateBiographyModel MapToBackUpdateBiographyModel(this TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models.UpdateBiographyModel item)
        {
            return new ContentService.Services.Biographies.Models.UpdateBiographyModel
            {
                GroupId = item.GroupId,
                Lang = item.Lang,
                Biographies = item.Biographies?.Select(el => el.MapToBackBiographyModel()).ToList()
            };
        }



        public static TamTech.ContentService.Services.Biographies.Models.BiographyModel MapToBackBiographyModel(this TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models.BiographyModel item)
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


        public static TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models.BiographyDto MapToFrontBiographyDto(this TamTech.ContentService.Services.Biographies.Models.BiographyDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models.BiographyDto
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
