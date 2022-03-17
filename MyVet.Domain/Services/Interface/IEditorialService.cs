using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IEditorialService
    {
        Task<ResponseDto> UpdateEditorialAsync(string token, EditorialDto edit);
        Task<ResponseDto> GetAllEditorial(string token);
        Task<ResponseDto> InsertEditorialAsync(string token, EditorialDto edit);
        Task<ResponseDto> DeleteEditorialAsync(string token, string id);
    }
}
