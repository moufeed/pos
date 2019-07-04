using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.User;

namespace TamTech.Monshaat.POS.Web.Core.Mappers
{
    public static class UsersManagerMapper
    {

        public static Microsoft.AspNetCore.Mvc.Rendering.SelectListItem MapToUserModelByEmail(this UserModel model)
        {
            return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = model.Email,
                Text = model.UserName
            };
        }



        public static RegisterUserModel MapCreateDtoToRegisterModel(this CreateUserDto dto)
        {
            return new RegisterUserModel
            {
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                RolesNames = dto.Roles,
                UserName = dto.UserName,

            };
        }


        public static CreateUserVM MapCreateDtoToCreateVM(this CreateUserDto dto)
        {
            return new CreateUserVM
            {
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                Roles = dto.Roles,
                UserName = dto.UserName,
                ConfirmPasswoord = dto.ConfirmPasswoord,
                Gender = dto.Gender,
                Id = dto.Id,
                ImageUrl = dto.ImageUrl,
                Name = dto.Name,
                PhoneNumberConfirmed = dto.PhoneNumberConfirmed,
                Status = dto.Status,
            };
        }
    }
}
