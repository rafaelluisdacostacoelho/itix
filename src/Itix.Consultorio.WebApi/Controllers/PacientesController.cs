using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Itix.Consultorio.WebApi.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService pacienteService;

        public PacientesController(IPacienteService pacienteService)
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
        public IActionResult Read(int id)
        {
            PacienteResponse paciente = pacienteService.Read(id);

            return Ok(paciente);
        }

        // POST api/pacientes
        [HttpPost]
        public void Create([FromBody]PacienteRequest request)
        {
            pacienteService.Create(request);
        }

        // PUT api/pacientes/{id}
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]PacienteRequest request)
        {
            pacienteService.Update(id, request);
        }

        // DELETE api/pacientes/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pacienteService.Delete(id);
        }
    }
}
