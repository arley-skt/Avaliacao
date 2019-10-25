using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperacaoContasController : ControllerBase
    {
        [HttpPost]
        public IActionResult EfetuarCredito([FromBody] string Cta) //async Task<IActionResult>
        {

            try
            {

                if (ModelState.IsValid)
                {
                    //var result = await _authenticationService.DoLogin(model, Ip);

                    if (1==1)
                    {
                        var x = 0;
                        //_logger.Info("Login - User Logged:" + result.messageReturning + "User Id:" + result.user.Id + "Ip:" + Ip);
                        return Ok(new { message = "vazi", token = "cra", x });
                    }
                    else
                    {
                        var erro = "100";
                        //_logger.Warn("Login - Not Authenticated: ", result.messageReturning);
                        return BadRequest(erro);
                    }

                }
                else
                {
                    //_logger.Warn("Login - ModelState: ", ModelState);
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                //_logger.Fatal("Login - Exception: " + ex.ToLogString(Environment.StackTrace));
                return BadRequest(ex.Message+" "+(Environment.StackTrace));
            }

        }
    

    [HttpGet]
    public IActionResult EfetuarCreditoG(string Cta) //async Task<IActionResult>
    {

        try
        {

            if (ModelState.IsValid)
            {
                //var result = await _authenticationService.DoLogin(model, Ip);

                if (1 == 1)
                {
                    var x = 0;
                    //_logger.Info("Login - User Logged:" + result.messageReturning + "User Id:" + result.user.Id + "Ip:" + Ip);
                    return Ok(new { message = "vazi", token = "cra", x });
                }
                else
                {
                    var erro = "100";
                    //_logger.Warn("Login - Not Authenticated: ", result.messageReturning);
                    return BadRequest(erro);
                }

            }
            else
            {
                //_logger.Warn("Login - ModelState: ", ModelState);
                return BadRequest(ModelState);
            }

        }
        catch (Exception ex)
        {
            //_logger.Fatal("Login - Exception: " + ex.ToLogString(Environment.StackTrace));
            return BadRequest(ex.Message + " " + (Environment.StackTrace));
        }

    }
}
}