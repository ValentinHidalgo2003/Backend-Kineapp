using Backend_Kineapp.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Kineapp.Dtos
{
    public class DtoDetalleTurno
    {
        public DateTime? Fecha { get; set; }

        public TimeSpan? HoraInicio { get; set; }

        public TimeSpan? HoraFin { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Precio { get; set; }

        public int? CantidadSesiones { get; set; }

        public int? IdKinesiologo { get; set; }
        public virtual DtoKinesiologo? Kinesiologo { get; set; }

        public int? IdTratamiento { get; set; }
        public virtual DtoTratamiento? Tratamiento { get; set; }

        public int? IdMedioPago { get; set; }
        public virtual DtoMedioPago? MedioPago { get; set; }

        public int? IdObraSocial { get; set; }
        public virtual DtoObraSocial? ObraSocial { get; set; }

        public int? IdPaciente { get; set; }
        public virtual DtoPaciente? Paciente { get; set; }
    }
}
