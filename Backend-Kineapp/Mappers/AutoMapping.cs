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
            CreateMap<RegistrarPacienteDTO, Paciente>();

            CreateMap<Paciente, DtoPacientePUT>()
           .ForMember(dest => dest.historialMedico, opt => opt.MapFrom(src => src.IdHistorialNavigation))
             .ForMember(dest => dest.DtoObraSocial, opt => opt.MapFrom(src => src.IdObraSocialNavigation)).ReverseMap();

            CreateMap<Paciente, DtoPaciente>()
           .ForMember(dest => dest.HistorialMedico, opt => opt.MapFrom(src => src.IdHistorialNavigation))
             .ForMember(dest => dest.DtoObraSocial, opt => opt.MapFrom(src => src.IdObraSocialNavigation))
             .ForMember(dest => dest.Turno, opt => opt.MapFrom(src => src.IdTurnoNavigation))
             .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation))
             .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation)).ReverseMap();

            CreateMap<DtoPaciente, Paciente>()
                .ForMember(dest => dest.IdHistorialNavigation, opt => opt.MapFrom(src => src.HistorialMedico))
                .ForMember(dest => dest.IdObraSocialNavigation, opt => opt.MapFrom(src => src.DtoObraSocial));

            CreateMap<Kinesiologo1, DtoKinesiologo>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.IdUsuarioNavigation)).ReverseMap();

            CreateMap<Tratamiento, DtoTratamiento>()
                .ForMember(dest => dest.TipoTratamiento, opt => opt.MapFrom(src => src.IdTipoTratamientoNavigation)).ReverseMap();

            CreateMap<MedioPago, DtoMedioPago>().ReverseMap();

            CreateMap<ObraSocial, DtoObraSocial>().ReverseMap();

            CreateMap<TipoTratamiento, DtoTipoTratamiento>().ReverseMap();

            CreateMap<DetalleTurno, DtoDetalleTurno>()
     .ForMember(dest => dest.Kinesiologo, opt => opt.MapFrom(src => src.IdKinesiologoNavigation))
     .ForMember(dest => dest.MedioPago, opt => opt.MapFrom(src => src.IdMedioPagoNavigation))
     .ForMember(dest => dest.ObraSocial, opt => opt.MapFrom(src => src.IdObraSocialNavigation))
     .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.IdPacienteNavigation))
     .ForMember(dest => dest.Tratamiento, opt => opt.MapFrom(src => src.IdTratamientoNavigation))
     .ForPath(dest => dest.Tratamiento.TipoTratamiento, opt => opt.MapFrom(src => src.IdTratamientoNavigation.IdTipoTratamientoNavigation)).ReverseMap();


            CreateMap<Turno, DtoTurno>()
                .ForMember(dest => dest.DetalleTurno, opt => opt.MapFrom(src => src.IdDetalleTurnoNavigation)).ReverseMap();
            
            CreateMap<Permiso, DtoPermisos>().ReverseMap();
            CreateMap<RolesPermisos, DtoRolesPermisos>().ReverseMap();

        }
    }
}
