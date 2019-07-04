using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Brands.Models;

namespace TamTechSDK.Common.Services.ContentService.Brands
{
    public class MockBrandsServices 
    {
        public async Task<IRequestProviderResult<object>> DeleteBrandByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }

        public async  Task<IRequestProviderResult<Brand>> GetBrandByIdAsync(string id)
        {
            return new RequestProviderResult<Brand>
            {
                Success = true,
                Data = new Brand
                {
                    Id = new Guid("76274b26-10dd-4fd8-9167-9e4232512b81"),
                    ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/lg.jpg",
                    Name = "LG",
                    Order = 1
                }
            };
        }

        public async  Task<IRequestProviderResult<List<Brand>>> GetBrandsListAsync()
        {
            return new RequestProviderResult<List<Brand>>
            {
                Success = true,
                Data = new List<Brand>
                {
                     new Brand
                    {
                        Id  = new Guid("d4dc806e-18e7-45b9-8807-91eb9298d1fa"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/samsung.jpg",
                        Name = "Samsung",
                        Order = 1
                    },
                    new Brand
                    {
                        Id = new Guid("76274b26-10dd-4fd8-9167-9e4232512b81"),
                        ImageUrl ="https://tamcommercedemo.blob.core.windows.net/demo/lg.jpg",
                        Name = "LG",
                        Order = 12
                    },
                    new Brand
                    {
                        Id = new Guid("a326d74a-44da-48b1-835e-10d4a0067f3f"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/apple.jpg",
                        Name ="Apple",
                        Order = 2
                    },
                    new Brand
                    {
                        Id = new Guid("b6abe2d4-3e25-4b46-8c73-774fa26b52c0"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/braun.jpg",
                        Name = "Braun",
                        Order = 3
                    },
                    new Brand
                    {
                        Id = new Guid("c0843d70-752f-4801-9585-308c3a127b9d"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/canon.jpg",
                        Name = "Canon",
                        Order = 4
                    },
                    new Brand
                    {
                        Id = new Guid("370edbb4-03d6-4d88-bbc9-bf5ef33186be"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/kenwood.jpg",
                        Name = "Kenwood",
                        Order = 5
                    },
                    new Brand
                    {
                        Id = new Guid("9380867e-bc05-4111-ba17-fb8927e0d253"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/huawei.jpg",
                        Name = "Huawei",
                        Order = 6
                    },
                    new Brand
                    {
                        Id = new Guid("5b478c56-47e6-48b1-b947-a814bb705b08"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/blackberry.jpg",
                        Name = "BlackBerry",
                        Order = 7
                    },
                    new Brand
                    {
                        Id = new Guid("fb9bc06a-e1ca-4605-b97d-4cfa50016790"),
                        ImageUrl  = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/google.png",
                        Name = "Google" ,
                        Order = 8
                    },
                    new Brand
                    {
                        Id = new Guid("b12ebf9d-5ac5-453e-b0a7-029b9f7f5759"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/coca-cola.jpg",
                        Name = "Coca-Cola" ,
                        Order = 10
                    },
                    new Brand
                    {
                        Id = new Guid("bebcc550-f1f4-4729-b611-846f5260155d"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/microsoft.jpg",
                        Name = "Microsoft" ,
                        Order = 11
                    },
                    new Brand
                    {
                        Id = new Guid("87d7b8bc-96d4-414b-a461-e93bef5b648a"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/ibm.png",
                        Name = "IBM" ,
                        Order = 10
                    },
                    new Brand
                    {
                        Id = new Guid("994777fc-2a49-4598-bd2c-c00aa9324b52"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/toyota.jpg",
                        Name = "Toyota" ,
                        Order = 4
                    },
                    new Brand
                    {
                        Id = new Guid("20a1be37-89e8-4f2c-a353-d26495c11775"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/zara.jpg",
                        Name = "Zara" ,
                        Order = 5
                    },
                    new Brand
                    {
                        Id = new Guid("a90efa27-ee20-4528-9aca-4b76e5e660fb"),
                        ImageUrl = "https://tamcommercedemo.blob.core.windows.net/demo/Brands/mercedes-benz.png",
                        Name = "Mercedes-Benz" ,
                        Order = 13
                    },
                }
            };
        }
    }
}
