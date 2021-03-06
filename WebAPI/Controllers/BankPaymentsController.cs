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
    public class BankPaymentsController : ControllerBase
    {
        IBankPaymentService bankPayment;

        public BankPaymentsController(IBankPaymentService _bankPayment)
        {
            bankPayment = _bankPayment;
        }

        [HttpPost("add")]
        public IActionResult Add(BankPayment payment)
        {
            var result = bankPayment.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
