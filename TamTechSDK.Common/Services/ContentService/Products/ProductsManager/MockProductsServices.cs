using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Brands.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace TamTechSDK.Common.Services.ContentService.Products
{
    public class MockProductsServices  
    {
        public async Task<IRequestProviderResult<object>> DeleteProductByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }

        public async  Task<IRequestProviderResult<object>> DeleteProductImagesUrlsAsync(List<string> imagesUrl)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }

        public async Task<IRequestProviderResult<Product>> GetProductByIdAsync(string id)
        {
            return new RequestProviderResult<Product>
            {
                Success = true,
                Data = new Product
                {
                    Id = new Guid("2799a6f5-3114-4ab0-a814-156989e17b0a"),
                    Name = "Huawei P10 VTR-L29 Dual Sim - 64GB, 4GB RAM, 4G LTE, Dazzling Blue",
                    MainImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/list/2.jpg",
                    ShortDescription = "Huawei P10 mobile has a large 64GB onboard storage to satisfy your data hunger",
                    FullDescription = "Huawei P10 mobile has a large 64GB onboard storage to satisfy your data hunger",
                    StockQuantity = 320,
                    DiscountPrice = 1499.00,
                    Price = 2099.00,
                    SKU = "HP10VTDS_B",
                    Published = true,
                    Brand = new Brand() { Id =  new Guid("9380867e-bc05-4111-ba17-fb8927e0d253") },
                    Categories = new List<Category>
                    {
                        new Category() {Id = new Guid("176b6d1b-8b2f-4e68-9972-4a07a4faae26") },
                        new Category() {Id = new Guid("44308c94-63e5-4998-b61e-a4d18647f1fa") }
                    },
                    Specifications = new Dictionary<string, string>
                    {
                            { "Brand", "Huawei" },
                            { "Operating System Type", "Android" },
                            { "Storage Capacity", "64 GB" },
                            { "Number Of SIM", "Dual SIM" },
                            { "Mobile Phone Type", "Smartphone" },
                            { "Cellular Network Technology", "4G LTE" },
                            { "CPU", "Octa Core" },
                            { "Chipset manufacturer", "Huawei Kirin" },
                            { "Model Number", "Nova 3e" },
                            { "Battery Capacity in mAh", "2000 - 3000 mAH" },
                            { "Rear Camera Resolution", "16 MP + 2 MP" },
                            { "Display Size (Inch)", "5.8 inch" },
                            { "Front Camera", "16 MP" },
                            { "Operating System Version", "Android 8.0" },
                            { "Memory RAM", "4 GB" },
                    },
                    Images = new List<string>
                        {
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-1.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-2.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-3.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-4.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-5.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-6.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-7.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-8.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-9.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-10.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-11.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-12.jpg",
                            "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-13.jpg"
                        },
                    Attributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                Name = "color",
                                //Required = false,
                                Type ="select",
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        Value = "Black",
                                       // ProductId = new Guid("fb5e74f7-9c05-438b-8212-7d22851c1940"),
                                        //Quantity = 15,
                                    },
                                    new ProductAttributeValue
                                    {
                                        Value = "Blue",
                                      //  ProductId = new Guid("fb5e74f7-9c05-438b-8212-7d22851c1940"),
                                       // Quantity = 25
                                    }
                                },

                            },
                              new ProductAttribute
                            {
                                Name = "Size",
                                //isRequired = false,
                                Type ="select",
                                Values = new List<ProductAttributeValue>
                                {
                                    new ProductAttributeValue
                                    {
                                        Value = "Larg",
                                     //   ProductId = new Guid("fb5e74f7-9c05-438b-8212-7d22831c1940"),
                                    //    Quantity = 105,
                                    },
                                    new ProductAttributeValue
                                    {
                                        Value = "Small",
                                     //   ProductId = new Guid("fb5e74f7-9c05-438b-8212-7d22831c1940"),
                                     //   Quantity = 25
                                    }
                                },

                            }
                        },
                }
            };
        }

        public async Task<IRequestProviderResult<List<ProductLite>>> GetProductsAsync()
        {
            return new RequestProviderResult<List<ProductLite>>
            {
                Success = true,
                Data = new List<ProductLite>
                {
                    new ProductLite
                    {
                        Id = "fb5e74f7-9c05-438b-8212-7d22851c1940" ,
                        Name="Huawei Nova 3e Dual SIM -64GB,4GB RAM, 4G LTE",
                        ThumbnailUrl = "https://tamcommercedemo.blob.core.windows.net/demo/products/huawei-nova-3e/item-1.jpg",
                        ShortDescription="The Huawei Nova 3e Dual SIM takes visual appeal and chic to a whole new level. It flaunts a gorgeous Midnight Black finish that looks striking against the vibrancy of the full HD screen.",
                        StockQuantity = 1500,
                        OldPrice =  1910.95,
                        Price = 1258.95,
                        SKU = "HNDSLT",
                        Published = false,
                        Categories = new List<string>{
                        "Mobile Phones"
                        }
                    },
                     new ProductLite
                    {
                        Id = "c28fb34f-c10a-4bc5-847f-ddea4a181e82",
                        Name="Huawei Mate 9 Dual Sim - 64 GB, 4 GB RAM, 4G LTE , Mocha Brown",
                        ThumbnailUrl =  "https://tamcommercedemo.blob.core.windows.net/demo/list/1.jpg" ,
                        ShortDescription="Huawei Mate9 smartphone features dual SIM slots and cutting edge features for your convenience. This Huawei smartphone is available in a rugged brown finish.Sporting a sleek design and curved edges" ,
                        StockQuantity = 530,
                        OldPrice =2173.00,
                        Price = 1.58900,
                        SKU = "HM9DS_64_Mb",
                        Published = true,
                        Categories = new List<string>{ "Mobile Phones"}
                    },
                      new ProductLite
                    {
                        Id = "2799a6f5-3114-4ab0-a814-156989e17b0a",
                        Name="Huawei P10 VTR-L29 Dual Sim - 64GB, 4GB RAM, 4G LTE, Dazzling Blue",
                        ThumbnailUrl = "https://tamcommercedemo.blob.core.windows.net/demo/list/2.jpg" ,
                        ShortDescription="Huawei P10 mobile has a large 64GB onboard storage to satisfy your data hunger" ,
                        StockQuantity = 320,
                        OldPrice =1499.00,
                        Price = 2099.00 ,
                        SKU = "HP10VTDS_B",
                        Published = false,
                        Categories = new List<string>{ "Mobile Phones" }
                    },
                       new ProductLite
                    {
                        Id = "531f2a51-8d79-44cb-91e6-720b9798aaa6",
                        Name="Samsung Galaxy S8+ Dual Sim - 64GB, 4G LTE, Midnight Black",
                        ThumbnailUrl = "https://tamcommercedemo.blob.core.windows.net/demo/list/3.jpg",
                        ShortDescription="Samsung Galaxy S8 Plus features a large 6.2inch" ,
                        StockQuantity = 950,
                        OldPrice = 2098.95,
                        Price = 3099.00,
                        SKU = "SGS8DS64_MB",
                        Published = true,
                        Categories = new List<string>{}
                    },
                        new ProductLite
                    {
                        Id = "657ec7ef-775f-46c2-a0bc-9fb8a2b141ab",
                        Name="JBL In-Ear Headphones, White - T110",
                        SKU = "JBINHET110_W",
                        ThumbnailUrl = "https://tamcommercedemo.blob.core.windows.net/demo/list/13.jpg",
                        ShortDescription="Experience real music with the JBL in ear headphones, your everyday companion. Compact and sturdy, these JBL headphones will stay tangle free even while folded.JBL is a trusted brand for precise, clear and appealing sound and quality bass effects. You should go ahead and purchase this pair of headphones as it will make the music soothing to your ears and eventually the music will",
                        StockQuantity = 128,
                        OldPrice =  56.00,
                        Price =103.95,
                        Published = true,
                        Categories = new List<string>{ "Mobile Phones"  , "accesories" }
                    }
                }
            };
        }
    }
}
 
 