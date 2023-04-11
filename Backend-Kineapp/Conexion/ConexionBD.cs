namespace Backend_Kineapp.Conexion
{
    public class ConexionBD
    {
        private string conexionString = string.Empty;
        public ConexionBD() 
        {
            var constructor = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            conexionString = constructor.GetSection("ConnectionStrings:Conexion").Value;
        }
        public string cadenaSQL ()
        {
            return conexionString;
        }
    }
}
