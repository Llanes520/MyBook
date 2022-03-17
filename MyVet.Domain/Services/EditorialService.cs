using Common.Utils.Enums;
using Common.Utils.RestServices.Interfaces;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class EditorialService : IEditorialService
    {
        #region Atributhe
        private readonly IRestServices _restServices;
        private readonly IConfiguration _config;

        #endregion

        #region Builder
        public EditorialService(IRestServices restServices, IConfiguration configuration)
        {
            _restServices = restServices;
            _config = configuration;
        }
        #endregion

        #region Methods
        
        public async Task<ResponseDto> GetAllEditorial(string token)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerEditorial").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodGetAllEditorials").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restServices.GetRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<EditorialDto>>(response.Result.ToString());

            return response;



            //var dates = _unitOfWork.DatesRepository.GetAll(x => x.IdUserVet == idUser || x.IdUserVet == null,
            //                                               p => p.PetEntity.userPetEntityes,
            //                                               p => p.PetEntity.TypePetEntity,
            //                                               p => p.ServicesEntity,
            //                                               p => p.StateEntity).ToList();

            //List<DateDto> list = dates.Select(x => new DateDto
            //{
            //    Id = x.Id,
            //    Contac = x.Contac,
            //    IdPet = x.IdPet,
            //    IdServices = x.IdServices,
            //    IdState = x.IdState,
            //    IdUserVet = x.IdUserVet,
            //    Date = x.Date,
            //    ClosingDate = x.ClosingDate,
            //    StrClosingDate = x.ClosingDate == null ? "No disponible" : x.ClosingDate.Value.ToString("yyyy-MM-dd"),
            //    Pet = $"{x.PetEntity.Name}  [{x.PetEntity.TypePetEntity.TypePet}]",
            //    Service = x.ServicesEntity.Services,
            //    State = x.StateEntity.State,
            //    StrDate = x.Date.ToString("yyyy-MM-dd"),
            //}).ToList();

            //return list;
        }
        public async Task<ResponseDto> InsertEditorialAsync(string token, EditorialDto edit)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerEditorial").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodInsertEditorials").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            EditorialDto parametres = new EditorialDto()
            {
                Nombre = edit.Nombre,
                Sede = edit.Sede,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PostRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;


            //DatesEntity datesEntity = new DatesEntity()
            //{
            //    Date = dates.Date,
            //    Contac = dates.Contac,
            //    IdPet = dates.IdPet,
            //    IdServices = dates.IdServices,
            //    IdState = (int)Enums.State.CitaActiva,
            //};

            //_unitOfWork.DatesRepository.Insert(datesEntity);
            //return await _unitOfWork.Save() > 0;
        }
        public async Task<ResponseDto> DeleteEditorialAsync(string token, string id)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerEditorial").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodDeleteEditorials").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();

            headers.Add("Token", token);
            parametres.Add("idEditorial", id);

            ResponseDto response = await _restServices.DeleteRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            //response.IsSuccess = true;
            if (response.IsSuccess)
                response.Message = "Se eliminó correctamente la editorial";

            return response;


            //ResponseDto response = new ResponseDto();

            //_unitOfWork.DatesRepository.Delete(id);
            //response.IsSuccess = await _unitOfWork.Save() > 0;
            //if (response.IsSuccess)
            //    response.Message = "Se elminnó correctamente la Mascota";
            //else
            //    response.Message = "Hubo un error al eliminar la Mascota, por favor vuelva a intentalo";

            //return response;
        }
        public async Task<ResponseDto> UpdateEditorialAsync(string token, EditorialDto edit)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerEditorial").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodUpdateEditorials").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            EditorialDto parametres = new EditorialDto()
            {
                IdEditorial = edit.IdEditorial,
                Nombre = edit.Nombre,
                Sede = edit.Sede,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PutRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;


            //bool result = false;

            //DatesEntity dateEntity = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == dates.Id);
            //if (dateEntity != null)
            //{
            //    dateEntity.Date = dates.Date;
            //    dateEntity.Contac = dates.Contac;
            //    dateEntity.IdServices = dates.IdServices;
            //    dateEntity.IdPet = dates.IdPet;
            //    dateEntity.Description = dates.Description;

            //    _unitOfWork.DatesRepository.Update(dateEntity);

            //    result = await _unitOfWork.Save() > 0;
            //}

            //return result;
        }



        #endregion
    }
}
