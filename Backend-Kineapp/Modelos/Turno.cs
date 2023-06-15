using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class Turno
{
    public int IdTurno { get; set; }

    public string? Nota { get; set; }

    public int? IdDetalleTurno { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; } = new List<Paciente>();

    public virtual DetalleTurno? IdDetalleTurnoNavigation { get; set; }

}
