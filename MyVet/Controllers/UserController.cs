using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.User;
using MyVet.Domain.Services.Interface;
using MyVet.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : Controller
    {
        #region Attributes
        private readonly IUserServices _userServices;
        private readonly IRolServices _rolServices; 
        #endregion

        #region Builder
        public UserController(IUserServices userServices, IRolServices rolServices)
        {
            _userServices = userServices;
            _rolServices = rolServices;
        } 
        #endregion

        #region Views
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _userServices.GetallUser(token);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(InsertUserDto user)
        {
            var users = HttpContext.User;
            string token = users.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _userServices.InsertUser(token, user);
            return Ok(response);


        }
        #endregion

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            var users = HttpContext.User;
            string token = users.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _userServices.UpdateUser(token, user);
            return Ok(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(UserEntity user)
        //{
        //    IActionResult response;

        //    bool result = await _userServices.UpdateUser(user);
        //    if (result)
        //    {
        //        response = RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "No se pudo actualizar el usuario");
        //        response = RedirectToAction(nameof(Index));
        //    }

        //    return response;
        //}


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _userServices.DeleteUser(token, Convert.ToString(idUser));
            return Ok(response);
        }


    }
}
