using System;
using System.Collections.Generic;

namespace SanJoseEstudiantes.Models.DB;

public partial class Expediente
{
    public int ExtpedienteId { get; set; }

    public int AlumnoId { get; set; }

    public int MateriaId { get; set; }

    public decimal NotaFinal { get; set; }

    public string? Observaciones { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Materium Materia { get; set; } = null!;
}
