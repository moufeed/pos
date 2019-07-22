using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.APISimulator.Models
{
   public class GetAllPersonsForCRModel
    {
        [Required]
        [JsonProperty("cr")]
        public string CR { get; set; }
    }
}
