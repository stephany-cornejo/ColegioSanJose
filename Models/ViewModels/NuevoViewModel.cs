using System.ComponentModel.DataAnnotations;
using System;


namespace SanJoseEstudiantes.Models.ViewModels
{
    public class NuevoViewModel
     {
         public int ExtpedienteId { get; set; }
         [Required]
         public AlumnoViewModel Alumno { get; set; } = new AlumnoViewModel();
         [Required]
         public MateriaViewModel Materia { get; set; } = new MateriaViewModel();
         [Range(0, 10, ErrorMessage = "La nota final debe estar en el rango de {1} y {2}.")]
         public decimal NotaFinal { get; set; }
         [StringLength(50, ErrorMessage = "Las observaciones no pueden superar los {1} caracteres.")]
         public string? Observaciones { get; set; }
         }

         public class AlumnoViewModel
         {
         public int AlumnoId { get; set; }
         [Required]
         [StringLength(15, ErrorMessage = "El nombre no puede superar los {1} caracteres.")]
         public string Nombre { get; set; } = string.Empty;
         [Required]
         [StringLength(15, ErrorMessage = "El apellido no puede superar los {1} caracteres.")]
         public string Apellido { get; set; } = string.Empty;
         [DataType(DataType.Date)]
         [Required]
         public DateOnly FechaNacimiento { get; set; }
         [Required]
         [StringLength(15, ErrorMessage = "El grado no puede superar los {1} caracteres.")]
         public string Grado { get; set; } = string.Empty;
         }

         public class MateriaViewModel
         {
         public int MateriaId { get; set; }
         [Required]
         [StringLength(25, ErrorMessage = "El nombre de la materia no puede superar los {1} caracteres.")]
         public string NombreMateria { get; set; } = string.Empty;
         [StringLength(30, ErrorMessage = "El nombre del docente no puede superar los {1} caracteres.")]
         public string Docente { get; set; } = string.Empty;
     }
}
