using System.ComponentModel.DataAnnotations;

namespace SanJoseEstudiantes.Models.ViewModels
{
    public class MateriaViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "El nombre de la materia no puede superar los {1} caracteres.")]
        public string NombreMateria { get; set; } = string.Empty;
        [StringLength(30, ErrorMessage = "El nombre del docente no puede superar los {1} caracteres.")]
        public string Docente { get; set; } = string.Empty;
    }
}