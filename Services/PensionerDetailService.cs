using APIPension.Models;
using APIPension.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Services
{
    public class PensionerDetailService : IPensionerDetail
    {
        public Pensioner GetPensionerDetails(string aadhaarNumber)
        { 
            string path = @"C:\Users\2064598\source\repos\PensionManagementPortal\PensionerList.csv";
            PensionerCSVFileService p = new PensionerCSVFileService();
            var records = p.ConvertCSVToList(path);
            Pensioner item = records.Find(i => i.AadhaarNumber == aadhaarNumber);
            return item;
        }
    }
}
