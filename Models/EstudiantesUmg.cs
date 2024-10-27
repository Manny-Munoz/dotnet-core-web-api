using System;
using System.Collections.Generic;

namespace Proyecto_final.Models;

public partial class EstudiantesUmg
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int? Edad { get; set; }

    public string? CorreoElectronico { get; set; }
}
