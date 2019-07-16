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
            TestUsers = new List<ADUserModel>
            {
                new ADUserModel("admin" , "P@ssw0rd")    ,
                new ADUserModel("admin1", "P@ssw0rd")    ,
                new ADUserModel("admin2", "P@ssw0rd")    ,
                new ADUserModel("admin3", "P@ssw0rd")    ,
                new ADUserModel("admin4", "P@ssw0rd")    ,
                new ADUserModel("admin5", "P@ssw0rd")    ,  
            };
        }
    }


}
