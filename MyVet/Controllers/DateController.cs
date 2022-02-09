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

namespace MyVet.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class DateController : Controller
    {
        #region Attribute
        private readonly IDateService _dateService;

        #endregion

        #region Builder
        public DateController(IDateService dateService)
        {
            _dateService = dateService;
        }
        #endregion

        #region Views
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DateVet()
        {
            return View();
        }
        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetAllDates()
        {
            var user = HttpContext.User;
            string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

            List<DateDto> list = _dateService.GetAllDates(Convert.ToInt32(idUser));
            return Ok(list);
        }

        [HttpGet]
        public IActionResult GetAllMyDates()
        {
            var user = HttpContext.User;
            string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

            List<DateDto> list = _dateService.GetAllMyDates(Convert.ToInt32(idUser));
            return Ok(list);
        }

        [HttpGet]
        public IActionResult GetAllMyService()
        {
            List<ServiceDto> response = _dateService.GetAllMyService();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertDate(DateDto dates)
        {
            //var user = HttpContext.User;
            //string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;
            //dates.idUser = Convert.ToInt32(idUser);

            bool response = await _dateService.InsertDateAsync(dates);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDate(DateDto dates)
        {
            bool response = await _dateService.UpdateDateAsync(dates);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDate(int id)
        {
            ResponseDto response = await _dateService.DeleteDateAsync(id);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> CancelDates(int id)
        {
            bool response = await _dateService.CancelDateAsync(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDateVet(DateDto dates)
        {
            bool response = await _dateService.UpdateDateVetAsync(dates);
            return Ok(response);
        }
        #endregion
    }
}
