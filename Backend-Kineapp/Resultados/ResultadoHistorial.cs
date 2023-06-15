using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Resultados
{
    public class ResultadoHistorial : ResultadoBase
    {
        public DateTime? FechaCreacion { get; set; }

        public string? Descripcion { get; set; }

        public string? Nota { get; set; }

    }
}
