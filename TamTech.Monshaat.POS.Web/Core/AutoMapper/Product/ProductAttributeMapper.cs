using System.Linq;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Web.Models.Shared.Products;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class ProductAttributeMapper
    {
        public static ProductAttributeVM MapToViewModel(this ProductAttribute dto)
        {
            return new ProductAttributeVM
            {
                Type = dto.Type,
                Name = dto.Name,
                //Required = dto.Required,
                Values = dto.Values.Select(p => p.MapToViewModel())
            };
        }

        public static ProductAttribute MapToDto(this ProductAttributeVM model)
        {
            return new ProductAttribute
            {
                Type = model.Type,
                Name = model.Name,
                //   Required = model.Required,
                Values = model.Values.Select(p => p.MapToDto())
            };
        }

        public static ProductAttributeForm MapToFormDto(this ProductAttributeVM model)
        {
            return new ProductAttributeForm
            {
                ProductId = model.ProductId,
                Type = model.Type,
                Name = model.Name
            };
        }
    }
}
