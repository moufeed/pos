using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using SimpleMvcSitemap.Translations;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.Controllers
{
    public class SeoController : Controller
    {
        private readonly IDirectoryServices _directoryServices;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IPageService _pageService;

        public SeoController(IDirectoryServices directoryServices, IHostingEnvironment hostingEnvironment , IPageService pageService)
        {
            _directoryServices = directoryServices;
            _hostingEnvironment = hostingEnvironment;
            _pageService = pageService;
        }


        #region utilities
            private void CreateRobotsRoles(StringBuilder stringBuilder)
            {
                 
                stringBuilder.AppendLine("User-agent: msnbot");
                stringBuilder.AppendLine("Crawl-delay: 120");
                stringBuilder.AppendLine("Disallow: /admin/");
                stringBuilder.AppendLine("Disallow: /lib/");
                stringBuilder.AppendLine("Disallow: /*.xml$");
                stringBuilder.AppendLine("Disallow: /editor/");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("User-agent: *");
                stringBuilder.AppendLine("Disallow: /admin/");
                stringBuilder.AppendLine("Disallow: /lib/");
                stringBuilder.AppendLine("Disallow: /*.xml$");
                stringBuilder.AppendLine("Disallow: /editor/");
                
            }

        private void AddToNodes(List<SitemapNode> nodes, List<SlugModel> items, string action, string controller)
        {
            foreach (SlugModel item in items)
            {
                nodes.Add(
                        new SitemapNode(Url.Action(action, controller, new { slug = item.Slug }))
                        {
                            LastModificationDate = item.ModifiedDate,
                            Priority = 0.8M
                        }
                    );
            }
        }
         
        #endregion


        [Route("/sitemap.xml", Name = "sitemap")]
        public async Task<IActionResult> Index()
        {

            var _PosSlugs = await _directoryServices.GetAllPublishedSlugsAsync();
            var _PagesSlugs = await _pageService.GetAllPublishedSlugsAsync();
            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index","Home")){
                     Priority = 1.0M
                },
                new SitemapNode(Url.Action("ContactUs","Home")){ Priority = 0.9M },
                new SitemapNode(Url.Action("PrivacyPolicy","Home")){ Priority = 0.9M },
                new SitemapNode(Url.Action("TermsofUse","Home")){ Priority = 0.9M },
                new SitemapNode(Url.Action("Index","Directory")){ Priority = 0.9M },
                new SitemapNode(Url.Action("Index","Vendor")){ Priority = 0.8M },
            };

          
            if (_PagesSlugs.Success)
            {
                AddToNodes(nodes, _PagesSlugs.Data, "v", "pages");
            }
            if (_PosSlugs.Success)
            {
                AddToNodes(nodes, _PosSlugs.Data, "Pos", "Directory");
            }


            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }



        [Route("/robots.txt", Name = "GetRobotsText")]
        public ContentResult RobotsText()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            StringBuilder stringBuilder = new StringBuilder();
            string file = $"{webRootPath}/_RobotsFile.txt";
            if (System.IO.File.Exists(file))
            {
                var fileStream = System.IO.File.ReadAllText(file);
                stringBuilder.Append(fileStream);
            }
            else
            {
                CreateRobotsRoles(stringBuilder);
            }
            stringBuilder.Append("");
            stringBuilder.Append("sitemap: ");
            stringBuilder.AppendLine(this.Url.RouteUrl("sitemap", null, this.Request.Scheme).TrimEnd('/'));

            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }


    }
}

