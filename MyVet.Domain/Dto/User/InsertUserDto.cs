using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.User
{
    public class InsertUserDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public string Password { get; set; }
    }
}
