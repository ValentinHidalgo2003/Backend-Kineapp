using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoPaciente
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

        public DtoHistorial? HistorialMedico { get; set; }
       
        public int? IdObraSocial { get; set; }        //REGISTRAR CON CUAL DE LAS OBRAS SOCIALES ESTA EL PACIENTE
        public virtual DtoObraSocial? DtoObraSocial { get; set; }   // CONSUTAR LOS DATOS DE LA OBRA SOCIAL DEL PACIENTE
       
        public int? IdTurno { get; set; }
        public virtual DtoTurno? Turno { get; set; }

        public int? IdUsuario { get; set; }
        public DtoUsuario? Usuario { get; set; }
    }
}
