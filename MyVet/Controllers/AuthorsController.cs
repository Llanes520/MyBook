using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    public class AuthorsController : Controller
    {
        #region Atribute
        private readonly IAuthorService _authorsService;
        #endregion

        #region Builder
        public AuthorsController(IAuthorService authorsService)
        {
            _authorsService = authorsService;
        }
        #endregion

        #region Views
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsService.GetAllAuthors(token);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAuthors(AuthorsDto authors)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsService.InsertAuthorAsync(token, authors);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorsDto authors)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsService.UpdateAuthorAsync(token, authors);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthors(int id)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsService.DeleteAuthorAsync(token, Convert.ToString(id));
            return Ok(response);
        }
        #endregion
    }
}
