using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Itix.Consultorio.WebApi.Controllers
{
    [Route("api/consultas")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService consultaService;

        public ConsultaController(IConsultaService consultaService)
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
        public ActionResult<string> Read(int id)
        {
            ConsultaResponse consulta = consultaService.Read(id);

            return Ok();
        }

        // POST api/consultas
        [HttpPost]
        public IActionResult Create([FromBody]ConsultaRequest request)
        {
            int id = consultaService.Create(request);

            return Ok(id);
        }

        // PUT api/consultas/{id}
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]ConsultaRequest request)
        {
            consultaService.Update(id, request);
        }

        // DELETE api/consultas/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            consultaService.Delete(id);
        }
    }
}
