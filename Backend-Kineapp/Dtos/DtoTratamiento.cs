using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoTratamiento
    {
        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string? Objetivo { get; set; }

        public string? Comentario { get; set; }

        public int? IdTipoTratamiento { get; set; }
        public virtual DtoTipoTratamiento? TipoTratamiento { get; set; }
    }
}
