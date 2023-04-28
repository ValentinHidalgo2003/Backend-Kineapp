namespace Backend_Kineapp.Dtos
{
    public class DtoPacientePUT
    {
        public int? IdPaciente { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public long? Dni { get; set; }

        public DateTime? FechaNacimento { get; set; }

        public bool? Sexo { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Antecedentes { get; set; }
        public int? IdHistorialMedico { get; set; }
        public virtual DtoHistorial? historialMedico { get; set; }
        public virtual DtoObraSocial? DtoObraSocial { get; set; }
        public int IdObraSocial { get; set; }

        public int? IdTurno { get; set; }
        public int? IdUsuario { get; set; }

    }
}
