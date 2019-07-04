using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class PublishDTO
    {

        public Guid Id { get; set; }

        public string Lang { get; set; }

        public int IntId { get; set; }
    }

    public class ActiveModel : PublishDTO
    {

    }

    public class BasePublishModel
    {
         
        public Guid Id { get; set; }

         
        public string Lang { get; set; }
    }

}
