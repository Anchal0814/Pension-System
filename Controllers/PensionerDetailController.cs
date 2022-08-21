using APIPension.Models;
using APIPension.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPension.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailController : ControllerBase
    {
        private readonly IPensionerDetail _repository;
        private readonly IPensionerCsvToList _repo;
        public PensionerDetailController(IPensionerDetail repository, IPensionerCsvToList repo)
        {
            _repository = repository;
            _repo = repo;
        }
        [Route("GetDetails/{AadhaarNumber}")]
        [HttpPost]
        public IActionResult GetDetails(string aadhaarNumber)
        {
            var result = _repository.GetPensionerDetails(aadhaarNumber);
            if (result == null)
            {
                return NotFound("Failure");
            }
            return Ok(result);
        }
        [Route("GetDetail")]
        [HttpGet]
        public IActionResult GetDetail()
        {
            string path = @"C:\Users\2064598\source\repos\PensionManagementPortal\PensionerList.csv";
            var result = _repo.ConvertCSVToList(path);
            if (result == null)
            {
                return NotFound("Failure");
            }
            return Ok(result);
        }

    }
}
