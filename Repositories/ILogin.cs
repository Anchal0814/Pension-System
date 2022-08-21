using APIPension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Repositories
{
    public interface ILogin
    {
        public Pensioner PortalLogin(Login login);
    }
}
