using Infraestructure.Entity.Models.Vet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class DateDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string Contac { get; set; }

        public int IdServices { get; set; }

        public int IdPet { get; set; }

        public int? IdUserVet { get; set; }

        public DateTime? ClosingDate { get; set; }

        public int IdState { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public string Pet { get; set; }
        public string Service { get; set; }
        public string State { get; set; }
        public string StrClosingDate { get; set; }
        public string StrDate { get; set; }
    }
}
