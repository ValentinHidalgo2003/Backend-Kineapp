using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public long? Dni { get; set; }

    public DateTime? FechaNacimento { get; set; }

    public bool? Sexo { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Antecedentes { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTurno { get; set; }

    public int? IdObraSocial { get; set; }

    public int? IdHistorial { get; set; }

    public virtual HistorialMedico? IdHistorialNavigation { get; set; }

    public virtual ObraSocial? IdObraSocialNavigation { get; set; }

    public virtual Turno? IdTurnoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<DetalleTurno> DetalleTurnos { get; } = new List<DetalleTurno>();
}
