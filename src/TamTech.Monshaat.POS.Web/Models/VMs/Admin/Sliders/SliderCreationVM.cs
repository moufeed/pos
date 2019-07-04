using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Admin.Sliders
{
    public class SliderCreationVM
    {
        [Required]
        public string Lang { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Key { get; set; }

        //   public string Position { get; set; }

        [Required]
        public string Summary { get; set; }

    }
}
