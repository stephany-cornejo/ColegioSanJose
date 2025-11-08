using SanJoseEstudiantes.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace SanJoseEstudiantes.Models.ViewModels
{
 public class ExpedienteCreateViewModel
 {
 [Required]
 public int AlumnoId { get; set; }
 [Required]
 public int MateriaId { get; set; }
 [Required]
 [Range(0, 10, ErrorMessage = "La nota final debe estar en el rango de {1} y {2}.")]
 public decimal NotaFinal { get; set; }
 [Required]
 [StringLength(50, ErrorMessage = "Las observaciones no pueden superar los {1} caracteres.")]
 public string? Observaciones { get; set; }
 }
}
