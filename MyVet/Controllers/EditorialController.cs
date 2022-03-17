using Common.Utils.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
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
    public class EditorialController : Controller
    {
        #region Attribute
        private readonly IEditorialService _editService;

        #endregion

        #region Builder
        public EditorialController(IEditorialService editService)
        {
            _editService = editService;
        }
        #endregion

        #region Views
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetAllEditorial()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editService.GetAllEditorial(token);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEditorial(EditorialDto edit)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editService.InsertEditorialAsync(token, edit);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEditorial(EditorialDto edit)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editService.UpdateEditorialAsync(token, edit);
            return Ok(response);

            //bool response = await _dateService.UpdateDateAsync(dates);
            //return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editService.DeleteEditorialAsync(token, Convert.ToString(id));
            return Ok(response);

            //ResponseDto response = await _dateService.DeleteDateAsync(id);
            //return Ok(response);
        }
        #endregion
    }
}
