using Itix.Consultorio.Domain.InterfacesPaciente;
using System;

namespace Itix.Consultorio.Domain.Entities
{
    public class Consulta
    {
        private DateTime _dataInicial { get; set; }
        private DateTime _dataFinal { get; set; }

        private readonly IConsultaRepository consultaRepository;

        public Consulta() { }
        public Consulta(IConsultaRepository consultaRepository)
        {
            this.consultaRepository = consultaRepository;
        }

        public int Id { get; set; }
        public string Observacoes { get; set; }

        public int PacienteId { get; set; }

        public DateTime DataInicial
        {
            get { return _dataInicial; }
            set
            {
                if (DataFinal != DateTime.MinValue && DataFinal <= value)
                {
                    throw new Exception("A data inicial não pode ser maior ou igual à data final.");
                }

                if (consultaRepository != null && value != DateTime.MinValue && !consultaRepository.DataDaConsultaEstaDisponivel(Id, value))
                {
                    throw new Exception("A data inicial está conflitando com outro horário de consulta.");
                }

                _dataInicial = value;
            }
        }

        public DateTime DataFinal
        {
            get { return _dataFinal; }
            set
            {
                if (DataInicial != DateTime.MinValue && value <= DataInicial)
                {
                    throw new Exception("A data final não pode ser menor ou igual à data inicial.");
                }

                if (consultaRepository != null && value != DateTime.MinValue && !consultaRepository.DataDaConsultaEstaDisponivel(Id, value))
                {
                    throw new Exception("A data final está conflitando com outro horário de consulta.");
                }

                _dataFinal = value;
            }
        }
    }
}
