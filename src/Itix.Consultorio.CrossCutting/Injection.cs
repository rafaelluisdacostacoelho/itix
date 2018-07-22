using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Services;
using Itix.Consultorio.Domain.Interfaces;
using Itix.Consultorio.Domain.InterfacesPaciente;
using Itix.Consultorio.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itix.Consultorio.CrossCutting
{
    public class Injection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IConsultaService, ConsultaService>();

            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
        }
    }
}
