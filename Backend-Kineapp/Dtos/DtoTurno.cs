using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoTurno
    {
        public string? Nota { get; set; }
        public int? IdDetalleTurno { get; set; }
        public virtual DtoDetalleTurno? DetalleTurno { get; set; }
    }
}
