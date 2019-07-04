using System.Collections.Generic;
using System.Linq;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Web.Models.Admin.Product;
using TamTechSDK.Web.Models.Shared.Products;
using TamTechSDK.Web.Models.Shop.Products;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class ProductMapper
    {

        public static ProductForm MapFormToDto(this ProductFormVM vm)
        {
            return new ProductForm
            {
                Id = vm.Id,
                Name = vm.Name,
                Attributes = vm.Attributes.Select(p => p.MapToDto()).ToList(),
                BrandId = vm.Brand,
                CategoriesIds = vm.Categories,
                Description = vm.Description,
                ShortDescription = vm.ShortDescription,
                FullDescription = vm.FullDescription,
                StockQuantity = vm.StockQuantity,
                DiscountPrice = vm.DiscountPrice,
                Price = vm.Price,
                MainImageUrl = vm.MainImageUrl,
                SKU = vm.SKU,
                Rate = vm.Rate,
                MaximumCartQuantity = vm.MaximumCartQuantity,
                IsShipEnabled = vm.IsShipEnabled,
                IsFreeShipping = vm.IsFreeShipping,
                Specifications = vm.Specifications,
                Weight = vm.Weight,
                Length = vm.Length,
                Width = vm.Width,
                Height = vm.Height,
                Images = vm.Images,
                Published = vm.Published,
                //  Combinations = vm.Combinations.Select(c => c.MapFormToFormDto()).ToList(),

            };
        }



        public static ProductFormVM MapFormToFormViewModel(this ProductForm dto)
        {
            return new ProductFormVM
            {
                Id = dto.Id,
                Name = dto.Name,
                Attributes = dto.Attributes.Select(p => p.MapToViewModel()).ToList(),
                Brand = dto.BrandId,
                Categories = dto.CategoriesIds,
                Description = dto.Description,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,
                StockQuantity = dto.StockQuantity,
                DiscountPrice = dto.DiscountPrice,
                Price = dto.Price,
                MainImageUrl = dto.MainImageUrl,
                SKU = dto.SKU,
                Rate = dto.Rate,
                MaximumCartQuantity = dto.MaximumCartQuantity,
                IsShipEnabled = dto.IsShipEnabled,
                IsFreeShipping = dto.IsFreeShipping,
                Specifications = dto.Specifications,
                Weight = dto.Weight,
                Length = dto.Length,
                Width = dto.Width,
                Height = dto.Height,
                Images = dto.Images,
                Published = dto.Published,
                Combinations = dto.Combinations != null ? dto.Combinations.Select(c => c.MapToDto()).ToList() : new List<ProductCombinationVM>(),
            };
        }
        public static ProductListVM MapToListViewModel(this Product dto)
        {
            return new ProductListVM
            {
                Id = dto.Id,
                Name = dto.Name,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,
                StockQuantity = dto.StockQuantity,
                Price = dto.Price,
                MainImageUrl = dto.MainImageUrl,
                SKU = dto.SKU,
                Published = dto.Published,
                DiscountPrice = dto.DiscountPrice
            };
        }


        public static ProductLiteVM MapToLiteViewModel(this Product dto)
        {
            return new ProductLiteVM
            {
                Id = dto.Id,
                Name = dto.Name,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,
                StockQuantity = dto.StockQuantity,
                Price = dto.Price,
                MainImageUrl = dto.MainImageUrl,
                SKU = dto.SKU,
                Published = dto.Published
            };
        }


        public static PublicProductVM MapToPublicViewModel(this Product dto)
        {
            return new PublicProductVM
            {
                Id = dto.Id,
                Name = dto.Name,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,
                StockQuantity = dto.StockQuantity,
                Price = dto.Price,
                MainImageUrl = dto.MainImageUrl,
                SKU = dto.SKU,
                Published = dto.Published,
                DiscountPrice = dto.DiscountPrice
            };
        }

        public static ProductFormVM MapToFormViewModel(this Product dto)
        {
            return new ProductFormVM
            {
                Id = dto.Id,
                Name = dto.Name,
                Attributes = dto.Attributes.Select(p => p.MapToViewModel()).ToList(),
                Brand = dto.Brand.Id,
                Categories = dto.Categories.Select(c => c.Id).ToList(),
                Description = dto.Description,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,
                StockQuantity = dto.StockQuantity,
                DiscountPrice = dto.DiscountPrice,
                Price = dto.Price,
                MainImageUrl = dto.MainImageUrl,
                SKU = dto.SKU,
                Rate = dto.Rate,
                MaximumCartQuantity = dto.MaximumCartQuantity,
                IsShipEnabled = dto.IsShipEnabled,
                IsFreeShipping = dto.IsFreeShipping,
                Specifications = dto.Specifications,
                Weight = dto.Weight,
                Length = dto.Length,
                Width = dto.Width,
                Height = dto.Height,
                Images = dto.Images,
                Published = dto.Published,
            };
        }
        //public static Product MapToDto(this ProductFormVM vm)
        //{
        //    return new Product
        //    {
        //        Id = vm.Id,
        //        Name = vm.Name,
        //        Attributes = vm.Attributes.Select(p => p.MapToDto()).ToList(),
        //        Brand = vm.Brand.MapToDto(),
        //        Categories = vm.Categories.Select(p => p.MapToDto()).ToList(),
        //        Description = vm.Description,
        //        ShortDescription = vm.ShortDescription,
        //        FullDescription = vm.FullDescription,
        //        StockQuantity = vm.StockQuantity,
        //        DiscountPrice = vm.DiscountPrice,
        //        Price = vm.Price,
        //        ThumbnailUrl = vm.ThumbnailUrl,
        //        SKU = vm.SKU,
        //        Rate = vm.Rate,
        //        MaximumCartQuantity = vm.MaximumCartQuantity,
        //        IsShipEnabled = vm.IsShipEnabled,
        //        IsFreeShipping = vm.IsFreeShipping,
        //        Specifications = vm.Specifications,
        //        Weight = vm.Weight,
        //        Length = vm.Length,
        //        Width = vm.Width,
        //        Height = vm.Height,
        //        Images = vm.Images,
        //    };
        //}


        //public static Product MapToDto(this ProductVM vm)
        //{
        //    return new Product
        //    {
        //        Id = vm.Id,
        //       // Attributes = vm.Attributes,
        //        Brand = vm.Brand,
        //        Categories = vm.Categories, 
        //        FullDescription = vm.FullDescription,
        //        Height = vm.Height,
        //      //  Images = vm.Images,
        //        IsFreeShipping = vm.IsFreeShipping,
        //        IsShipEnabled = vm.IsShipEnabled,
        //        Length= vm.Length,
        //        MaximumCartQuantity= vm.MaximumCartQuantity,
        //        Name= vm.Name,
        //       // DiscountedPrice = vm.DiscountedPrice,
        //        Pictures= vm.Pictures,
        //        Price = vm.Price,
        //        Published= vm.Published,
        //        SKU= vm.SKU,
        //        Specifications= vm.Specifications,
        //        StockQuantity= vm.StockQuantity,
        //        ThumbnailUrl= vm.ThumbnailUrl,
        //        Weight = vm.Weight,
        //       ShortDescription= vm.ShortDescription,
        //       Width= vm.Width,

        //    };
        //}

    }
}
