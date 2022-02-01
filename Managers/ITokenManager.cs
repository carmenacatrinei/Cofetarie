using Cofetarie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}
