using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    public class KinesiologoController : ControllerBase
    {
            private readonly KineappContext _context;
            private readonly IMapper _mapper;

            public KinesiologoController(KineappContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet("api/Kinesiologo/Get")]
            public async Task<ActionResult<List<DtoKinesiologo>>> getKine()
            {
                try
                {
                    var listaDto = new List<DtoKinesiologo>();
                    var kinesiologos = await _context.Kinesiologo1s.ToListAsync();
                    if (kinesiologos != null)
                    {
                        var kineDto = _mapper.Map<List<DtoKinesiologo>>(kinesiologos);
                        if (kineDto != null)
                        {
                            listaDto.AddRange(kineDto);

                            return listaDto;
                        }
                        else return BadRequest("fallo el mapeo");
                    }
                    else
                    {
                        return StatusCode(500, "No hay kinesiologos");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Fallo la solicitud: {ex.Message}");
                }
            }


            [HttpGet("api/Kinesiologo/{id}")]
            public async Task<ActionResult<DtoKinesiologo>> ObtenerPorId(int id)
            {
                var kinesiologos = await _context.Kinesiologo1s.FirstOrDefaultAsync(k => k.IdKinesiologo == id);
                if (kinesiologos == null)
                {
                    return NotFound();
                }
                return Ok(kinesiologos);
            }
        
    }
}
