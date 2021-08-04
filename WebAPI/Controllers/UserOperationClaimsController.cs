using Business.Abstract;
using Core.Entities.Concrete;
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
    public class UserOperationClaimsController : ControllerBase
    {
        IUserOperationClaimService claim;

        public UserOperationClaimsController(IUserOperationClaimService _claim)
        {
            claim = _claim;
        }
        [HttpPost("add")]
        public ActionResult Add(UserOperationClaim claiming)
        {
            var result = claim.Add(claiming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
