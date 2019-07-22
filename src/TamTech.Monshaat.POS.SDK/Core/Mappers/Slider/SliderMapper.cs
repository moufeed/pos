using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sliders.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Sliders;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Slider
{
    public static class SliderMapper
    {

        public static UpdateSliderDto MapDtoToUpdateDto(this SliderDto dto)
        {
            return new UpdateSliderDto
            {
                Id = dto.Id,
                Title = dto.Title,
                Key = dto.Key,
                //Position = dto.Position,
                Summary = dto.Summary,
                Lang = dto.Lang,
                Published = dto.Published,
                Locked = dto.Locked,
                Items = dto.Items != null ? dto.Items.Where(item => !item.Deleted)
                                                            .Select(item => item.MapDtoToUpdateDto(dto.Id))
                                                            .OrderBy(m => m.DisplayOrder)
                                                            .ToList() : new List<UpdateSliderItemDto>()

            };
        }

        public static UpdateSliderItemDto MapDtoToUpdateDto(this SliderItemDto dto, Guid sliderId)
        {
            return new UpdateSliderItemDto
            {
                SliderId = sliderId,
                Id = dto.Id,
                Title = dto.Title,
                Lang = dto.Lang,
                MainImage = dto.MainImage,
                Url = dto.Url,
                UrlTarget = dto.UrlTarget,
                DisplayOrder = dto.DisplayOrder,
                Summary = dto.Summary,
                CreatedDate = dto.CreatedDate,
                Published = dto.Published,
                Deleted = dto.Deleted

            };
        }

        public static CreateSliderDto MapFromVMToCreateDto(this SliderCreationVM vm)
        {
            return new CreateSliderDto
            {

                Title = vm.Title,
                Key = vm.Key,
                //Position = vm.Position,
                Summary = vm.Summary,
                Lang = vm.Lang

            };
        }

        public static SliderCreationVM MapToViewModel(this SliderDto dto)
        {
            return new SliderCreationVM
            {
                Lang = dto.Lang,
                Title = dto.Title,
                Key = dto.Key,
                Summary = dto.Summary,
                //Position = dto.Position,

            };
        }

        public static UpdateSliderDto MapFormUpdateVMToUpdateDto(this UpdateSliderVm vm)
        {
            return new UpdateSliderDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Key = vm.Key,
                //Position = vm.Position,
                Published = vm.Published,
                Summary = vm.Summary,
                Lang = vm.Lang,
                Items = vm.Items != null ? vm.Items.Select(p => p.MapSliderItemVmToSliderItemDto()).ToList() : new List<UpdateSliderItemDto>()
            };
        }

        public static UpdateSliderItemDto MapSliderItemVmToSliderItemDto(this UpdateSliderItemVm vm)
        {
            return new UpdateSliderItemDto
            {
                Id = vm.Id,
                SliderId = vm.SliderId,
                Title = vm.Title,
                Lang = vm.Lang,
                MainImage = vm.Image,
                Url = vm.Url,
                UrlTarget = vm.UrlTarget,
                DisplayOrder = vm.DisplayOrder,
                Published = vm.Published,

            };
        }

        public static UpdateSliderItemDto MapTOUpdateSliderItemDto(this SliderItemDto Dto)
        {
            return new UpdateSliderItemDto
            {
                Lang = Dto.Lang,
                Id = Dto.Id,
                SliderId = Dto.SliderId,
                Title = Dto.Title,
                MainImage = Dto.MainImage,
                Summary = Dto.Summary,
                Url = Dto.Url,
                UrlTarget = Dto.UrlTarget,
                DisplayOrder = Dto.DisplayOrder,
                Published = Dto.Published

            };
        }
        public static CreateSliderItemVm MapSliderItemVm(this CreateSliderItemDto vm)
        {
            return new CreateSliderItemVm
            {
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MainImage = vm.MainImage,
                NewFile = vm.NewFile,
                SliderId = vm.SliderId,
                Summary = vm.Summary,
                Title = vm.Title,
                Url = vm.Url,
                UrlTarget = vm.UrlTarget

            };
        }


        public static CreateSliderItemDto MapSliderItemDto(this CreateSliderItemVm vm)
        {
            return new CreateSliderItemDto
            {
                DisplayOrder = vm.DisplayOrder,
                Lang = vm.Lang,
                MainImage = vm.MainImage,
                NewFile = vm.NewFile,
                SliderId = vm.SliderId,
                Summary = vm.Summary,
                Title = vm.Title,
                Url = vm.Url,
                UrlTarget = vm.UrlTarget 
                 
            };
        }

        //public static CreateSliderItemDto MapCreateDtoToDto(this SliderItemDto dto)
        //{
        //    return new CreateSliderItemDto
        //    {
        //        SliderId = dto.SliderId,
        //        Title = dto.Title,
        //        Lang = dto.Lang,
        //        Image = dto.MainImage,
        //        UrlTarget = dto.UrlTarget,
        //        Summary = dto.Summary,
        //        DisplayOrder = dto.DisplayOrder
        //    };
        //}

        //public static UpdateSliderItemDto ItemDto_UpdateItemDto(this SliderItemDto dto)
        //{
        //    return new UpdateSliderItemDto
        //    {
        //        Id = dto.Id,
        //        SliderId = dto.SliderId,
        //        Title = dto.Title,
        //        Lang = dto.Lang,
        //        Image = dto.MainImage,
        //        UrlTarget = dto.UrlTarget,
        //        DisplayOrder = dto.DisplayOrder
        //    };
        //}

        //public static UpdateSliderVm MapSliderDtoToUpdateSliderVm(this SliderDto dto)
        //{
        //    return new UpdateSliderVm
        //    {
        //        Id = dto.Id,
        //        Title = dto.Title,
        //        Slug = dto.Slug,
        //        Position = dto.Position,
        //        Summary = dto.Summary,
        //        Lang = dto.Lang,
        //        Items = dto.Items != null ? dto.Items.Select(p => p.MapSliderItemVmToSliderItemDto()).ToList() : new List<UpdateSliderItemVm>()
        //    };
        //}

        //public static UpdateSliderItemVm MapSliderItemVmToSliderItemDto(this SliderItemDto dto)
        //{
        //    return new UpdateSliderItemVm
        //    {
        //        Id = dto.Id,
        //        SliderId = dto.SliderId,
        //        Title = dto.Title,
        //        Lang = dto.Lang,
        //        Image = dto.MainImage,
        //        UrlTarget = dto.UrlTarget,
        //        DisplayOrder = dto.DisplayOrder,

        //    };
        //}
    }
}

