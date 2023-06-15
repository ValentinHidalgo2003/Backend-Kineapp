using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoUsuario
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        //public virtual Rol? IdRolNavigation { get; set; }
    }
}
