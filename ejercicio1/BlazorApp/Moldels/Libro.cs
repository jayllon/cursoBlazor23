using BlazorApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Moldels
{

    public enum CategoriaLibro { Terror, Drama, Infantil, Humor, Comic, Historico }
    public class Libro
    {
        [Display(Name = "Titulo del libro")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string? Titulo { get; set; }

        [Display(Name = "Autor del libro")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string? Autor { get; set; }
       
        public int? id_pais { get; set; }
        
        // Ejemplo de un annotation que depende de otro campo, definido en Helpers Customannotation (no fuciona, tenemos que definir bien)
        //[RequiredConditional(PropertyName = nameof(id_pais), InValues = new List<>(){ 724 })]
        public int? id_provincia;

        [Range(typeof(DateTime), "1/1/200", "1/1/2100", ErrorMessage = "El campo {0} debe ser mayor a {1} y menor a {2}")]
        public DateTime? FechaPublicacion { get; set;}

        [Range(0.1, 100, ErrorMessage = "El campo {0} debe estar entre {1} y {2} ")]
        public float Precio { get; set; }


        public bool Disponible { get; set; }

        public CategoriaLibro Categoria { get; set; }

        

    }
}
