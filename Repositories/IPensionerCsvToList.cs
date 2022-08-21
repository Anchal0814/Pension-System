using APIPension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Repositories
{
    public interface IPensionerCsvToList
    {
        public List<Pensioner> ConvertCSVToList(string location);
    }
}
