namespace Backend_Kineapp.Dtos
{
    public class DtoPacientePUT
    {

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public long? Dni { get; set; }

        public DateTime? FechaNacimento { get; set; }

        public bool? Sexo { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Antecedentes { get; set; }

        public virtual DtoHistorial? DtoIdHistorial { get; set; }
        public virtual DtoObraSocial? DtoObraSocial { get; set; }
        public virtual DtoTurno? DtoTurno { get; set; }
        public virtual DtoUsuario? DtoUsuario { get; set; }
    }
}
