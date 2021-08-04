using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFindexesController : ControllerBase
    {
        ICustomerFindexService findexService;

        public CustomerFindexesController(ICustomerFindexService _findexService)
        {
            findexService = _findexService;
        }

        [HttpGet("getFindex")]
        public ActionResult GetFindex(int customerId)
        {
            var result = findexService.GetFindexByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerFindex findex)
        {
            var result = findexService.Add(findex);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
