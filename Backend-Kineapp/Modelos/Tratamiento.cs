using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class Tratamiento
{
    public int IdTratamiento { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Objetivo { get; set; }

    public string? Comentario { get; set; }

    public int? IdTipoTratamiento { get; set; }

    public virtual ICollection<DetalleTurno> DetalleTurnos { get; } = new List<DetalleTurno>();

    public virtual TipoTratamiento? IdTipoTratamientoNavigation { get; set; }
}
