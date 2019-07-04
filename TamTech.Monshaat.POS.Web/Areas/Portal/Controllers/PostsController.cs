using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.ContentService.Sections.Models;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Models.Shared;
using System.Linq;
using TamTechSDK.Web.Extensions;
using TamTechSDK.Common.Models.Pagination;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class PostsController : PublicBaseController
    {

        #region props
        private IPostsService _postservice;
        private ISectionsService _SectionsService;
        #endregion

        #region constructor
        public PostsController(ITelemetryClientService telemetryClientService,
                                    IPostsService postservice,
                                    ISectionsService SectionsService)
                                : base(telemetryClientService)
        {

            _postservice = postservice;
            _SectionsService = SectionsService;

        }
        #endregion






        [HttpGet]
        public virtual async Task<IActionResult> Index(PaginationModel Pagination)
        {
            try
            {
                var sections = await _SectionsService.GetPublicListAsync();

                //var data = await _postservice.GetPublicLatestPostsAsync(Pagination);
                var data = await _postservice.GetPublicListAsync(Pagination);



                SectionContainerDto model = new SectionContainerDto
                {
                    Sections = (sections.Success) ? sections.Data : new List<SectionDto>(),
                    Posts = data.Data != null ? data.Data : new List<PostDto>(),
                    Pagination = data.Pagination,
                    SectionsSlugs = data.SectionsSlugs
                };
                return View(model);


            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(new SectionContainerDto
            {
                Sections = new List<SectionDto>(),
                Posts = new List<PostDto>(),
                Pagination = new PaginationMetadataModel()
            });
        }

        [ActionName("s")]
        public virtual async Task<IActionResult> Section(PaginationModel Pagination, string slug)
        {
            try
            {

                ViewBag.slug = slug;
                var sectionContainer = await _SectionsService.GetPublicSectionWithLatestSubSectionsBySlugAsync(slug);

                if (sectionContainer == null || sectionContainer.SectionInfo == null)
                {
                    return NotFound();
                }

                // When there is no sectionInfo there can be no posts
                PostsList pagedPosts = sectionContainer?.SectionInfo != null ? await _postservice.GetPublicListBySectionSlugAsync(Pagination, slug) : new PostsList();

                SectionContainerDto model = new SectionContainerDto
                {
                    Sections = sectionContainer.Sections,
                    SectionInfo = sectionContainer.SectionInfo,
                    Posts = pagedPosts.Data,
                    Pagination = pagedPosts.Pagination,
                    SectionsSlugs = pagedPosts.SectionsSlugs
                };

                return View("Section", model);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return StatusCode(500);

        }

        [ActionName("p")]
        public virtual async Task<IActionResult> Post(string slug)
        {
            try
            {

                var Sections = await _SectionsService.GetPublicListAsync();
                if (Sections.Success)
                {
                    ViewBag.Sections = Sections.Data;
                }
                string _slug = slug.Trim('/');
                string[] arrSlugs = _slug.Split('/');
                List<string> _slugs = arrSlugs.ToList();
                _slug = _slugs[_slugs.Count - 1];
                _slugs.Remove(_slug);

                var result = await _postservice.GetPublicBySlugAndSectionSlugsAsync(_slugs, _slug);

                return View("Post", result);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return NotFound();
        }
    }
}
