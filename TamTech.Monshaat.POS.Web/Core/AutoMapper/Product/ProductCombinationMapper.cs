using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Web.Models.Shared.Products;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class ProductCombinationMapper
    {
        public static ProductCombinationForm MapFormToFormDto(this ProductCombinationFormVM vm)
        {
            return new ProductCombinationForm
            {
                ProductId = vm.ProductId,
                AttributesValues = vm.Attributes,
                Price = vm.Price,
                DiscountPrice = vm.DiscountPrice,
                Quantity = vm.Quantity,
                Sku = vm.Sku,
            };
        }





        public static ProductCombinationVM MapToDto(this ProductCombination dto)
        {
            return new ProductCombinationVM
            {
                AttributesValues = dto.AttributesValues,
                Price = dto.Price,
                DiscountPrice = dto.DiscountPrice,
                Quantity = dto.Quantity,
                Sku = dto.Sku,
                Published = dto.Published
            };
        }
        //public static ProductCombinationForm MapFormToDto(this ProductCombinationVM vm)
        //{
        //    return new ProductCombinationForm
        //    { 
        //        AttributesValues = vm.,
        //        Price = vm.Price,
        //        Quantity = vm.Quantity,
        //        Sku = vm.Sku
        //    };
        //}



        //public static ProductCombinationDto MapToDto(this ProductCombination model)
        //{
        //    return new ProductCombinationDto
        //    {
        //        AttributesValues = model.AttributesValues,
        //        Price = model.Price,
        //        Quantity = model.Quantity,
        //        Sku = model.Sku
        //    };
        //}


        //public static ProductCombination MapFormToModel(this ProductCombinationFormDto dto)
        //{
        //    var combination = new ProductCombination();

        //    return new ProductCombination
        //    {
        //        AttributesValues = dto.AttributesValues.SerializeAttsVals(),
        //        Price = dto.Price,
        //        Quantity = dto.Quantity,
        //        Sku = dto.Sku
        //    };
        //}
    }
}
