using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoKinesiologo
    {
        public int IdKinesiologo { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public long? Dni { get; set; }

        public string? Telefono { get; set; }

        public string? Emal { get; set; }
        public virtual DtoUsuario? Usuario { get; set; }
    }
}
