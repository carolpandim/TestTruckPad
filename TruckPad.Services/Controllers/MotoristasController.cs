using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TruckPad.Services.Models;
using TruckPad.Services.Repository;

namespace TruckPad.Services.Controllers
{
    [Route("api/Motoristas")]
    [ApiController]
    public class MotoristasController : ControllerBase
    {
        private readonly IMotoristaRepository motoristaRepository;
        public MotoristasController(IMotoristaRepository _motoristaRepository)
        {
            motoristaRepository = _motoristaRepository;
        }

        // GET: api/Motoristas/GetMotoristas
        [HttpGet]
        [Route("GetMotoristas")]
        public async Task<IActionResult> GetMotoristas()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristas();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // GET: api/Motoristas/GetMotorista/1
        [HttpGet]
        [Route("GetMotorista")]
        public async Task<IActionResult> GetMotorista(int? idMotorista)
        {
            if (idMotorista == null)
            {
                return BadRequest();
            }

            try
            {
                var motorista = await motoristaRepository.GetMotorista(idMotorista);

                if (motorista == null)
                {
                    return NotFound();
                }

                return Ok(motorista);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Motoristas/UpdateMotorista
        [HttpPut]
        [Route("UpdateMotorista")]
        public async Task<IActionResult> PutMotorista([FromBody]Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await motoristaRepository.PutMotorista(motorista);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // POST: api/Motoristas/AddMotorista
        [HttpPost]
        [Route("AddMotorista")]
        public async Task<ActionResult<Motorista>> PostMotorista([FromBody] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idMotorista = await motoristaRepository.PostMotorista(motorista);

                    if (idMotorista > 0)
                    {
                        //return Ok(idMotorista);
                        return CreatedAtAction(nameof(GetMotorista), new { id = motorista.IdMotorista }, motorista);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE: api/Motoristas/DeleteMotorista/1
        [HttpDelete]
        [Route("DeleteMotorista")]
        public async Task<IActionResult> DeleteMotorista(int? idMotorista)
        {
            int result = 0;

            if (idMotorista == null)
            {
                return BadRequest();
            }

            try
            {
                result = await motoristaRepository.DeleteMotorista(idMotorista);

                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
                                    
        // GET: api/Motoristas/GetMotoristaSemCargaDestinoOrigem
        [HttpGet]
        [Route("GetMotoristaSemCargaDestinoOrigem")]
        public async Task<IActionResult> GetMotoristaSemCargaDestinoOrigem()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristaSemCargaDestinoOrigem();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }           
        }

        // GET: api/Motoristas/GetMotoristaOrigemDestino
        [HttpGet]
        [Route("GetMotoristaOrigemDestino")]
        public async Task<IActionResult> GetMotoristaOrigemDestino()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristaOrigemDestino();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Motoristas/GetMotoristaParada
        [HttpGet]
        [Route("GetMotoristaParada")]
        public async Task<IActionResult> GetMotoristaParada()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristaParada();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Motoristas/GetMotoristaParadaCarregadoPorPeriodo
        [HttpGet]
        [Route("GetMotoristaParadaCarregadoPorPeriodo")]
        public async Task<IActionResult> GetMotoristaParadaCarregadoPorPeriodo()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristaParadaCarregadoPorPeriodo();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Motoristas/GetMotoristaTipoVeiculoOrigemDestino
        [HttpGet]
        [Route("GetMotoristaTipoVeiculoOrigemDestino")]
        public async Task<IActionResult> GetMotoristaTipoVeiculoOrigemDestino()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristaTipoVeiculoOrigemDestino();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Motoristas/GetMotoristaVeiculoProprio
        [HttpGet]
        [Route("GetMotoristaVeiculoProprio")]
        public async Task<IActionResult> GetMotoristaVeiculoProprio()
        {
            try
            {
                var motoristas = await motoristaRepository.GetMotoristaVeiculoProprio();

                if (motoristas == null)
                {
                    return NotFound();
                }

                return Ok(motoristas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}