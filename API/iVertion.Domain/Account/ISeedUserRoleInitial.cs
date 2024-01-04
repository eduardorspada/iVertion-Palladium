using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedUsers();
        void SeedRoles();
    }
}