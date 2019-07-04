using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Testimonials.Models;
using TamTechSDK.Web.Models.Admin.Testimonials;

namespace TamTechSDK.Web.Extensions.AutoMapper.Testimonials
{
    public static class TestimonialsMapper
    {
        public static CreateTestimonialDto MapFormVMToCreateDto(this TestimonialFormVM vm)
        {
            return new CreateTestimonialDto
            {

                Lang = vm.Lang,
                Title = vm.Title,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                Company = vm.Company,
                Postion = vm.Postion,
                Email = vm.Email,
                AuthorName = vm.AuthorName,
                Rating = vm.Rating

            };
        }



        public static TestimonialFormVM MapDtoToGVm(this TestimonialDto item)
        {
            return new TestimonialFormVM
            {
                Id = item.Id,
                Lang = item.Lang,
                Title = item.Title,
                DisplayOrder = item.DisplayOrder,
                Summary = item.Summary,
                MainImage = item.MainImage,
                PublishedDate = item.PublishedDate,
                ModifiedDate = item.ModifiedDate,
                Published = item.Published,
                Company = item.Company,
                Postion = item.Postion,
                Email = item.Email,
                AuthorName = item.AuthorName,
                Rating = item.Rating
            };
        }


        public static UpdateTestimonialDto MapVmToUpdateDto(this TestimonialFormVM vm)
        {
            return new UpdateTestimonialDto
            {
                Id = vm.Id,
                Lang = vm.Lang,
                Title = vm.Title,
                Summary = vm.Summary,
                MainImage = vm.MainImage,
                DisplayOrder = vm.DisplayOrder,
                Company = vm.Company,
                Postion = vm.Postion,
                Email = vm.Email,
                AuthorName = vm.AuthorName,
                Rating = vm.Rating

            };
        }
    }
}
