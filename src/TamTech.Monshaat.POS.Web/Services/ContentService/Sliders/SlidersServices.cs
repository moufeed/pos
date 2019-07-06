using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sliders
{
	public class SlidersServices : ISlidersServices
	{
		public async Task<IRequestProviderResult<bool>> CreateSliderASync(SliderItemDto slider)
		{
			return new RequestProviderResult<bool>
			{
				Success = true,
				Data = true
			};
		}

		public async Task<IRequestProviderResult<bool>> DeleteSliderByIdAsync(Guid id)
		{
			return new RequestProviderResult<bool>
			{
				Success = true,
				Data = true
			};
		}

		public async Task<IRequestProviderResult<SliderItemDto>> GetSliderByIdAsync(Guid id)
		{
			return new RequestProviderResult<SliderItemDto>
			{
				Success = true,
				Data = new SliderItemDto
				{
					Id = new Guid("ff18d7f1-6e01-44e5-98c4-f983ddb3be42"),
					Title = "Creative Websites",
					//Slug = "creative_websites",
					MainImage = "http://via.placeholder.com/150x150",
					Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ",
					CreatedDate = DateTime.Now,
					DisplayOrder = 3,
				}
			};
		}

		public async Task<IRequestProviderResult<List<SliderItemDto>>> GetAllSlidersAsync()
		{
			return new RequestProviderResult<List<SliderItemDto>>
			{
				Success = true,
				Data = new List<SliderItemDto>
				{
					new SliderItemDto {
						Id = new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
						Title = "Mobile Apps",
						//Slug ="mobile_apps",
						MainImage ="http://via.placeholder.com/150x150",
						Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
						CreatedDate = DateTime.Now,
						DisplayOrder = 2,
						
					},
					new SliderItemDto {
						Id = new Guid("4d657f36-9ca3-4520-879c-64eea6947ad7"),
						Title = "Creative Websites",
						//Slug ="creative_websites",
						MainImage ="http://via.placeholder.com/150x150",
						Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ",
						CreatedDate = DateTime.Now,
						DisplayOrder = 3,
						
					},
					new SliderItemDto {
						Id = new Guid("2688b521-760d-4e95-a879-89db1c009cc8"),
						Title = "SEO Optimization",
						///Slug ="seo_optimzation",
						MainImage ="http://via.placeholder.com/150x150",
						Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
						CreatedDate = DateTime.Now,
						DisplayOrder = 0,
						
					} ,
					new SliderItemDto {
						Id = new Guid("3fd2b6e4-8585-4fe2-b81d-b41e1da25d29"),
						Title = "SEO Optimization",
						//Slug ="seo_optimzation",
						MainImage ="http://via.placeholder.com/150x150",
						Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
						CreatedDate = DateTime.Now,
						DisplayOrder = 0,
						
					}
				}
			};
		}

		public async Task<IRequestProviderResult<bool>> publishSliderByIdAsync(PublishModel data)
		{
			return new RequestProviderResult<bool>
			{
				Success = true,
				Data = true
			};
		}

		public async Task<IRequestProviderResult<bool>> UpdateSliderAsync(SliderItemDto slider)
		{
			throw new NotImplementedException();
		}

        public Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<SliderDto>>> GetAllAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> CreateASync(SliderDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> UpdateAsync(SliderDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> publishByIdAsync(PublishModel data)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> CreateSliderItemASync(SliderItemDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(SliderItemDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<Guid>> CreateASync(CreateSliderDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> UpdateAsync(UpdateSliderDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(SliderItemKeysDto model, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<Guid>> CreateSliderItemASync(CreateSliderItemDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(UpdateSliderItemDto slider)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(SliderItemKeysDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(SliderItemKeysDto modle)
        {
            throw new NotImplementedException();
        }

        public Task<SliderDto> GetPublicBySlugAsync(string slug, string lang)
        {
            throw new NotImplementedException();
        }


        public Task<IRequestProviderResult<SliderDto>> GetPublicByKeyAsync(string slug )
        {
            throw new NotImplementedException();
        }
      

        public Task<IRequestProviderResult<SliderDto>> GetPublicByKeyAsync(int settingId)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<SliderDto>> GetPublishedBySettingIdAsync(int settingId)
        {
            throw new NotImplementedException();
        }
    }
}
