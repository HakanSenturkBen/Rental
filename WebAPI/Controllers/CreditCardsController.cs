using Business.Abstract;
using Business.ValidationRules;
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
    public class CreditCardsController : ControllerBase
    {
        ICreditCardService cardService;

        public CreditCardsController(ICreditCardService _cardService)
        {
            cardService = _cardService;
        }

        [HttpGet("getcardinfo")]
        public IActionResult GetCardInfo(string card)
        {
            var result = cardService.GetCardByNumber(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
