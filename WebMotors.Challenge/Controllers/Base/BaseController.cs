using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMotors.Framework.Exceptions;
using WebMotors.Framework.Models;

namespace WebMotors.Challenge.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BaseController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        protected virtual async Task<IActionResult> ApiResultAsync<T>(Func<Task<T>> fn)
        {
            try
            {
                var result  = await fn();

                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (InternalServerErrorException ex)
            {
                return new JsonResult(new ErrorModel($"Houve um erro ao tentar acionar a API : {ex.Message}"));
            }
        }



    }
}
