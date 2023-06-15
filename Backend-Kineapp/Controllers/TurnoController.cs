using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;


        public TurnoController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("api/Turno/Get")]
        public async Task<ActionResult<List<DtoTurno>>> GetTurnos()
        {
            try
            {
                var listaDto = new List<DtoTurno>();
                //var turnos = await _context.Turnos.Include(t => t.IdDetalleTurnoNavigation).ToListAsync();
                var turnos = await _context.Turnos
                    .Include(t => t.IdDetalleTurnoNavigation)
                        .ThenInclude(d => d.IdKinesiologoNavigation)
                    .Include(t => t.IdDetalleTurnoNavigation)
                        .ThenInclude(d => d.IdTratamientoNavigation)
                    .Include(t => t.IdDetalleTurnoNavigation)
                        .ThenInclude(d => d.IdTratamientoNavigation.IdTipoTratamientoNavigation)
                    .Include(t => t.IdDetalleTurnoNavigation)
                        .ThenInclude(d => d.IdMedioPagoNavigation)
                    .Include(t => t.IdDetalleTurnoNavigation)
                        .ThenInclude(d => d.IdObraSocialNavigation)  
                    .Include(t => t.IdDetalleTurnoNavigation)
                        .ThenInclude(d => d.IdPacienteNavigation)
                    .ToListAsync();

                if (turnos != null)
                {
                    var turnoDto = _mapper.Map<List<DtoTurno>>(turnos);
                    if (turnoDto != null)
                    {
                        listaDto.AddRange(turnoDto);
                        return listaDto;
                    }
                    else return BadRequest("fallo el mapeo");
                }
                else
                {
                    return StatusCode(500, "No hay pacientes");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fallo la solicitud: {ex.Message}");
            }
        }


        [HttpPost("api/Turno/Post")]
        public ActionResult PostPaciente(DtoTurno registrarTurnoDTO)
        {
            if (registrarTurnoDTO is null || registrarTurnoDTO.DetalleTurno is null)
            {
                return BadRequest("El campo registrarTurnoDTO o detalleTurno son requeridos.");
            }

            var turno = _mapper.Map<Turno>(registrarTurnoDTO);

            var detalleturno = _mapper.Map<DetalleTurno>(registrarTurnoDTO.DetalleTurno);
            var tratamiento = _mapper.Map<Tratamiento>(registrarTurnoDTO.DetalleTurno.Tratamiento);

            turno.IdDetalleTurnoNavigation = detalleturno;
            turno.IdDetalleTurnoNavigation.IdTratamientoNavigation = tratamiento;
            

            _context.Turnos.Add(turno);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("api/Turno/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var detalleTurno = await _context.DetalleTurnos.FindAsync(id);
            if (detalleTurno == null)
            {
                return NotFound($"No se encontró el detalle turno con el Id {id}");
            }

            // buscar turno correspondiente y removerlo
            var turno = await _context.Turnos.FirstOrDefaultAsync(t => t.IdDetalleTurno == id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
            }

            _context.DetalleTurnos.Remove(detalleTurno);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("api/Turno/GetTurnosPorFecha/{fecha}")]
        public ActionResult<List<DtoTurno>> GetTurnosPorFecha(DateTime fecha)
        {
            var turnos = _context.Turnos
                .Include(t => t.IdDetalleTurnoNavigation)
                .ThenInclude(d => d.IdTratamientoNavigation.IdTipoTratamientoNavigation)
                .Where(t => t.IdDetalleTurnoNavigation.Fecha == fecha.Date)
                .ToList();
            var turnosDto = _mapper.Map<List<DtoTurno>>(turnos);
            return turnosDto;
        }


    }

}
