using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using APIPension.Mapper;
using APIPension.Models;
using APIPension.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPension.Services
{
    public class PensionerCSVFileService : IPensionerCsvToList
    {
        public List<Pensioner> ConvertCSVToList(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<PensionerMap>();
                    var records = csv.GetRecords<Pensioner>().ToList();
                    return records;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}