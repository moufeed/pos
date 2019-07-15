using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using SimpleMvcSitemap.Translations;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.Controllers
{
   
    public class SeoController : Controller
    {


        [Route("/sitemap.xml", Name = "sitemap")]
        public IActionResult Index()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
            {
            new SitemapNode(Url.Action("Index","Home")){
                LastModificationDate = DateTime.UtcNow,
                Priority = 1.0M
            },
            new SitemapNode(Url.Action("ContactUs","Home")){ Priority = 0.9M },
            new SitemapNode(Url.Action("PrivacyPolicy","Home")){ Priority = 0.9M },
            new SitemapNode(Url.Action("TermsofUse","Home")){ Priority = 0.9M },
            new SitemapNode(Url.Action("Index","Directory")){ Priority = 0.9M },
            new SitemapNode(Url.Action("Index","Vendor")){ Priority = 0.8M },
            };

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }



        [Route("/robots.txt", Name = "GetRobotsText")]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("User-agent: msnbot");
            stringBuilder.AppendLine("Crawl-delay: 120");
            stringBuilder.AppendLine("Disallow: /admin/");
            stringBuilder.AppendLine("Disallow: /lib/");
            stringBuilder.AppendLine("Disallow: /*.xml$");
            stringBuilder.AppendLine("/editor/");

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("User-agent: *");
            stringBuilder.AppendLine("Disallow: /admin/");
            stringBuilder.AppendLine("Disallow: /lib/");
            stringBuilder.AppendLine("Disallow: /*.xml$");
            stringBuilder.AppendLine("/editor/");
             
            stringBuilder.Append("sitemap: ");
            stringBuilder.AppendLine(this.Url.RouteUrl("sitemap", null, this.Request.Scheme).TrimEnd('/'));

            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }


    }
}

