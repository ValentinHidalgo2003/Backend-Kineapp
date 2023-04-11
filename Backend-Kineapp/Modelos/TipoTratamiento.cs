using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class TipoTratamiento
{
    public int IdTipoTratamiento { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Tratamiento> Tratamientos { get; } = new List<Tratamiento>();
}
