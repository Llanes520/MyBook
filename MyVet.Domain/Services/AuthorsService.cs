using Common.Utils.RestServices.Interfaces;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class AuthorsService : IAuthorService
    {
        #region Atributhe
        private readonly IRestServices _restServices;
        private readonly IConfiguration _config;

        #endregion

        #region Builder
        public AuthorsService(IRestServices restServices, IConfiguration configuration)
        {
            _restServices = restServices;
            _config = configuration;
        }
        #endregion

        #region Methods

        public async Task<ResponseDto> GetAllAuthors(string token)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerAuthors").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodGetAllAthors").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restServices.GetRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<AuthorsDto>>(response.Result.ToString());

            return response;
           
        }
        public async Task<ResponseDto> InsertAuthorAsync(string token, AuthorsDto authors)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerAuthors").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodInsertAuthors").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            AuthorsDto parametres = new AuthorsDto()
            {
                Nombre = authors.Nombre,
                Apellidos = authors.Apellidos,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PostRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;

        }
        public async Task<ResponseDto> DeleteAuthorAsync(string token, string id)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerAuthors").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodDeleteAuthors").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();

            headers.Add("Token", token);
            parametres.Add("idAthor", id);

            ResponseDto response = await _restServices.DeleteRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            //response.IsSuccess = true;
            if (response.IsSuccess)
                response.Message = "Se eliminó correctamente la editorial";

            return response;

        }
        public async Task<ResponseDto> UpdateAuthorAsync(string token, AuthorsDto authors)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerAuthors").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodUpdateAuthor").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            AuthorsDto parametres = new AuthorsDto()
            {
                Id = authors.Id,
                Nombre = authors.Nombre,
                Apellidos = authors.Apellidos,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PutRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;

        }



        #endregion
    }
}
