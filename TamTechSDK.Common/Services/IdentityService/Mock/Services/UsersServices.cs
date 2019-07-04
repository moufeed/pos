using AdminPanelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace AdminPanelWeb.Services
{
    public class _UsersServices : _IUsersServices
    {
        
                
        private List<_User> _getUsers(){
            Random random = new Random();
            return new List<_User>
            {
                new _User
                {
                    Id = random.Next().ToString(),
                    Username ="Herrod",
                    Name = "Nazmi Sakhr Abboud",
                    Email = "Herrod@hotmail.com",
                    ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                    Phone ="858-243-4866",
                    Status= true,
                    Confirmed =true
                },
                new _User
                {
                    Id = random.Next().ToString(),
                    Username ="Jose",
                    Name="Taslim Rayhan Nahas",
                    Email = "Jose@hotmail.com",
                    ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                    Phone ="0096635878",
                    Status= true,
                    Confirmed =false
                },
                new _User
                {
                    Id = random.Next().ToString(),
                    Username ="Watson",
                    Name="",
                    Email = "Watson@hotmail.com",
                    ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                    Phone ="718-304-8438",
                    Status= false,
                    Confirmed =true
                },
                new _User
                {
                    Id = random.Next().ToString(),
                    Username ="Mu'mmar",
                    Name="Mandhur Al Bara' Quraishi",
                    Email = "mmar@hotmail.com",
                    ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                    Phone ="201-387-6951",
                    Status= false,
                    Confirmed =true
                },
                new _User
                {
                    Id = random.Next().ToString(),
                    Username ="Mahir",
                    Name="Yusuf Reda Harb",
                    Email = "Mahir@hotmail.com",
                    ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                    Phone ="216-312-4239",
                    Status= true,
                    Confirmed =false
                },
            };
        } 

        

        public _User GetUserById(string id)
        {
            return new _User
            {
                Id = "15",
                Username = "Mahir",
                Name="Qutaiba Munsif Sayegh",
                Email = "Mahir@hotmail.com",
                ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                Phone = "216-312-4239",
                Status = true,
                Confirmed = false,
                Role = "admin"
            };
        }

        public _User GetUserByUserName(string username)
        {
             
            return new _User
            {
                Id = "20",
                Username = "Mahir",
                Name="Qutaiba Munsif Sayegh",
                Email = "Mahir@hotmail.com",
                ImageUrl = $"https://www.w3schools.com/howto/img_avatar.png",
                Phone = "216-312-4239",
                Status = false,
                Confirmed = false,
                Role = "admin"
            };
        }

        public List<_User> GetUsers()
        {
            return _getUsers();
        }
    }


     
   
}
