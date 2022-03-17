using Common.Utils.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBook.Domain.Domain.Dto.Books;
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
    public class BookController : Controller
    {
        #region Attribute
        private readonly IBookServices _bookServices;
        #endregion

        #region Buider
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
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
        public async Task<IActionResult> GetAllMyBook()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            //List<ConsultBookDto> list = await _bookServices.GetAllMyBook(token);
            ResponseDto response = await _bookServices.GetAllMyBook(token);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.DeleteBookAsync(token,Convert.ToString(book));
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllEditorial()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.GetAllEditorial(token);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTypeBook()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.GetAllTypeBook(token);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertBook(BookDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.InsertBookAsync(token, book);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookServices.UpdateBookAsync(token, book);
            return Ok(response);
        }
        #endregion

    }
}
