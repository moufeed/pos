using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus
{
    public class MockMenusServices 
    {
        public async Task<IRequestProviderResult<List<MenuDto>>> GetAllAsync()
        {
            return new RequestProviderResult<List<MenuDto>>
            {
                Success = true,
                Data = new List<MenuDto>
                    {
                        new MenuDto
                        {
                            Key = "MainMenu",
                            Title="header menu",
                            Position= "header",
                            CreatedDate = DateTime.Now
                        },
                         new MenuDto
                        {
                            Key = "MainMenu",
                            Title="header menu",
                            Position= "header",
                            CreatedDate = DateTime.Now
                        }
                    }
            };
        }

        public async Task<IRequestProviderResult<Guid>> CreateAsync(MenuDto menu)
        {
            return new RequestProviderResult<Guid>
            {
                Success = true,
                Data = new Guid("6accf447-795d-4a68-bb52-025039dde0c7")

            };
        }


        //public async Task<IRequestProviderResult<List<Menu>>> GetAllAsync()
        //{

        //    /*
        //     var result =   await _requestProvider.GetAsync<List<Menu>>(_backendSettings.GetMenusAsyncEndpoint);
        //     return result; 
        //    */


        //    return new RequestProviderResult<List<Menu>>
        //    {
        //        Success = true,
        //        Data = new List<Menu>
        //            {
        //                new Menu
        //                {
        //                    Key = "MainMenu",
        //                    Title="header menu",
        //                    Position= "header",
        //                    CreatedDate = DateTime.Now
        //                },
        //                 new Menu
        //                {
        //                    Key = "MainMenu",
        //                    Title="header menu",
        //                    Position= "header",
        //                    CreatedDate = DateTime.Now
        //                }
        //            }
        //    };
        //}


    }
}
