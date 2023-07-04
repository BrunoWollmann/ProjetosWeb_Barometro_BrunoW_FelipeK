using Barometro.API.Models;
using Barometro.Aplicacao.Aplicacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barometro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarometroController : ControllerBase
    {
        // GET: api/<BarometroController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<BarometroModel> BarometrosModel = new List<BarometroModel>();
                BarometroAplicacao BarometroAplicacao = new BarometroAplicacao();

                var Barometros = BarometroAplicacao.SelecionarTodos();

                foreach (var prod in Barometros)
                {
                    BarometrosModel.Add(new BarometroModel()
                    {
                        TEMPId = prod.TEMPId,
                        PRESSURE = prod.PRESSURE,
                        Id = prod.Id,
                        HUMIDITY = prod.HUMIDITY,
                        ALTITUDE = prod.ALTITUDE,
                        DATE = prod.DATE
                    });
                }

                return Ok(Barometros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<BarometroController>/id
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<BarometroController>
        [HttpPost]
        public IActionResult Post([FromBody] BarometroModel cliente)
        {
            try
            {
                //Codigo de inserção aqui!!!
                //Deve retornar o código gerado por aqui
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BarometroController>/5
        [HttpPut]
        public IActionResult Put([FromBody] BarometroModel Barometro)
        {
            try
            {
                //Código de Alteração aqui!!!
                //Deve retornar o Guid do registro alterado
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BarometroController>/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Código de Exclusão aqui
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
