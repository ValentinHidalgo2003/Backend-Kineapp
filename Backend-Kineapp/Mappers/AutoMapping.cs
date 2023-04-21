using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Backend_Kineapp.Resultados;

namespace Backend_Kineapp.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ObraSocial, DtoObraSocial>().ReverseMap();

            CreateMap<Usuario, DtoUsuario>().ReverseMap();

            CreateMap<ObraSocial, DtoObraSocial>().ReverseMap();

            CreateMap<HistorialMedico, DtoHistorial>()
                .ReverseMap(); //SIRVE PARA MAPEAR EN AMBOS SENTIDOS
            CreateMap<HistorialMedico, ResultadoHistorial>().ReverseMap();
            CreateMap<DtoHistorial, ResultadoHistorial>().ReverseMap();
            


            CreateMap<DtoPaciente, Paciente>();  //CONVIERTE DE UN DTOPACIENTE A UN PACIENTE
            CreateMap<Paciente, DtoPaciente>(); //AQUI ES AL REVEZ PORQUE EL ORIGEN ES DESDE PACIENTES A DTO
            CreateMap<DtoPaciente, ResultadoPaciente>();
            CreateMap<DtoPacientePUT, Paciente>();
            CreateMap<Paciente, ResultadoPaciente>()
            .ForMember(dest => dest.DtoIdHistorial, opt => opt.MapFrom(src => src.IdHistorialNavigation))
            .ForMember(dest => dest.DtoObraSocial, opt => opt.MapFrom(src => src.IdObraSocialNavigation))
            .ForMember(dest => dest.DtoTurno, opt => opt.MapFrom(src => src.IdTurnoNavigation))
            .ForMember(dest => dest.DtoUsuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation));


        }
    }
}
