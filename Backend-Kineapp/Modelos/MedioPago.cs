using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class MedioPago
{
    public int IdMedio { get; set; }

    public int? TipoMedioPago { get; set; }

    public bool? Activo { get; set; }

    //public int? IdDetalleTurno { get; set; }

    public virtual ICollection<DetalleTurno> DetalleTurnos { get; } = new List<DetalleTurno>();
}
