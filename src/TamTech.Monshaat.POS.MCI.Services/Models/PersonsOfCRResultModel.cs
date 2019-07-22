using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.Services.Models
{
  public class PersonsOfCRResultModel   : BaseResultModel
    {
        [JsonProperty("Persons")]
        public List<PersonModel> Persons { get; set; }
    }
}
