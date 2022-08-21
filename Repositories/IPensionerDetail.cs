using APIPension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Repositories
{
    public interface IPensionerDetail
    {
        public Pensioner GetPensionerDetails(string aadhaarNumber);
    }
}
