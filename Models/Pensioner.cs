using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Models
{
    [Table("Pensioner")]
    public class Pensioner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PensionerId { get; set; }
        public string PensionerName { get; set; }
        public DateTime DOB { get; set; }
        public string PAN { get; set; }
        public float SalaryEarned { get; set; }
        public int Allowances { get; set; }
        public string PensionType { get; set; }
        public string BankName { get; set; }
        public long AccountNumber { get; set; }
        public string BankType { get; set; }
        public float PensionAmount { get; set; }
        public string AadhaarNumber { get; set; }
        public int BankCharge { get; set; }

    }
}
