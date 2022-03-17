using Common.Utils.Enums;
using Common.Utils.RestServices.Interfaces;
using Microsoft.Extensions.Configuration;
using MyBook.Domain.Domain.Dto.Books;
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
    public class BookServices : IBookServices
    {
        #region Atributes
        private readonly IRestServices _restServices;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public BookServices(IRestServices restServices, IConfiguration config)
        {
            _restServices = restServices;
            _config = config;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllMyBook(string token)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerBook").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodGetAllBook").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restServices.GetRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultBookDto>>(response.Result.ToString());

            return response;
        }
        public async Task<ResponseDto> GetAllTypeBook(string token)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerBook").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodGetAllTypeBook").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restServices.GetRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultBookDto>>(response.Result.ToString());

            return response;

        }
        public async Task<ResponseDto> GetAllEditorial(string token)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerBook").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodGetAllEditorial").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restServices.GetRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultBookDto>>(response.Result.ToString());

            return response;

        }
        public async Task<ResponseDto> DeleteBookAsync(string token, string book)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerBook").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodDeleteBook").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            
            headers.Add("Token", token);
            parametres.Add("book", book);

            ResponseDto response = await _restServices.DeleteRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Message = "Se eliminó correctamente la editorial";

            return response;

        }
        public async Task<ResponseDto> InsertBookAsync(string token,BookDto book)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerBook").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodInsertBook").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            BookDto parametres = new BookDto()
            {
                Titulo = book.Titulo,
                Sipnosis = book.Sipnosis,
                Paginas = book.Paginas,
                IdEditorial = book.IdEditorial,
                IdTypeBook = book.IdTypeBook,
                IdAuthors = (int)Enums.Autores.Predeterminado,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PostRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;

        }
        public async Task<ResponseDto> UpdateBookAsync(string token, BookDto book)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerBook").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodUpdateBook").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            BookDto parametres = new BookDto()
            {
                IdBook = book.IdBook,
                Titulo = book.Titulo,
                Sipnosis = book.Sipnosis,
                Paginas = book.Paginas,
                IdEditorial = book.IdEditorial,
                IdTypeBook = book.IdTypeBook,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PutRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;


        } 
        #endregion
    }

}

