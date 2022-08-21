using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPension.Models;

namespace APIPension.Repositories
{
    public interface ICalculatePension
    {
        public Tuple<float,Pensioner> CalculatePension(string EnteredAadhaarNumber);
    }
}
