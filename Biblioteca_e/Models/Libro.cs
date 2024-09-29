using System;
using System.Collections.Generic;

namespace Biblioteca_e.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string? CodiceUtente { get; set; }

    public string Titolo { get; set; } = null!;

    public DateOnly AnnoPubblicazione { get; set; }

    public bool Disponibilita { get; set; }

    public virtual ICollection<Prestito> Prestitos { get; set; } = new List<Prestito>();
}
