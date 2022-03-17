using MyBook.Domain.Domain.Dto.Books;
using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IBookServices
    {
        Task<ResponseDto> GetAllMyBook(string token);
        Task<ResponseDto> GetAllTypeBook(string token);
        Task<ResponseDto> GetAllEditorial(string token);
        Task<ResponseDto> DeleteBookAsync(string token, string book);
        Task<ResponseDto> InsertBookAsync(string token, BookDto book);
        Task<ResponseDto> UpdateBookAsync(string token, BookDto book);

    }
}
