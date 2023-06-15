using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    //public int TipoUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string Password  { get; set; }
    public int? IdRol { get; set; }
    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; } = new List<Paciente>();
    public virtual ICollection<Kinesiologo1>? Kinesiologo1s { get; } = new List<Kinesiologo1>();
}
