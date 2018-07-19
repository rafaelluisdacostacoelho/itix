using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Itix.Consultorio.WebApi.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            this.pacienteService = pacienteService;
        }

        // GET api/pacientes
        [HttpGet]
        public IActionResult Read()
        {
            IEnumerable<PacienteResponse> pacientes = pacienteService.Read();

            return Ok(pacientes);
        }

        // GET api/pacientes/{id}
        [HttpGet("{id}")]
        public ActionResult<string> Read(Guid id)
        {
            PacienteResponse paciente = pacienteService.Read(id);

            return Ok();
        }

        // POST api/pacientes
        [HttpPost]
        public IActionResult Create([FromBody]PacienteRequest request)
        {
            Guid id = pacienteService.Create(request);

            return Ok(id);
        }

        // PUT api/pacientes/{id}
        [HttpPut("{id}")]
        public void Update(Guid id, [FromBody]PacienteRequest request)
        {
            pacienteService.Update(id, request);
        }

        // DELETE api/pacientes/{id}
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            pacienteService.Delete(id);
        }
    }
}
