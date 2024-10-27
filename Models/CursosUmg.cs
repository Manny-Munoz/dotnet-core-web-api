using System;
using System.Collections.Generic;

namespace Proyecto_final.Models;

public partial class CursosUmg
{
    public int Id { get; set; }

    public string Curos { get; set; } = null!;

    public string Semestre { get; set; } = null!;

    public int? Creditos { get; set; }
}
