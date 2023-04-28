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


            CreateMap<HistorialMedico, DtoHistorial>()
                .ReverseMap(); //SIRVE PARA MAPEAR EN AMBOS SENTIDOS
            CreateMap<HistorialMedico, ResultadoHistorial>().ReverseMap();
            CreateMap<DtoHistorial, ResultadoHistorial>().ReverseMap();
            
            CreateMap<RegistrarPacienteDTO, HistorialMedico>();


            //CreateMap<DtoPaciente, Paciente>();  //CONVIERTE DE UN DTOPACIENTE A UN PACIENTE
            //CreateMap<Paciente, DtoPaciente>(); //AQUI ES AL REVEZ PORQUE EL ORIGEN ES DESDE PACIENTES A DTO
                                                // CreateMap<DtoPaciente, ResultadoPaciente>();
            CreateMap<RegistrarPacienteDTO, Paciente>();

            //   CreateMap<DtoPacientePUT, Paciente>()
            //.ForMember(dest => dest.IdHistorialNavigation, opt => opt.MapFrom(src => src.historialMedico));
            //.ForMember(dest => dest.IdObraSocialNavigation, opt => opt.MapFrom(src => src.DtoObraSocial));
            CreateMap<Paciente, DtoPacientePUT>()
           .ForMember(dest => dest.historialMedico, opt => opt.MapFrom(src => src.IdHistorialNavigation))
             .ForMember(dest => dest.DtoObraSocial, opt => opt.MapFrom(src => src.IdObraSocialNavigation)).ReverseMap();

            CreateMap<Paciente, DtoPaciente>()
           .ForMember(dest => dest.HistorialMedico, opt => opt.MapFrom(src => src.IdHistorialNavigation))
             .ForMember(dest => dest.DtoObraSocial, opt => opt.MapFrom(src => src.IdObraSocialNavigation));

            CreateMap<DtoPaciente, Paciente>()
                .ForMember(dest => dest.IdHistorialNavigation, opt => opt.MapFrom(src => src.HistorialMedico))
                .ForMember(dest => dest.IdObraSocialNavigation, opt => opt.MapFrom(src => src.DtoObraSocial));
    //        CreateMap<DtoPaciente, ResultadoPaciente>()
    //.ForMember(dest => dest.HistorialesMedicos, opt => opt.MapFrom(src => src.HistorialesMedicos));
        }
    }
}
