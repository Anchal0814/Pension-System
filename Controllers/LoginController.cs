using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPension.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using System.Web.Http;
using System.Web;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using APIPension.Repositories;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPension.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILogin _repository;
        private readonly IConfiguration _config;
        public LoginController(ILogin repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [AllowAnonymous]
        [Route("UserLogin")]
        [HttpPost]
        
        public IActionResult UserLogin(Login login)
        {
            var log = _repository.PortalLogin(login);
            if (log != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    log.PensionerName,
                log.DOB,
                log.PAN,
                log.SalaryEarned,
                log.Allowances,
                log.PensionType,
                log.BankName,
                log.AccountNumber,
                log.BankType,
                log.PensionAmount,
                log.AadhaarNumber,
                log.BankCharge)
                    );
            }
            return NotFound("Failure");
        }

    }
}
