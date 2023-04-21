using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    //public int TipoUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string Password  { get; set; }
    public int? IdPaciente { get; set; }

    public int? IdKinesiologo { get; set; }

    public virtual ICollection<Kinesiologo1> Kinesiologo1s { get; } = new List<Kinesiologo1>();

    public virtual ICollection<Paciente> Pacientes { get; } = new List<Paciente>();
}
