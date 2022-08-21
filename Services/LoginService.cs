using APIPension.Models;
using APIPension.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Services
{
    public class LoginService : ILogin
    {
        private readonly PensionerContext _context;
        public LoginService(PensionerContext context)
        {
            _context = context;
        }
        public Pensioner PortalLogin(Login login)
        {
            var log = _context.Login.Where(x => x.AadhaarNumber == login.AadhaarNumber && x.Password == login.Password).FirstOrDefault();
            if (log != null)
            {
                string path = @"C:\Users\2064598\source\repos\PensionManagementPortal\PensionerList.csv";
                PensionerCSVFileService obj = new PensionerCSVFileService();
                var record = obj.ConvertCSVToList(path);
                var item= record.Find(i => i.AadhaarNumber == login.AadhaarNumber);
                return item;
            }
            return null;
        }
    }
}
