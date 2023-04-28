using Backend_Kineapp.Modelos;
using System.ComponentModel.DataAnnotations;

namespace Backend_Kineapp.Dtos
{
    public class DtoHistorial
    {
        public DateTime? FechaCreacion { get; set; }

        public string? Descripcion { get; set; }

        public string? Nota { get; set; }
       // public virtual ICollection<Paciente>? Pacientes { get; } = new List<Paciente>();
    }
}
