using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCIServices.Models
{
  public class PersonsOfCRResultModel   : BaseResultModel
    {
        [JsonProperty("status")]
        public List<PersonModel> Persons { get; set; }
    }
}
