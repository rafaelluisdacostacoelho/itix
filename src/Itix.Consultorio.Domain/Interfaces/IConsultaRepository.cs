using Itix.Consultorio.Domain.Entities;
using System.Collections.Generic;

namespace Itix.Consultorio.Domain.InterfacesPaciente
{
    public interface IConsultaRepository
    {
        void Create(Consulta consulta);

        IEnumerable<Consulta> Read();

        Consulta Read(int id);

        void Update(Consulta consulta);

        void Delete(int id);
    }
}
