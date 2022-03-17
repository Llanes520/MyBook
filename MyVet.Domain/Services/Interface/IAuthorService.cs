using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IAuthorService
    {
        Task<ResponseDto> GetAllAuthors(string token);
        Task<ResponseDto> InsertAuthorAsync(string token, AuthorsDto authors);
        Task<ResponseDto> DeleteAuthorAsync(string token, string id);
        Task<ResponseDto> UpdateAuthorAsync(string token, AuthorsDto edit);
    }
}
