using ConsoleApi.Models;
using ConsoleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsoleApi.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class ConsolesController : ControllerBase {

        private readonly ConsolesService _consolesService;

        public ConsolesController(ConsolesService consolesService){
            _consolesService = consolesService; 
        }

        [HttpGet]
        public ActionResult<List<Console>> Get(){
            return _consolesService.Get();
        }

        [HttpPost]
        public ActionResult<Console> Post(Console console){
            _consolesService.Create( console );
            return console;
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id){
            var console = _consolesService.Get( id );

            if( console == null){
                return NotFound();
            }

            _consolesService.Remove( console.Id );
            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, Console consoleIn){
            var selectedConsole = _consolesService.Get(id);

            if( selectedConsole == null){
                return NotFound();
            }

            _consolesService.Update( id, consoleIn );
            return NoContent();
        }

    }
}