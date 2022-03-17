using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBook.Domain.Domain.Dto.Books
{
    public class BookDto : InsertBookDto
    {
        [Key]
        public int IdBook { get; set; }
    }
}
