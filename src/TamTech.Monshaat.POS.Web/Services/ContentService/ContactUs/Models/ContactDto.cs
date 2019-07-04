using System;
using System.Collections.Generic;
using System.Text;
 
namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models
{
    public  class ContactDto : ContactBaseModel
    {
        public Guid Id { get; set; }

        public int StatusId { get; set; }

        public string StatusOptions { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Replay { get; set; }

        public string StatusName { get; set; }
 
        public string TypeName { get; set; }

        public List<string> Attachments { get; set; }

            
    }   
}
