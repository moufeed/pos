using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;

namespace TamTechSDK.Common.Services.ContentService.Categories
{
    public class MockCategoriesServices
    {
        public async  Task<IRequestProviderResult<object>> DeleteCategoryByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }


        public async Task<IRequestProviderResult<List<Category>> > GetCategoriesAsync()
        {
            Random rang = new Random();
            return new RequestProviderResult<List<Category>>
            {
                Success = true,
                Data = new List<Category>
            {
                new Category
                {
                    Id = new Guid("ed1416f1-31d4-488a-b7fe-09f198497ea0"),
                    Name ="Food",
                    Description ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius ex ipsa quae alias expedita eos.",
                    ImageUrl="/images/categories/food.jpg",
                },
                new Category
                {
                    Id = new Guid("c24c924d-954d-4354-85d4-564a9dda9857"),
                    Name ="Travel",
                    Description ="Lorem ipsum dolor sit, amet consectetur  Eius ex ipsa quae alias expedita eos.",
                   ImageUrl="/images/categories/travel.jpg",
                },
                new Category
                {
                    Id = new Guid("ffb99f6a-e826-4c63-8e4b-a8280c990859"),
                    Name ="Fashion",
                    Description =" alias expedita eos.",
                    ImageUrl="/images/categories/fashion.png",
                },
                new Category
                {
                   Id = new Guid("b0ac85ec-850c-4ec6-8cd5-7f7689bfd047"),
                    Name ="Books",
                    Description ="Lorem ipsum dolor sit,Eius ex ipsa quae alias expedita eos.",
                    ImageUrl="/images/categories/food.jpg",
                },
                new Category
                {
                     Id = new Guid("44308c94-63e5-4998-b61e-a4d18647f1fa"),
                    Name ="Home Audio/Video",
                    Description ="Lorem ipsum dolor sit",
                    ImageUrl="/images/categories/media.jpg",
                },
                new Category
                {
                    Id = new Guid("d27907dd-50b1-4708-9681-a7dc74f028c2"),
                    Name ="Freebies",
                    Description ="",
                    ImageUrl="/images/categories/freebies.jpg",
                },
                new Category
                {
                    Id = new Guid("6ff65cdf-0979-4e43-82cd-7329e4c835f1"),
                    Name ="Health",
                    Description ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius ex ipsa quae",
                    ImageUrl="/images/categories/health.jpg",
                },
                new Category
                {
                    Id = new Guid("176b6d1b-8b2f-4e68-9972-4a07a4faae26"),
                    Name ="Electronics",
                    Description ="amet consectetur adipisicing elit. Eius ex ipsa quae alias expedita eos.",
                    ImageUrl="/images/categories/electronics.jpg",
                },
                new Category
                {
                     Id = new Guid("8a52549f-65db-4afb-ad0f-1eb7b6a9edc9"),
                    Name ="Sports & Fitness ",
                    Description ="Lorem ipsum dolor sit, amet consectetur adipisicing elit",
                    ImageUrl="/images/categories/sports.jpg",
                },
                new Category
                {
                     Id = new Guid("f26e5f30-5d77-4dbb-95fb-233aa20efc49"),
                    Name ="Informations",
                    Description ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius ex ipsa quae alias expedita eos.",
                    ImageUrl="/images/categories/informations.jpg",
                }
            }
        };
        }

        public async  Task<IRequestProviderResult<Category>> GetCategoryByIdAsync(string id)
        {
            return new RequestProviderResult<Category>
            {
                Success= true,
                Data = new Category
                {
                    Id = new Guid("176b6d1b-8b2f-4e68-9972-4a07a4faae26"),
                    Name = "Informations",
                    Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius ex ipsa quae alias expedita eos.",
                    ImageUrl = "/images/categories/informations.jpg",
                }
            };
        }
    }
}
