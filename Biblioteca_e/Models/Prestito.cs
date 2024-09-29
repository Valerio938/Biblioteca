using System;
using System.Collections.Generic;

namespace Biblioteca_e.Models;

public partial class Prestito
{
    public int PrestitoId { get; set; }

    public string? CodiceUtente { get; set; }

    //public string TracciaLibro { get; set; } = null!;

    public DateOnly DataConsegna { get; set; }

    public DateOnly DataRitiro { get; set; }

    public int UtenteRif { get; set; }

    public int LibroRif { get; set; }

    public virtual Libro LibroRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
