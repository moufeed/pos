using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Core.Domain.Models;
using TamTech.ContentService.Services.Shared.Dtos;
using TamTech.ContentService.Services.Values.Models;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ValuesServices.Mapper;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ValuesServices;
using TamTechSDK.Common.Services.ValuesServices.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ValuesServices
{
    public class DirectValuesServies : BaseDirectService, IValueService, IPosValuesService
    {
        private readonly TamTech.ContentService.Services.Values.IValueService _valuesServices;

        public DirectValuesServies(ContentService.Services.Values.IValueService valuesServices)
        {
            _valuesServices = valuesServices;
        }

        public async Task<IRequestProviderResult<int>> CreateAsync(TamTechSDK.Common.Services.ValuesServices.Models.CreateValueModel model)
        {
            var result = await _valuesServices.CreateAsync(model.MapToBackendCreateValueModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(TamTechSDK.Common.Services.ValuesServices.Models.UpdateValueModel model)
        {
            var result = await _valuesServices.EditAsync(model.MapToBackendUpdateValueModel());
            return MapRequestProviderResult(result);
        }

        public async Task<List<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto>> GetAllExceptSoftDeletedAsync(string lang)
        {
            var request = await _valuesServices.GetAllExceptSoftDeletedAsync(lang);

            return request?.Select(s => s.MapToForntValueDto()).ToList();
        }

        public async Task<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            var request = await _valuesServices.GetByIdExceptSoftDeletedAsync(id, lang);
            return request?.MapToForntValueDto();
        }

        public async Task<TamTechSDK.Common.Models.Pagination.PagedResultModel<List<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _valuesServices.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());
            return new TamTechSDK.Common.Models.Pagination.PagedResultModel<List<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto>>
            {
                Data = request.Data?.Select(s => s.MapToForntValueDto()).ToList(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new TamTechSDK.Common.Models.Pagination.PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto> GetPublishedBySlugAsync(string slug)
        {
            var request = await _valuesServices.GetPublishedBySlugAsync(slug);
            return request?.MapToForntValueDto();
        }

        public async Task<List<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto>> GetPublishedListAsync(bool sortManually = true)
        {
            var request = await _valuesServices.GetPublishedListAsync(sortManually);

            return request?.Select(s => s.MapToForntValueDto()).ToList();
        }

        public async Task<List<TamTechSDK.Common.Services.ValuesServices.Models.ValueDto>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            var request = await _valuesServices.GetPublishedListAsync(takeItems, sortManually);

            return request?.Select(s => s.MapToForntValueDto()).ToList();
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {
            var result = await _valuesServices.PublishAsync(model.MapToBackendPuplishModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            var result = await _valuesServices.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }
    }
}
