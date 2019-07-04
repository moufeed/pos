using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Menus.Models;
using TamTechSDK.Web.Models.Admin.Menus;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class MenuMapper
    {
        public static UpdateMenuDto MapEditVMToDto(this EditMenuVM vm)
        {
            return new UpdateMenuDto
            {
                Title = vm.Title,
                Position = vm.Position,
                Id = vm.Id,
                Lang = vm.Lang,
                Key = vm.Key
            };
        }



        public static EditMenuVM MapDtoToEditVM(this MenuDto dto)
        {
            return new EditMenuVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Key = dto.Key,
                Position = dto.Position,
                Locked = dto.Locked,
                CreatedDate = dto.CreatedDate,
                ModifiedDate = dto.ModifiedDate,
                MenuItems = dto.MenuItems,
                Lang = dto.Lang
            };
        }






        public static MenuLiteDto MapLiteDtoToCreateDto(this CreateMenuDto dto)
        {
            return new MenuLiteDto
            {
                Title = dto.Title,
                Key = dto.Key,
                Position = dto.Position,
            };
        }


    }
}
