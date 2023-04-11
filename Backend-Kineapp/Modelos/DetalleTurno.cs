using System;
using System.Collections.Generic;

namespace Backend_Kineapp.Modelos;

public partial class DetalleTurno
{
    public int IdDetalle { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public TimeSpan? HoraFin { get; set; }

    public int? IdTratamiento { get; set; }

    public int? IdMedioPago { get; set; }

    public int? IdObraSocial { get; set; }

    public int? IdKinesiologo { get; set; }

    public virtual Kinesiologo1? IdKinesiologoNavigation { get; set; }

    public virtual MedioPago? IdMedioPagoNavigation { get; set; }

    public virtual ObraSocial? IdObraSocialNavigation { get; set; }

    public virtual Tratamiento? IdTratamientoNavigation { get; set; }
}
