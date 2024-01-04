using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.WebApi.Models
{
    public class RoleModel
    {
        public RoleModel(string role, string userName)
        {
            Role = role;
            UserName = userName;
        }

        public string Role { get; set; }
        public string UserName { get; set; }
    }
}