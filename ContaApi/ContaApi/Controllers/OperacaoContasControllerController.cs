using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contas.Business.Dto;
using Contas.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContaApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperacaoContasController : ControllerBase
    {
        private readonly ILancamentoService lancamentoService;
        private readonly IMensagemService mensagemService;
        public OperacaoContasController(ILancamentoService lancamentoService, IMensagemService mensagemService)
        {
            this.lancamentoService = lancamentoService;
            this.mensagemService = mensagemService;
        }

        [HttpPost]
        public IActionResult EfetuarCredito([FromBody] List<LancamentoDto> lista) 
        {

            try
            {

                if (ModelState.IsValid)
                {
                    

                    if (lista.Any())
                    {
                        var Msg = JsonConvert.SerializeObject(lista);
                        
                        mensagemService.Enviar(Msg);
                        
                        return Ok(new { message = "Lista Criada" });
                    }
                    else
                    {
                        var erro = "Json Vazio";
                       
                        return BadRequest(erro);
                    }

                }
                else
                {
                    
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message+" "+(Environment.StackTrace));
            }

        }
    

    [HttpGet]
    public IActionResult EfetuarCreditoG(string Cta) 
    {

        try
        {

            if (ModelState.IsValid)
            {
          

                if (1 == 1)
                {
                    var x = 0;
                    
                    return Ok(new { message = "vazi", token = "cra", x });
                }
                else
                {
                    var erro = "100";
                    
                    return BadRequest(erro);
                }

            }
            else
            {
                
                return BadRequest(ModelState);
            }

        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message + " " + (Environment.StackTrace));
        }

    }
}
}