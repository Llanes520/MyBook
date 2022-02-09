using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class ServiceDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El servicio es requerido")]
        public string Services { get; set; }
        public string Description { get; set; }
    }
}
