using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBook.Domain.Domain.Dto.Books
{
    public class InsertBookDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(300)]
        [Display(Name = "Sipnosis")]
        public string Sipnosis { get; set; }

        public int Paginas { get; set; }

        [Required(ErrorMessage = "El typo de libro es requerido")]
        public int IdTypeBook { get; set; }
         
        public int IdEditorial { get; set; }

        public int IdAuthors { get; set; }
    }
}
