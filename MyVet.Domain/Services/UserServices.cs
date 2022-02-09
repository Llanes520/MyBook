using Common.Utils.Utils;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
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
        private readonly IUnitOfWork _uniOfWork;
        #endregion

        #region Builder
        public UserServices(IUnitOfWork uniOfWork)
        {
            _uniOfWork = uniOfWork;
        }
        #endregion

        #region authentication

        public ResponseDto Login(UserDto user)
        {
            ResponseDto response = new ResponseDto();

            UserEntity result = _uniOfWork.UserRepository.FirstOrDefault(x => x.Email == user.UserName
                                                                            && x.Password == user.Password,
                                                                           r => r.RolUserEntities);
            if (result == null)
            {
                response.Message = "Usuario o contraseña inválida!";
                response.IsSuccess = false;
            }
            else
            {
                response.Result = result;
                response.IsSuccess = true;
                response.Message = "Usuario autenticado!";
            }

            return response;
        }

        #endregion

        #region Methods Crud
        public List<UserEntity> GetAll()
        {
            return _uniOfWork.UserRepository.GetAll().ToList();
        }

        public UserEntity GetUser(int idUser)
        {
            return _uniOfWork.UserRepository.Find(x => x.IdUser == idUser);
        }

        public async Task<bool> UpdateUser(UserEntity user)
        {
            UserEntity _user = GetUser(user.IdUser);

            _user.Name = user.Name;
            _user.LastName = user.LastName;
            _uniOfWork.UserRepository.Update(_user);

            return await _uniOfWork.Save() > 0;

            //return _uniOfWork.UserRepository.Find(x => x.IdUser == idUser);
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            _uniOfWork.UserRepository.Delete(idUser);

            return await _uniOfWork.Save() > 0;
        }
        public async Task<ResponseDto> CreateUser(UserEntity data)
        {
            ResponseDto result = new ResponseDto();

            if (Utils.ValidateEmail(data.Email))
            {
                if (_uniOfWork.UserRepository.FirstOrDefault(x => x.Email == data.Email) == null)
                {
                    int idRol = data.IdUser;
                    data.Password = "123456";
                    data.IdUser = 0;

                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = idRol,
                        UserEntity = data
                    };

                    _uniOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _uniOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
                result.Message = "Usuarioc con Email Inválido";

            return result;
        }

        public async Task<ResponseDto> Register(UserDto data)
        {
            ResponseDto result = new ResponseDto();

            if (Utils.ValidateEmail(data.UserName))
            {
                if (_uniOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
                {

                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = RolUser.Estandar.GetHashCode(),
                        UserEntity = new UserEntity()
                        {
                            Email = data.UserName,
                            LastName = data.LastName,
                            Name = data.Name,
                            Password = data.Password
                        }
                    };

                    _uniOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _uniOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
                result.Message = "Usuarioc con Email Inválido";

            return result;
        }
        #endregion

    }
}
