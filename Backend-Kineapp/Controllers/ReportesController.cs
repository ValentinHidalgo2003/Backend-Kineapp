using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;
        private readonly DtoReporteTurnosXDia _obtenerTurnosAtendidosPorDiaSemana;

        public ReportesController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _obtenerTurnosAtendidosPorDiaSemana = new DtoReporteTurnosXDia(context);
        }

        [HttpGet("api/Reporte/PacientesPorObraSocial")]
        public ActionResult<List<DtoReportePacienteObraSocial>> GetReportePacientesPorObraSocial()
        {
            var reporte = _context.Pacientes
                .GroupBy(p => p.IdObraSocialNavigation.Descripcion)
                .Select(g => new DtoReportePacienteObraSocial
                {
                    NombreObraSocial = g.Key,
                    CantidadPacientes = g.Count()
                })
                .ToList();
            return reporte;
        }

        [HttpGet("api/Reporte/Mes/{mes}")]
        public async Task<ActionResult<DtoReporteCobrosDto>> ObtenerReporteCobrosMes(int mes)
        {
            try
            {

                var fechaInicio = new DateTime(DateTime.Now.Year, mes, 1);
                var fechaFin = fechaInicio.AddMonths(1).AddSeconds(-1);


                var cobros = await _context.DetalleTurnos
                    .Where(c => c.Fecha >= fechaInicio && c.Fecha <= fechaFin)
                    .ToListAsync();


                if (cobros == null || cobros.IsNullOrEmpty() )
                {
                    return NotFound();
                }

                var cobrosTarjeta = cobros.Where(c => c.IdMedioPago == 2);
                var cobrosEfectivo = cobros.Where( c => c.IdMedioPago == 1);
                var totalTarjeta = cobrosTarjeta.Sum(c => c.Precio) ?? 0;
                var totalEfectivo = cobrosEfectivo.Sum(c => c.Precio) ?? 0;



                var reporte = new DtoReporteCobrosDto
                {
                    Mes = mes,
                    TotalTarjeta = totalTarjeta,
                    TotalEfectivo = totalEfectivo,
                    Total = totalTarjeta + totalEfectivo
                };

                return reporte;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("api/Reporte/TurnosAtendidos/{diaSemana}")]
        public ActionResult<int> GetTurnosAtendidosPorDiaSemana(string diaSemana)
        {
            var turnosAtendidos = _obtenerTurnosAtendidosPorDiaSemana.ObtenerTurnosAtendidos(diaSemana);
            if (turnosAtendidos == -1)
            {
                return BadRequest("Error al obtener los turnos atendidos.");
            }

            return turnosAtendidos;
        }

        [HttpGet("api/Reporte/TurnosPorDiaSemana")]
        public ActionResult<Dictionary<string, int>> GetTurnosPorDiaSemana()
        {
            try
            {
                var turnosPorDiaSemana = _context.DetalleTurnos
                    .AsEnumerable()
                    .GroupBy(t => t.Fecha.DayOfWeek.ToString())
                    .ToDictionary(g => g.Key, g => g.Count());


                return turnosPorDiaSemana;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
