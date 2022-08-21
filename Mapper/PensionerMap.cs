using CsvHelper.Configuration;
using APIPension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Mapper
{
    public sealed class PensionerMap : ClassMap<Pensioner>
    {
       public PensionerMap()
       {
            Map(x => x.AadhaarNumber).Name("AadhaarNumber");
            Map(x => x.PensionerName).Name("PensionerName");
            Map(x => x.DOB).Name("DOB");
            Map(x => x.PAN).Name("PAN");
            Map(x => x.SalaryEarned).Name("SalaryEarned");
            Map(x => x.Allowances).Name("Allowances");
            Map(x => x.PensionType).Name("PensionType");
            Map(x => x.BankName).Name("BankName");
            Map(x => x.AccountNumber).Name("AccountNumber");
            Map(x => x.BankType).Name("BankType");
            Map(x => x.BankCharge).Name("BankCharge");
        }
    }
}
