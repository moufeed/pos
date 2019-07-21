using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.MCI.APISimulator.Models;

namespace TamTech.Monshaat.POS.MCI.APISimulator.Data
{
    public class MockData
    {

        public readonly List<ADUserModel> TestUsers;

        public MockData()
        {
            TestUsers = GetTestUsers();
        }


        private List<ADUserModel> GetTestUsers()
        {
            return new List<ADUserModel>
            {
                new ADUserModel("test1" , "asdfasdf")    ,
                new ADUserModel("ad_admin" , "P@ssw0rd")    ,
                new ADUserModel("ad_admin1", "P@ssw0rd")    ,
                new ADUserModel("ad_admin2", "P@ssw0rd")    ,
                new ADUserModel("ad_admin3", "P@ssw0rd")    ,
                new ADUserModel("ad_admin4", "P@ssw0rd")    ,
                new ADUserModel("ad_admin5", "P@ssw0rd")    ,
            };
        }

        public List<PersonModel> GetPersons(string cr)
        {
            switch (cr)
            {
                case "1000000001":
                    return new List<PersonModel>
                     {
                        new PersonModel
                        {
                            Name = "مازن عدنان سعيد هجراني",
                            National_ID = "1099800391",
                        }, new PersonModel
                        {
                            Name = "سعد ماجد ياسر الرازي",
                            National_ID = "1099999999",
                        }
                    };
                case "1000000002":
                    return new List<PersonModel>
                     {
                        new PersonModel
                {      Name = "محمود باسم عامر الباشا",
                       National_ID = "1099999998",
                }, new PersonModel
                {      Name = "عبد الغفور مصطفى الحسن",
                       National_ID = "1099999997",
                }
                    };
                case "1000000003":
                    return new List<PersonModel>
                     {
                        new PersonModel
                {      Name = "فائز الزين العمار",
                       National_ID = "1099999996",
                }, new PersonModel
                {      Name = "يس العلي",
                       National_ID = "1099999995",
                }
                    };
                case "1000000004":
                    return new List<PersonModel>
                     {
                        new PersonModel
                {      Name = "مروان عماد",
                       National_ID = "1099999994",
                }, new PersonModel
                {      Name = "مازن لؤي",
                       National_ID = "1099999993",
                }
                    };
                default:
                    return null;

            }

        }
    }


}
