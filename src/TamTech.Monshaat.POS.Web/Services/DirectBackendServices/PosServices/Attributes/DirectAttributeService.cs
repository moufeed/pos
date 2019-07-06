using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Attributes.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Attributes
{
    public class DirectAttributeService : BaseDirectService, IAttributeService, IPOSAttributeService
    {
        private readonly TamTech.ContentService.Services.Attributes.IAttributeService _AttributeService;

        public DirectAttributeService(ContentService.Services.Attributes.IAttributeService AttributeService)
        {
            _AttributeService = AttributeService;
        }
        public async Task<IRequestProviderResult<int>> CreateAsync(CreateAttributeModel model)
        {
            var result = await _AttributeService.CreateAsync(model.MapToBackendCreateAttribute());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateAttributeModel model)
        {
            var result = await _AttributeService.EditAsync(model.MapToBackendUpdateAttribute());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<List<AttributeDto>>> GetAllAsync(string lang)
        {
            var request = await _AttributeService.GetAllExceptSoftDeletedAsync(lang);

            return ReturnRequestProviderResult(request != null ? request.Select(s => s.MapToForntAttributeDto()).ToList() : new List<AttributeDto>());
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<AttributeDto>>>> GetAsync(DTFilter model)
        {
            var request = await _AttributeService.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());
            return ReturnRequestProviderResult( new PagedResultModel<List<AttributeDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToForntAttributeDto()).ToList() : new List<AttributeDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            });
        }

        public async Task<IRequestProviderResult<List<TamTech.Monshaat.POS.Web.Models.Dtos.SelectList.SelectListItemModel>>> GetAllSelectListAsync(string lang)
        {
            var result = await _AttributeService.GetAllSelectListAsync(lang);

            return ReturnRequestProviderResult(result?.Select(itm => itm.MapToForntSelectListItemModel()).ToList());

        }


        public async Task<IRequestProviderResult<AttributeDto>> GetByIdAsync(int id, string lang)
        {
            var request = await _AttributeService.GetByIdExceptSoftDeletedAsync(id, lang);
            return ReturnRequestProviderResult(request != null ? request.MapToForntAttributeDto() : null);

        }

        public async Task<IRequestProviderResult<AttributeDto>> GetPublishedBySlugAsync(string slug)
        {
            var request = await _AttributeService.GetPublishedBySlugAsync(slug);
            return ReturnRequestProviderResult(request != null ? request.MapToForntAttributeDto() : null);
        }

        public async Task<IRequestProviderResult<List<AttributeDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            var request = await _AttributeService.GetPublishedListAsync(sortManually);

            return ReturnRequestProviderResult(request != null ? request.Select(s => s.MapToForntAttributeDto()).ToList() : new List<AttributeDto>());
        }

        public async Task<IRequestProviderResult<List<AttributeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            var request = await _AttributeService.GetPublishedListAsync(takeItems, sortManually);

            return ReturnRequestProviderResult(request != null ? request.Select(s => s.MapToForntAttributeDto()).ToList() : new List<AttributeDto>());
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishLookupModel model)
        {
            var result = await _AttributeService.PublishAsync(model.MapToBackendPuplishModel());
            return MapRequestProviderResult(result);

        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            var result = await _AttributeService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }
    }
}
