using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Testimonials.Mapper
{
    public static class TestimonialsMapper
    {
        public static TamTech.ContentService.Services.Testimonials.Dtos.CreateTestimonialModel MapToBackendDto(this TamTechSDK.Common.Services.ContentService.Testimonials.Models.CreateTestimonialDto item)
        {
            return new TamTech.ContentService.Services.Testimonials.Dtos.CreateTestimonialModel
            {

                DisplayOrder = item.DisplayOrder,
                Lang = item.Lang,
                MainImage = item.MainImage,
                AuthorName = item.AuthorName,
                Summary = item.Summary,
                Postion = item.Postion,
                Company = item.Company,
                Email = item.Email,
                Rate = item.Rating,
                Title = item.Title,
                Slug = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString() + "_" + item.Lang,
            };
        }


        public static TamTechSDK.Common.Services.ContentService.Testimonials.Models.TestimonialDto MapToFrontendDto(this TamTech.ContentService.Services.Testimonials.Dtos.TestimonialDto item)
        {
            return new TamTechSDK.Common.Services.ContentService.Testimonials.Models.TestimonialDto
            {

                DisplayOrder = item.DisplayOrder,
                Lang = item.Lang,
                MainImage = item.MainImage,
                AuthorName = item.AuthorName,
                Summary = item.Summary,
                Postion = item.Postion,
                Company = item.Company,
                Email = item.Email,
                Rating = item.Rate,
                Title = item.Title,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                Published = item.Published,
                PublishedDate = item.PublishedDate,
                Id = item.Id,
                Locked = item.Locked,
                Slugs = item.Slugs?.Select(m => m.MapSlugsToFrontend()).ToList()
            };
        }

        public static TamTech.ContentService.Services.Testimonials.Dtos.UpdateTestimonialModel MapToBackendUpdateDto(this TamTechSDK.Common.Services.ContentService.Testimonials.Models.UpdateTestimonialDto item)
        {
            return new TamTech.ContentService.Services.Testimonials.Dtos.UpdateTestimonialModel
            {
                DisplayOrder = item.DisplayOrder,
                Lang = item.Lang,
                MainImage = item.MainImage,
                AuthorName = item.AuthorName,
                Summary = item.Summary,
                Postion = item.Postion,
                Company = item.Company,
                Email = item.Email,
                Rate = item.Rating,
                Title = item.Title,
                Id = item.Id,
                Slug = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString() + "_" + item.Lang,
            };
        }
    }
}
