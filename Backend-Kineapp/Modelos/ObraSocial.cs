using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class ObraSocial
{
    public int IdObra { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<DetalleTurno> DetalleTurnos { get; } = new List<DetalleTurno>();

    public virtual ICollection<Paciente> Pacientes { get; } = new List<Paciente>();
}
