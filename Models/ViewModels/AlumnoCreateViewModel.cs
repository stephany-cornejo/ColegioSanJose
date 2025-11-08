using System.ComponentModel.DataAnnotations;

namespace SanJoseEstudiantes.Models.ViewModels
{
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
}
