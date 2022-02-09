using Infraestructure.Entity.Models.Vet;
using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IDateService
    {
        List<DateDto> GetAllMyDates(int idUser);
        public List<ServiceDto> GetAllMyService();
        Task<bool> InsertDateAsync(DateDto dates);
        Task<bool> UpdateDateAsync(DateDto dates);
        Task<bool> UpdateDateVetAsync(DateDto dates);
        Task<ResponseDto> DeleteDateAsync(int idPet);
        Task<bool> CancelDateAsync(int idDate);
        List<DateDto> GetAllDates(int idUser);
    }
}
