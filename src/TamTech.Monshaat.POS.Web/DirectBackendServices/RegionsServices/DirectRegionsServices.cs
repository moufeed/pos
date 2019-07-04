using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices;
using TamTech.Monshaat.POS.Web.DirectBackendServices.RegionsServices.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Regions;
using TamTechSDK.Common.Services.Regions.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.RegionsServices
{
    public class DirectRegionsServices : BaseDirectService, IRegionService
    {

        private readonly TamTech.ContentService.Services.Regions.IRegionService _regionsServices;

        public DirectRegionsServices(TamTech.ContentService.Services.Regions.IRegionService regionsServices)
        {
            _regionsServices = regionsServices;
        }
        public async Task<IRequestProviderResult<int>> CreateAsync(CreateRegionModel model)
        {
            var result = await _regionsServices.CreateAsync(model.MapToBackCreateRegionModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateRegionModel model)
        {
            var result = await _regionsServices.EditAsync(model.MapToBackUpdateRegionModel());
            return MapRequestProviderResult(result);
        }

        public async Task<List<RegionDto>> GetAllExceptSoftDeletedAsync(string lang)
        {
            var result = await _regionsServices.GetAllExceptSoftDeletedAsync(lang);

            return result?.Select(m => m.MapToFrontRegionDto()).ToList();
        }

        public async Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang)
        {
            var result = await _regionsServices.GetAllSelectListAsync(lang);

            return result != null ? result.Select(m => m.MapToFrontEndSelectListItemModel()).ToList() : new List<SelectListItemModel>();
        }

        public async Task<RegionDto> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            var result = await _regionsServices.GetByIdExceptSoftDeletedAsync(id, lang);

            return result?.MapToFrontRegionDto();
        }

        public async Task<PagedResultModel<List<RegionDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _regionsServices.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return new PagedResultModel<List<RegionDto>>
            {
                Data = request.Data?.Select(s => s.MapToFrontRegionDto()).ToList(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<RegionDto> GetPublishedBySlugAsync(string slug)
        {
            var result = await _regionsServices.GetPublishedBySlugAsync(slug);

            return result?.MapToFrontRegionDto();
        }

        public async Task<List<RegionDto>> GetPublishedListAsync(bool sortManually = true)
        {
            var result = await _regionsServices.GetPublishedListAsync(sortManually);

            return result?.Select(m => m.MapToFrontRegionDto()).ToList();
        }

        public async Task<List<RegionDto>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            var result = await _regionsServices.GetPublishedListAsync(takeItems, sortManually);

            return result?.Select(m => m.MapToFrontRegionDto()).ToList();
        }

        public async Task<List<SelectListItemModel>> GetPublishedSelectListAsync(string lang, bool sortManually = true)
        {
            var result = await _regionsServices.GetPublishedSelectListAsync(lang, sortManually);

            return result?.Select(itm => itm.MapToForntSelectListItemModel()).ToList();
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {
            var result = await _regionsServices.PublishAsync(model.MapToBackendPuplishModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            var result = await _regionsServices.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }
    }
}
