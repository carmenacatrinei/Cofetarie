using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class User : IdentityUser 
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
