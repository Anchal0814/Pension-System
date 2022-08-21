using APIPension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPension.Repositories;
using System.IO;
using System.Text;
using CsvHelper;
using APIPension.Mapper;
using APIPension.Services;

namespace APIPension.Services
{
    public class CalculatePensionService : ICalculatePension
    {
        public Tuple<float,Pensioner> CalculatePension(string EnteredAadhaarNumber)
        {
            List<Pensioner> record=null;
            float pension=0.0f;
            string path = @"C:\Users\2064598\source\repos\PensionManagementPortal\PensionerList.csv"; ;
            PensionerCSVFileService p = new PensionerCSVFileService();
            record = p.ConvertCSVToList(path);
            Pensioner item = record.Find(c => c.AadhaarNumber == EnteredAadhaarNumber);
            if (item != null)
            {
                if (item.BankType == "Public" && item.SalaryEarned > 500)
                {
                    pension = ((80 * item.SalaryEarned)/100) + item.Allowances - 500;

                }
                else if (item.BankType == "Private" && item.SalaryEarned > 550)
                {
                    pension = ((50 * item.SalaryEarned)/100) + item.Allowances - 550;
                }
                else
                {
                    pension = 0.0f;
                }
                return new Tuple<float,Pensioner>(pension,item);
            }
            return new Tuple<float, Pensioner>(pension,null);
        }
    }
}
