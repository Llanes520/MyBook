using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class EditorialDto
    {
        [Key]
        public int IdEditorial { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        public string Sede { get; set; }
    }
}
