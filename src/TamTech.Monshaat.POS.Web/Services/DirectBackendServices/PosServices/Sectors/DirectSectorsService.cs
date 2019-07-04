using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TamTech.ContentService.Services.Sectors;
using TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Sectors.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Sectors
{
    public class DirectSectorsService : BaseDirectService, ISectorServices
    {
        private readonly IPOSSectorService _sectorservices;

        public DirectSectorsService(IPOSSectorService sectorServices)
        {

            _sectorservices = sectorServices;
        }



        #region public methods
        public async Task<SectorDto> GetPublishedBySlugAsync(string slug)
        {

            var request = await _sectorservices.GetPublishedBySlugAsync(slug);

            return request != null ? request.MapToForntSectorDto() : null;

        }

        public async Task<List<SectorDto>> GetPublishedListAsync(bool sortManually = true)
        {
            var request = await _sectorservices.GetPublishedListAsync(sortManually);

            return request != null ? request.Select(s => s.MapToForntSectorDto()).ToList() : new List<SectorDto>();

        }
        public async Task<List<SectorDto>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            var request = await _sectorservices.GetPublishedListAsync(takeItems, sortManually);

            return request != null ? request.Select(s => s.MapToForntSectorDto()).ToList() : new List<SectorDto>();

        }

        #endregion


        #region admin methods
        public async Task<List<SectorDto>> GetAllExceptSoftDeletedAsync(string lang)
        {
            var request = await _sectorservices.GetAllExceptSoftDeletedAsync(lang);

            return request != null ? request.Select(s => s.MapToForntSectorDto()).ToList() : new List<SectorDto>();
        }

        public async Task<SectorDto> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            var request = await _sectorservices.GetByIdExceptSoftDeletedAsync(id, lang);

            return request != null ? request.MapToForntSectorDto() : null;
        }


        public async Task<PagedResultModel<List<SectorDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _sectorservices.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return new PagedResultModel<List<SectorDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToForntSectorDto()).ToList() : new List<SectorDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }



        public async Task<IRequestProviderResult<int>> CreateAsync(CreateSectorModel model)
        {

            var result = await _sectorservices.CreateAsync(model.MapToBackCreateSectorModel());
            return MapRequestProviderResult(result);

        }



        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateSectorModel model)
        {

            var result = await _sectorservices.EditAsync(model.MapToBackUpdateSectorModel());
            return MapRequestProviderResult(result);

        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {

            var result = await _sectorservices.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);



        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {

            var result = await _sectorservices.PublishAsync(model.MapToBackendPuplishModel());
            return MapRequestProviderResult(result);

        }

        public async Task<List<SelectListItemModel>> GetSelectListAsync(string lang, bool isOfficial = true)
        {
            var result = await _sectorservices.GetSelectListAsync(lang, isOfficial);

            return result != null ? result.Select(itm => itm.MapToForntSelectListItemModel()).ToList() : new List<SelectListItemModel>();
        }
        public async Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang)
        {
            var result = await _sectorservices.GetAllSelectListAsync(lang);

            return result != null ? result.Select(itm => itm.MapToForntSelectListItemModel()).ToList() : new List<SelectListItemModel>();
        }

        #endregion
    }
}




