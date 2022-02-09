﻿using Infraestructure.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Domain.Services.Interface;
using MyVet.Handler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRolServices _rolServices;

        public UserController(IUserServices userServices, IRolServices rolServices)
        {
            _userServices = userServices;
            _rolServices = rolServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserEntity> users = _userServices.GetAll();

            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            IActionResult response;

            if (Id == null)
                response = NotFound();

            UserEntity user = _userServices.GetUser((int)Id);
            if (user == null)
                response = NotFound();
            else
            {
                response = View(user);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEntity user)
        {
            IActionResult response;

            bool result = await _userServices.UpdateUser(user);
            if (result)
            {
                response = RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No se pudo actualizar el usuario");
                response = RedirectToAction(nameof(Index));
            }

            return response;
        }


        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            IActionResult response;

            if (Id == null)
                response = NotFound();

            UserEntity user = _userServices.GetUser((int)Id);
            if (user == null)
                response = NotFound();
            else
            {
                response = View(user);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int IdUser)
        {
            IActionResult response;
            if (IdUser == 0)
                response = NotFound();

            else
            {
                bool result = await _userServices.DeleteUser(IdUser);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo eliminar el usuario");
                    response = RedirectToAction(nameof(Index));
                }
            }

            return response;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Roles"] = new SelectList(_rolServices.GetAll(), "IdRol", "Rol");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(UserEntity user)
        {
            IActionResult response;

            var result = await _userServices.CreateUser(user);
            if (result.IsSuccess)
            {
                response = RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Roles"] = new SelectList(_rolServices.GetAll(), "IdRol", "Rol");
                ModelState.AddModelError(string.Empty, result.Message);
                response = View(user);
            }
            return response;
        }

    }
}
