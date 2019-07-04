using TamTechSDK.Common.Services.ContentService.Categories.Models;
using TamTechSDK.Web.Models.Admin.Product;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class CategoryMapper
    {
        public static Category MapToDto(this CategoryVM model)
        {
            return new Category
            {

                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CategoryType = model.CategoryType
            };
        }

        public static CategoryVM MapToViewModel(this Category dto)
        {
            return new CategoryVM
            {

                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Description = dto.Description,
                CategoryType = dto.CategoryType
            };
        }
    }
}
