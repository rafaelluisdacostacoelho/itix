using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Itix.Consultorio.WebApi.Controllers
{
    [Route("api/consultas")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService consultaService;

        public ConsultasController(IConsultaService consultaService)
        {
            this.consultaService = consultaService;
        }

        // GET api/consultas
        [HttpGet]
        public IActionResult Read()
        {
            IEnumerable<ConsultaResponse> consultas = consultaService.Read();

            return Ok(consultas);
        }

        // GET api/consultas/{id}
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            ConsultaResponse consulta = consultaService.Read(id);

            return Ok(consulta);
        }

        // POST api/consultas
        [HttpPost]
        public IActionResult Create([FromBody]ConsultaRequest request)
        {
            try
            {
                consultaService.Create(request);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // PUT api/consultas/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ConsultaRequest request)
        {
            try
            {
                consultaService.Update(id, request);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // DELETE api/consultas/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            consultaService.Delete(id);

            return Ok();
        }
    }
}
