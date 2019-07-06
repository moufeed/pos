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
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.TypeService
{
    public class DirectTypeServices : BaseDirectService, TamTech.Monshaat.POS.Web.Services.ContentService.Types.ITypeService, IContactTypeService, IPosTypeService
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

        public async Task<IRequestProviderResult<List<TypeDto>>> GetAllExceptSoftDeletedAsync(string lang)
        {
            var request = await _typeService.GetAllExceptSoftDeletedAsync(lang);

            var result = request != null ? request.Select(itm => itm.MapToForntTypeDto()).ToList() : new List<TypeDto>();

            return ReturnRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<TypeDto>> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            var request = await _typeService.GetByIdExceptSoftDeletedAsync(id, lang);

            return ReturnRequestProviderResult(request?.MapToForntTypeDto());

        }

        public async Task<IRequestProviderResult<PagedResultModel<List<TypeDto>>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _typeService.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return ReturnRequestProviderResult(new PagedResultModel<List<TypeDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToForntTypeDto()).ToList() : new List<TypeDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            });
        }

        public async Task<IRequestProviderResult<TypeDto>> GetPublishedBySlugAsync(string slug)
        {
            var request = await _typeService.GetPublishedBySlugAsync(slug); 
            return ReturnRequestProviderResult(request?.MapToForntTypeDto());
        }

        public async Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            var request = await _typeService.GetPublishedListAsync(sortManually);

            var result = request != null ? request.Select(itm => itm.MapToForntTypeDto()).ToList() : new List<TypeDto>();
            return ReturnRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            var request = await _typeService.GetPublishedListAsync(takeItems, sortManually);

           var  result = request != null ? request.Select(itm => itm.MapToForntTypeDto()).ToList() : new List<TypeDto>();
            return ReturnRequestProviderResult(result);
        }



        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetSelectListAsync(string lang, bool isOfficial = true)
        {
            var result = await _typeService.GetSelectListAsync(lang, isOfficial);

            return ReturnRequestProviderResult(result != null ? result.Select(itm => itm.MapToForntSelectListItemModel()).ToList() : new List<SelectListItemModel>());

            
        }
        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang)
        {
            var result = await _typeService.GetAllSelectListAsync(lang);

            return ReturnRequestProviderResult(result != null ? result.Select(itm => itm.MapToForntSelectListItemModel()).ToList() : new List<SelectListItemModel>());

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
