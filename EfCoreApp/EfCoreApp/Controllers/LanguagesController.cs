using EfCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public LanguagesController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("GetAllLanguages")]
        public async Task<IActionResult> GetLanguages()
        {
            //var res = await appDbContext.Languages.ToListAsync();
            var res = await (from Language in appDbContext.Languages
                             select Language).ToListAsync();

            return Ok(res);
        }


        [HttpGet("GetLanguageById{Id}")]
        public async Task<IActionResult> GetLanguagesById([FromRoute] int Id)
        {
            //FIndAsync is only used to get data by primary key
            var res = await appDbContext.Languages.FindAsync(Id);
            //var res = await (from Language in appDbContext.Languages
            //                 where Language.Id == Id
            //                 select Language).ToListAsync();

            return Ok(res);
        }


        [HttpGet("GetLanguageByName{Name}")]
        public async Task<IActionResult> GetLanguagesByName([FromRoute] string Name)
        {
            // var res = await appDbContext.Languages.Where(x=>x.Title ==Name).FirstOrDefaultAsync();
            var res = await (from Language in appDbContext.Languages
                             where Language.Title == Name
                             select Language).FirstOrDefaultAsync();

            return Ok(res);
        }
    }
}
