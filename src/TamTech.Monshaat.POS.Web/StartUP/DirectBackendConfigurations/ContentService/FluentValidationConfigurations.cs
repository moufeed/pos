using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using TamTech.ContentService.Dtos.Product;
using TamTech.ContentService.Validators;
using TamTech.ContentService.Services.Menus.Dtos;
using TamTech.ContentService.Services.Dtos;
using TamTech.ContentService.Services.Galleries.Dtos;
using TamTech.ContentService.Services.Services.Validators;
using TamTech.ContentService.Services.Menus.Validators;
using TamTech.ContentService.Services.Galleries.Validators;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{
    public static class FluentValidationConfigurations
    {
        public static void DirectBackendServices_ContentService_AddFluentValidationConfigurations(this IServiceCollection services)
        {

            #region Product Module

            services.AddTransient<IValidator<CreateProductDto>, CreateProductDtoValidator>();

            services.AddTransient<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();

            services.AddTransient<IValidator<ProductDto>, ProductDtoValidator>();

            #endregion



            //#region Page Module

            //services.AddTransient<IValidator<CreateHtmlPageModel>, CreateHtmlPageModelValidator>();

            //services.AddTransient<IValidator<CreateSectionsPageModel>, CreateSectionsPageModelValidator>();

            //services.AddTransient<IValidator<UpdateHtmlPageModel>, UpdateHtmlPageModelValidator>();

            //services.AddTransient<IValidator<UpdateSectionsPageModel>, UpdateSectionsPageModelValidator>();

            //#endregion


            #region Menu Module

            services.AddTransient<IValidator<CreateMenuItemModel>, CreateMenuItemModelValidator>();

            services.AddTransient<IValidator<UpdateMenuItemModel>, UpdateMenuItemModelValidator>();

            services.AddTransient<IValidator<MenuItemKeysModel>, MenuItemKeysModelValidator>();

            services.AddTransient<IValidator<CreateMenuModel>, CreateMenuModelValidator>();

            #endregion


            #region Service Module

            services.AddTransient<IValidator<CreateServiceModel>, CreateServiceModelValidator>();

            services.AddTransient<IValidator<UpdateServiceModel>, UpdateServiceModelValidator>();

            #endregion


            #region Gallery Module

            services.AddTransient<IValidator<CreateGalleryModel>, CreateGalleryModelValidator>();

            services.AddTransient<IValidator<UpdateGalleryModel>, UpdateGalleryModelValidator>();

            #endregion



        }

    }
}
