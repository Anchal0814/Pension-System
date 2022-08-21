using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIPension.Models
{
    public class JwtService
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }
        private readonly IConfiguration config;
        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.SecretKey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);
        }

        public string GenerateToken(string PensionerName, DateTime DOB, string PAN, float SalaryEarned, int Allowances, string PensionType, string BankName, long AccountNumber, string BankType, float PensionAmount, string AadhaarNumber,int BankCharge)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("PensionerName",PensionerName),
                new Claim("DOB",DOB.ToString()),
                new Claim("PAN",PAN),
                new Claim("SalaryEarned",SalaryEarned.ToString()),
                new Claim("Allowances",Allowances.ToString()),
                new Claim("PensionType",PensionType),
                new Claim("BankName",BankName),
                new Claim("AccountNumber",AccountNumber.ToString()),
                new Claim("BankType",BankType),
                new Claim("PensionAmount",PensionAmount.ToString()),
                new Claim("AadhaarNumber",AadhaarNumber),
                new Claim("BankCharge",BankCharge.ToString())
            };

            var jwtToken = new JwtSecurityToken(
                    issuer : "localhost",
                    audience : "localhost",
                    claims : payload,
                    expires : DateTime.Now.AddMinutes(TokenDuration),
                    signingCredentials : signature
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
