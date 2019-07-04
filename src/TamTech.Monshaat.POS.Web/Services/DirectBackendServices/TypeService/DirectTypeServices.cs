using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Services.Statuses;
using TamTech.ContentService.Services.Types;
using TamTech.Monshaat.POS.Web.DirectBackendServices.TypeService.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.TypesService;
using TamTech.Monshaat.POS.Web.Services.TypesService.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.TypeService
{
    public class DirectTypeServices : BaseDirectService, TamTech.Monshaat.POS.Web.Services.TypesService.ITypeService, IContactTypeService, IPosTypeService
    {
        private readonly TamTech.ContentService.Services.Types.ITypeService _typeService;

        public DirectTypeServices(ContentService.Services.Types.ITypeService conUsTypeService)
        {
            _typeService = conUsTypeService;
        }
        public async Task<IRequestProviderResult<int>> CreateAsync(CreateTypeModel model)
        {
            var result = await _typeService.CreateAsync(model.MapToBackCreateType());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateTypeModel model)
        {
            var result = await _typeService.EditAsync(model.MapToBackUpdateModele());
            return MapRequestProviderResult(result);
        }

        public async Task<List<TypeDto>> GetAllExceptSoftDeletedAsync(string lang)
        {
            var request = await _typeService.GetAllExceptSoftDeletedAsync(lang);

            return request != null ? request.Select(itm => itm.MapToForntTypeDto()).ToList() : new List<TypeDto>();
        }

        public async Task<TypeDto> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            var request = await _typeService.GetByIdExceptSoftDeletedAsync(id, lang);

            return request != null ? request.MapToForntTypeDto() : null;

        }

        public async Task<PagedResultModel<List<TypeDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _typeService.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return new PagedResultModel<List<TypeDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToForntTypeDto()).ToList() : new List<TypeDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<TypeDto> GetPublishedBySlugAsync(string slug)
        {
            var request = await _typeService.GetPublishedBySlugAsync(slug);
            return request != null ? request.MapToForntTypeDto() : null;
        }

        public async Task<List<TypeDto>> GetPublishedListAsync(bool sortManually = true)
        {
            var request = await _typeService.GetPublishedListAsync(sortManually);

            return request != null ? request.Select(itm => itm.MapToForntTypeDto()).ToList() : new List<TypeDto>();
        }

        public async Task<List<TypeDto>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            var request = await _typeService.GetPublishedListAsync(takeItems, sortManually);

            return request != null ? request.Select(itm => itm.MapToForntTypeDto()).ToList() : new List<TypeDto>();
        }

        public async Task<List<SelectListItemModel>> GetSelectListAsync(string lang, bool isOfficial = true)
        {
            var result = await _typeService.GetSelectListAsync(lang, isOfficial);

            return result != null ? result.Select(itm => itm.MapToForntSelectListItemModel()).ToList() : new List<SelectListItemModel>();

        }
        public async Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang)
        {
            var result = await _typeService.GetAllSelectListAsync(lang);

            return result != null ? result.Select(itm => itm.MapToForntSelectListItemModel()).ToList() : new List<SelectListItemModel>();

        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {
            var result = await _typeService.PublishAsync(model.MapToBackendPuplishModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            var result = await _typeService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }
    }
}
