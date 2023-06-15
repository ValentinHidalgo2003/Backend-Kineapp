using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoReporteTurnosXDia
    {
        private readonly KineappContext _context;

        public DtoReporteTurnosXDia(KineappContext context)
        {
            _context = context;
        }

        public int ObtenerTurnosAtendidos(string diaSemana)
        {
            try
            {
                string[] diasSemana = { "lunes", "martes", "miércoles", "jueves", "viernes", "sábado", "domingo" };
                int numeroDiaSemana = Array.IndexOf(diasSemana, diaSemana.ToLower());

                if (numeroDiaSemana == -1)
                {
                    // El día de la semana no es válido
                    return -1;
                }

                var fechaActual = DateTime.Now.Date;
                var primerDiaSemana = fechaActual.AddDays(-(int)fechaActual.DayOfWeek + numeroDiaSemana);
                var ultimoDiaSemana = primerDiaSemana.AddDays(6);

                var turnosAtendidos = _context.DetalleTurnos
                    .Where(t => t.Fecha >= primerDiaSemana && t.Fecha <= ultimoDiaSemana)
                    .Count();

                return turnosAtendidos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }


    }
}
