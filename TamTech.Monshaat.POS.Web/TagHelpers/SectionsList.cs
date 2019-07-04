using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Sections.Models;
using TamTechSDK.Web.Extensions;
using TamTechSDK.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.TagHelpers
{
    //[HtmlTargetElement("SectionsList")]
    public class SectionsList : TagHelper
    {
        #region Attributes
        public List<SectionDto> Sections { get; set; }
        public string ActionName { get; set; }
        public Guid? RootId { get; set; }
        public string ControllerName { get; set; }
        #endregion

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        private IUrlHelperFactory _urlHelperFactory { get; set; }

        public SectionsList(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        string PrintUL(List<TreeItem<SectionDto>> sections, bool submenu = false)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            //TagBuilder
            StringBuilder stringBuilder = new StringBuilder($"<ul class=\"list-unstyled {((submenu) ? "submenu" : "")}\">");

            foreach (TreeItem<SectionDto> section in sections)
            {
                var link = urlHelper.Action(ActionName, ControllerName, new { slug = section.Item.SlugHierarchy }).Replace("%2F", "/");
                if (section.Children.Count() > 0)
                {
                    stringBuilder.Append("<li>");
                    var sublavel = PrintUL(section.Children.ToList(), true);
                    stringBuilder.Append($"<a  href=\"{ link }\" class=\"\">{section.Item.Title} </a>");
                    stringBuilder.Append(sublavel);
                    stringBuilder.Append("</li>");
                }
                else
                {
                    stringBuilder.Append("<li class=\"\">");
                    stringBuilder.Append($"<a href=\"{link}\" class=\"\">{section.Item.Title}</a>");
                    stringBuilder.Append("</li>");
                }
            }

            stringBuilder.Append("</ul>");
            return stringBuilder.ToString();
        }



        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var sectionsList = Sections.GenerateTree(c => c.Id, c => c.ParentId, RootId).ToList();

            output.Content.SetHtmlContent(PrintUL(sectionsList));
        }
    }
}
