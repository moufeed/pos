using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Core.Domain.Models;
using TamTech.ContentService.Services.Shared.Dtos;
using TamTech.ContentService.Services.Values.Models;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ValuesServices.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ValuesServices;
using TamTech.Monshaat.POS.Web.Services.ValuesServices.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ValuesServices
{
    public class DirectValuesServies : BaseDirectService, IValueService, IPosValuesService
    {
        private readonly TamTech.ContentService.Services.Values.IValueService _valuesServices;

        public DirectValuesServies(ContentService.Services.Values.IValueService valuesServices)
        {
            _valuesServices = valuesServices;
        }

        public async Task<IRequestProviderResult<int>> CreateAsync(TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.CreateValueModel model)
        {
            var result = await _valuesServices.CreateAsync(model.MapToBackendCreateValueModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.UpdateValueModel model)
        {
            var result = await _valuesServices.EditAsync(model.MapToBackendUpdateValueModel());
            return MapRequestProviderResult(result);
        }

        public async Task<List<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto>> GetAllExceptSoftDeletedAsync(string lang)
        {
            var request = await _valuesServices.GetAllExceptSoftDeletedAsync(lang);

            return request?.Select(s => s.MapToForntValueDto()).ToList();
        }

        public async Task<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            var request = await _valuesServices.GetByIdExceptSoftDeletedAsync(id, lang);
            return request?.MapToForntValueDto();
        }

        public async Task<TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PagedResultModel<List<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _valuesServices.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());
            return new TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PagedResultModel<List<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto>>
            {
                Data = request.Data?.Select(s => s.MapToForntValueDto()).ToList(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto> GetPublishedBySlugAsync(string slug)
        {
            var request = await _valuesServices.GetPublishedBySlugAsync(slug);
            return request?.MapToForntValueDto();
        }

        public async Task<List<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto>> GetPublishedListAsync(bool sortManually = true)
        {
            var request = await _valuesServices.GetPublishedListAsync(sortManually);

            return request?.Select(s => s.MapToForntValueDto()).ToList();
        }

        public async Task<List<TamTech.Monshaat.POS.Web.Services.ValuesServices.Models.ValueDto>> GetPublishedListAsync(int takeItems, bool sortManually = true)
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
