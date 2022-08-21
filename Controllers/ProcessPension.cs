using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPension.Repositories;
using APIPension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace APIPension.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[Controller]")]
    public class ProcessPension : Controller
    {
        private readonly ICalculatePension _repository;
        private readonly PensionerContext _context;

        public ProcessPension(ICalculatePension repository, PensionerContext context)
        {
            _repository = repository;
            _context = context;
        }
        
        [Route("GetPension/{EnteredAadhaarNumber}")]
        [HttpPost]
        public IActionResult GetPension(string EnteredAadhaarNumber)
        {
            float pension = 0.0f;
            Tuple<float,Pensioner> res = _repository.CalculatePension(EnteredAadhaarNumber);
            pension = res.Item1;
            if (pension == 0.0f)
            {
                return NotFound(0.0);
            }
            Pensioner record = res.Item2;
            
            record.PensionAmount = pension;
            _context.Pensioner.Add(record);
            _context.SaveChanges();
            return Ok(record);
        }
    }
}
