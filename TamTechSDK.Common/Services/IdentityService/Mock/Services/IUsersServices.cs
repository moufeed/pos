using AdminPanelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelWeb.Services
{
   public interface _IUsersServices
    {
        List<_User> GetUsers();
        _User GetUserById(string id);
        _User GetUserByUserName(string username);
    }
}
