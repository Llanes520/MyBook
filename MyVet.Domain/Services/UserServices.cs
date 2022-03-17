using Common.Utils.Enums;
using Common.Utils.RestServices.Interfaces;
using Common.Utils.Utils;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.RestSevices;
using MyVet.Domain.Dto.User;
using MyVet.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Utils.Enums.Enums;

namespace MyVet.Domain.Services
{
    public class UserServices : IUserServices
    {
        #region Attribute
        private readonly IRestServices _restServices;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public UserServices(IRestServices restServices, IConfiguration config)
        {
            _restServices = restServices;
            _config = config;
        }
        #endregion

        #region authentication

        public async Task<ResponseDto> Login(LoginDto user)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerAuthentication").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodLogin").Value;

            LoginDto parametres = new LoginDto()
            {
                Password=user.Password,
                UserName=user.UserName,
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            ResponseDto resultToken = await _restServices.PostRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return resultToken;

            //ResponseDto response = new ResponseDto();
            //UserEntity result = _uniOfWork.UserRepository.FirstOrDefault(x => x.Email == user.UserName
            //                                                                && x.Password == user.Password,
            //                                                               r => r.RolUserEntities);
            //if (result == null)
            //{
            //    response.Message = "Usuario o contraseña inválida!";
            //    response.IsSuccess = false;
            //}
            //else
            //{
            //    response.Result = result;
            //    response.IsSuccess = true;
            //    response.Message = "Usuario autenticado!";
            //}

            //return response;
        }

        #endregion

        #region Methods Crud
        public async Task<ResponseDto> GetallUser(string token)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerUser").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodGetAllUser").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restServices.GetRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<UpdateUserDto>>(response.Result.ToString());

            return response;


            //return _uniofwork.userrepository.getall().tolist();
        }
        public async Task<ResponseDto> InsertUser(string token ,InsertUserDto user)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerUser").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodInsertUser").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            InsertUserDto parametres = new InsertUserDto()
            {
                Name = user.Name,
                LastName  = user.LastName,
                Email = user.Email,
                Password = user.Password,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PostRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;
        }

        public async Task<ResponseDto> UpdateUser(string token ,UpdateUserDto user)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerUser").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodUpdateUser").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            UpdateUserDto parametres = new UpdateUserDto()
            {
                IdUser = user.IdUser,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
            };
            headers.Add("Token", token);

            ResponseDto response = await _restServices.PutRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);

            return response;
        }

        public async Task<ResponseDto> DeleteUser(string token ,string idUser)
        {
            string urlBase = _config.GetSection("ApiMyBook").GetSection("UrlBase").Value;
            string Controller = _config.GetSection("ApiMyBook").GetSection("ControlerUser").Value;
            string Method = _config.GetSection("ApiMyBook").GetSection("MethodDeleteUser").Value;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> parametres = new Dictionary<string, string>();

            headers.Add("Token", token);
            parametres.Add("idUser", idUser);

            ResponseDto response = await _restServices.DeleteRestServiceAsync<ResponseDto>(urlBase, Controller, Method, parametres, headers);
            if (response.IsSuccess)
                response.Message = "Se eliminó correctamente el usuario";

            return response;
        }

        //public async Task<ResponseDto> Register(UserDto data)
        //{
        //    ResponseDto result = new ResponseDto();

        //    if (Utils.ValidateEmail(data.UserName))
        //    {
        //        if (_uniOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
        //        {

        //            RolUserEntity rolUser = new RolUserEntity()
        //            {
        //                IdRol = RolUser.Estandar.GetHashCode(),
        //                UserEntity = new UserEntity()
        //                {
        //                    Email = data.UserName,
        //                    LastName = data.LastName,
        //                    Name = data.Name,
        //                    Password = data.Password
        //                }
        //            };

        //            _uniOfWork.RolUserRepository.Insert(rolUser);
        //            result.IsSuccess = await _uniOfWork.Save() > 0;
        //        }
        //        else
        //            result.Message = "Email ya se encuestra registrado, utilizar otro!";
        //    }
        //    else
        //        result.Message = "Usuario con Email Inválido";

        //    return result;
        //}
        #endregion

    }
}
