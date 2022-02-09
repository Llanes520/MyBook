using Common.Utils.Enums;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class DateService : IDateService
    {
        #region Atributhe
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Builder
        public DateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<DateDto> GetAllMyDates(int idUser)
        {
            var dates = _unitOfWork.DatesRepository.FindAll(p => p.PetEntity.userPetEntityes.IdUser == idUser,
                                                           p => p.PetEntity.userPetEntityes,
                                                           p => p.PetEntity.TypePetEntity,
                                                           p => p.ServicesEntity,
                                                           p => p.StateEntity).ToList();

            List<DateDto> list = dates.Select(x => new DateDto
            {
                Id = x.Id,
                Contac = x.Contac,
                IdPet = x.IdPet,
                IdServices = x.IdServices,
                IdState = x.IdState,
                IdUserVet = x.IdUserVet,
                Description = x.Description,
                Date = x.Date,
                ClosingDate = x.ClosingDate,
                StrClosingDate = x.ClosingDate == null ? "No disponible" : x.ClosingDate.Value.ToString("yyyy-MM-dd"),
                Pet = $"{x.PetEntity.Name}  [{x.PetEntity.TypePetEntity.TypePet}]",
                Service = x.ServicesEntity.Services,
                State = x.StateEntity.State,
                StrDate = x.Date.ToString("yyyy-MM-dd"),
            }).ToList();

            return list;
        }
        
        public List<DateDto> GetAllDates(int idUser)
        {
            var dates = _unitOfWork.DatesRepository.GetAll(x => x.IdUserVet == idUser || x.IdUserVet == null,
                                                           p => p.PetEntity.userPetEntityes,
                                                           p => p.PetEntity.TypePetEntity,
                                                           p => p.ServicesEntity,
                                                           p => p.StateEntity).ToList();

            List<DateDto> list = dates.Select(x => new DateDto
            {
                Id = x.Id,
                Contac = x.Contac,
                IdPet = x.IdPet,
                IdServices = x.IdServices,
                IdState = x.IdState,
                IdUserVet = x.IdUserVet,
                Date = x.Date,
                ClosingDate = x.ClosingDate,
                StrClosingDate = x.ClosingDate == null ? "No disponible" : x.ClosingDate.Value.ToString("yyyy-MM-dd"),
                Pet = $"{x.PetEntity.Name}  [{x.PetEntity.TypePetEntity.TypePet}]",
                Service = x.ServicesEntity.Services,
                State = x.StateEntity.State,
                StrDate = x.Date.ToString("yyyy-MM-dd"),
            }).ToList();

            return list;
        }

        public List<ServiceDto> GetAllMyService()
        {
            List<ServicesEntity> services = _unitOfWork.ServicesRepository.GetAll().ToList();

            List<ServiceDto> list = services.Select(x => new ServiceDto
            {
                Id = x.Id,
                Services = x.Services,
            }).ToList();

            return list;
        } 

        public async Task<bool> InsertDateAsync(DateDto dates)
        {
            //PetEntity petEntity = new PetEntity()
            //{
            //    DateBorns = pet.DateBorns,
            //    IdSex=  pet.IdSex,
            //    IdTypePet= pet.IdTypePet,
            //    Name= pet.Name, 
            //};
            //_unitOfWork.PetRepository.Insert(petEntity);

            //UserPetEntity userPetEntity = new UserPetEntity()
            //{
            //    IdUser=pet.IdUser,
            //    IdPet=petEntity.Id
            //};
            //_unitOfWork.UserPetRepository.Insert(userPetEntity);

            DatesEntity datesEntity = new DatesEntity()
            {
                Date = dates.Date,
                Contac = dates.Contac,
                IdPet = dates.IdPet,
                IdServices = dates.IdServices,
                IdState = (int)Enums.State.CitaActiva,
            };

            _unitOfWork.DatesRepository.Insert(datesEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateDateAsync(DateDto dates)
        {
            bool result = false;

            DatesEntity dateEntity = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == dates.Id);
            if (dateEntity != null)
            {
                dateEntity.Date = dates.Date;
                dateEntity.Contac = dates.Contac;
                dateEntity.IdServices = dates.IdServices;
                dateEntity.IdPet = dates.IdPet;
                dateEntity.Description = dates.Description;

                _unitOfWork.DatesRepository.Update(dateEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<bool> UpdateDateVetAsync(DateDto dates)
        {
            bool result = false;

            DatesEntity dateEntity = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == dates.Id);
            if (dateEntity != null)
            {
                dateEntity.Date = dates.Date;
                dateEntity.Contac = dates.Contac;
                dateEntity.IdServices = dates.IdServices;
                dateEntity.IdPet = dates.IdPet;
                dateEntity.IdState = dates.IdState;
                dateEntity.IdUserVet = dates.IdUserVet;
                dateEntity.ClosingDate = DateTime.Now;

                _unitOfWork.DatesRepository.Update(dateEntity);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<ResponseDto> DeleteDateAsync(int id)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.DatesRepository.Delete(id);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente la Mascota";
            else
                response.Message = "Hubo un error al eliminar la Mascota, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> CancelDateAsync(int idDate)
        {
            bool result = false;

            DatesEntity dateEntity = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == idDate);
            if (dateEntity != null)
            {
                dateEntity.IdState = (int)Enums.State.CitaCancelada;
                dateEntity.ClosingDate = DateTime.Now;

                _unitOfWork.DatesRepository.Update(dateEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        #endregion
    }
}
