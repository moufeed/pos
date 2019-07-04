using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Web.Models.Shared.Products;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class ProductAttributeValueMapper
    {
        public static ProductAttributeValueVM MapToViewModel(this ProductAttributeValue dto)
        {
            return new ProductAttributeValueVM
            {
                Price = dto.Price,
                Value = dto.Value
            };
        }

        public static ProductAttributeValue MapToDto(this ProductAttributeValueVM model)
        {
            return new ProductAttributeValue
            {
                Price = model.Price,
                Value = model.Value
            };
        }


        public static ProductAttributeValueForm MapToFormDto(this ProductAttributeValueVM model)
        {
            return new ProductAttributeValueForm
            {
                Price = model.Price,
                Value = model.Value
            };
        }
    }
}
