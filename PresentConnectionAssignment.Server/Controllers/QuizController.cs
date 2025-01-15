
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentConnectionAssignment.Server.Data;
using PresentConnectionAssignment.Server.Data.Models;


namespace PresentConnectionAssignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly DBContext _context;

        
        public QuizController(DBContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<TestQuestion>>> GetTest()
        {
           
            var test = await _context.Test.ToListAsync();

     
            return Ok(test);
        }
    }
}