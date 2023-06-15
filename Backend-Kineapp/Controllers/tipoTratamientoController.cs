using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    public class tipoTratamientoController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;

        public tipoTratamientoController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("api/TipoTratamiento/Get")]
        public async Task<ActionResult<List<DtoTipoTratamiento>>> getTipoTratamiento()
        {
            try
            {
                var listaDto = new List<DtoTipoTratamiento>();
                var tratamientos = await _context.TipoTratamientos.ToListAsync();
                if (tratamientos != null)
                {
                    var tipostratamientos = _mapper.Map<List<DtoTipoTratamiento>>(tratamientos);
                    if (tipostratamientos != null)
                    {
                        listaDto.AddRange(tipostratamientos);

                        return listaDto;
                    }
                    else return BadRequest("fallo el mapeo");
                }
                else
                {
                    return StatusCode(500, "No hay tratamientos");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fallo la solicitud: {ex.Message}");
            }
        }


        [HttpGet("api/TipoTratamiento/{id}")]
        public async Task<ActionResult<DtoTipoTratamiento>> ObtenerPorId(int id)
        {
            var tiposTratamientos = await _context.TipoTratamientos.FirstOrDefaultAsync(t => t.IdTipoTratamiento == id);
            if (tiposTratamientos == null)
            {
                return NotFound();
            }
            return Ok(tiposTratamientos);
        }
    }
}
