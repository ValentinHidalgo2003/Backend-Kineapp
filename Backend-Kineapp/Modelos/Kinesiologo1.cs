using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class Kinesiologo1
{
    public int IdKinesiologo { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public long? Dni { get; set; }

    public string? Telefono { get; set; }

    public string? Emal { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<DetalleTurno> DetalleTurnos { get; } = new List<DetalleTurno>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
