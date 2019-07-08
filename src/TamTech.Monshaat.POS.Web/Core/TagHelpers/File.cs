using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Core.TagHelpers
{
    [HtmlTargetElement("Import")]
    public class File : TagHelper
    {



        //[HtmlAttributeNotBound]
        #region private 
        private const string _baseDirectory = "/UploadFolder/avatars/";
            private const string _empty = "~/portal/img/empty.jpg";
            private readonly IHostingEnvironment _hostingEnvironment;
            private IUrlHelper _urlHelperFactory { get; set; }
         private IHtmlHelper _htmlHelper;
        #endregion



        #region ctor
        public File(IHostingEnvironment hostingEnvironment , IUrlHelper url , IHtmlHelper htmlHelper)
        {
            _hostingEnvironment = hostingEnvironment;
            _urlHelperFactory = url;
            _htmlHelper = htmlHelper;
        }
        #endregion

        #region attributes

        public string ControllerName { get; set; } = "Files";
        public string ActionName { get; set; } = "View";
        public string file { get; set; }

        #endregion

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            
            output.Content.SetHtmlContent("");
        }


        private void CreateImage()
        {

        }
    }
}
