using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api_intro.Controllers
{                               //Action bueada yazildiqda diger metodlarin uzerinde yazilmir // 
                               // Burada yazilmadiqda ancaq uzerinde yazildigi metodu gosterir///
[Route("api/[controller]/[action]")]
    [ApiController]          //ControllerBase  (return View) yazmaq olmur ancaq (Return Ok,NotFound,BadReguest) yazmaq olur API-da  //
    public class EmployeeController : ControllerBase
    {
        [HttpGet]    //mutleq sekilde yazilmalidir 
        public IActionResult GetAll()
        {
            string[] names = {"Eli","Jale","Pervin"};
            return Ok (names);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int? id)
        {
            if(id == null) return BadRequest();
            return Ok("Eli - " + " " + id);
        }

    }
}
