using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.APISimulator.Models
{
    public class PersonModel
    {    
            public object BirthDate { get; set; }
            public int CardNo { get; set; }
            public object Entered_CR { get; set; }
            public string ID_Type { get; set; }
            public object Location { get; set; }
            public object LocationID { get; set; }
            public string Name { get; set; }
            public string National_ID { get; set; }
            public object National_ID_CreatedDate { get; set; }
            public string Nationality { get; set; }
            public string NationalityEN { get; set; }
            public object NationalityID { get; set; }
            public string Nationality_ISO3 { get; set; }
            public string PartyAddress { get; set; }
            public string PartyBirthLocation { get; set; }
            public string PartyGross { get; set; }
            public object PartyPercint { get; set; }
            public string PartyShareCount { get; set; }
            public string RelationType { get; set; }
            public string RelationTypeEN { get; set; }
            public string RelationTypeID { get; set; }
            public object mainCR { get; set; }
            public object Mobile { get; set; }     
    }
}
