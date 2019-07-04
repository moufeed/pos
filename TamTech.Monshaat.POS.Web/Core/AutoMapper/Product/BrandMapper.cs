using System.Linq;
using TamTechSDK.Common.Services.ContentService.Brands.Models;
using TamTechSDK.Web.Models.Admin.Product;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class BrandMapper
    {
        public static BrandVM MapToViewModel(this Brand dto)
        {
            return new BrandVM
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Order = dto.Order,
                Categories = dto.Categories.Select(p => p.MapToViewModel()).ToList(),
            };
        }

        public static Brand MapToDto(this BrandVM model)
        {
            return new Brand
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Order = model.Order,
                Categories = model.Categories.Select(p => p.MapToDto()).ToList(),
            };
        }
    }
}
