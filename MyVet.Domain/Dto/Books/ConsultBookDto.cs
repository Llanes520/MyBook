using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBook.Domain.Domain.Dto.Books
{
    public class ConsultBookDto : BookDto
    {
        public string TypeBook { get; set; }
        public string Nombre { get; set; }
    }
}
