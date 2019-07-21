using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;                        
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.User;


namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class MapperConfigurations
    {
        public static void InitializeMapper(this IApplicationBuilder app)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
              //  cfg.ContentService_InitializeMapper();

                //cfg.CreateMap<RegisterUserModel, CreateUserVM>();
                //cfg.CreateMap<CreateUserDto, RegisterUserModel>()
                //    .ForMember(model => model.RolesNames,
                //        opt => opt.MapFrom(dto => dto.Roles));

 

                cfg.CreateMap<KeyValuePair<Guid, string>, SelectListItem>()
                    .ForMember(dest => dest.Text,
                        opts => opts.MapFrom(src => src.Value))

                    .ForMember(dest => dest.Value,
                        opts => opts.MapFrom(src => src.Key));

                //cfg.CreateMap<UserModel, SelectListItem>()
                //    .ForMember(dest => dest.Text,
                //        opts => opts.MapFrom(src => src.UserName))

                //    .ForMember(dest => dest.Value,
                //        opts => opts.MapFrom(src => src.Email));


                // for identity self securing automapper , this might not be used at all
                // I just coppied this for now 
                //cfg.CreateMap<TamTechBackendSDK.IdentityService.Models.ApplicationUser,
                //        TamTechBackendSDK.IdentityService.Models.Users.UserModel>()
                //    .ForMember(model => model.MobileNumber, opt => opt.MapFrom(sur => sur.PhoneNumber))
                //    .ForMember(model => model.MobileNumberConfirmed,
                //        opt => opt.MapFrom(sur => sur.PhoneNumberConfirmed));

            });

        }
    }
}
