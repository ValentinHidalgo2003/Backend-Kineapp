using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Kineapp.Modelos;

public partial class HistorialMedico
{

    //[DatabaseGenerated(DatabaseGeneratedOption.None)]

    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdHistorial { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public string? Nota { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; } = new List<Paciente>();
    
}
