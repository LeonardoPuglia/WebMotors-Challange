using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMotors.Framework.Exceptions;

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
                return BadRequest(ex.Message);//TO DO
            }
        }

        //protected virtual Task<IActionResult> ApiResult<T>(Func<Task<T>> fn)
        //{
        //    try
        //    {
        //        var result =  fn();

        //        return Ok(result);
        //    }
        //    catch (BadRequestException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }

        //    catch (InternalServerErrorException ex)
        //    {
        //        return BadRequest(ex.Message);//TO DO
        //    }
        //}


    }
}
