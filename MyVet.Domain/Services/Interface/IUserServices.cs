using MyVet.Domain.Dto;
using MyVet.Domain.Dto.RestSevices;
using MyVet.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IUserServices
    {
        #region Crud
        Task<ResponseDto> GetallUser(string token);
        Task<ResponseDto> InsertUser(string token, InsertUserDto user);
        Task<ResponseDto> DeleteUser(string token, string idUser);
        Task<ResponseDto> UpdateUser(string token, UpdateUserDto user);


        #endregion

        #region Auth
        Task<ResponseDto> Login(LoginDto user);

        //Task<ResponseDto> Register(UserDto data);
        #endregion
    }
}
