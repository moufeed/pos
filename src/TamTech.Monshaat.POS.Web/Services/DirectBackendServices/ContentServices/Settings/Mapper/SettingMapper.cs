using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Settings.Mapper
{
    public static class SettingMapper
    {


        public static TamTech.Monshaat.POS.Web.Services.ContentService.Settings.Models.SettingDto MapToFrontDto(this TamTech.ContentService.Services.Settings.Models.SettingDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.ContentService.Settings.Models.SettingDto
            {
                Description = item.Description,
                GenericField = item.GenericField,
                Id = item.Id,
                Key = item.Key,
                Value = item.Value,
                GroupId = item.GroupId,
                SharedKey = item.SharedKey,
                Enabled = item.Enabled,
            };
        }
    }

}
