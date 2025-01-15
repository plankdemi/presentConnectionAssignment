using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentConnectionAssignment.Server.Data;
using PresentConnectionAssignment.Server.Data.Models;


namespace PresentConnectionAssignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteeController : ControllerBase
    {
        private readonly DBContext _context;

   
        public TesteeController(DBContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<List<Testee>>> GetTestees()
        {
                     

            var testees = await _context.Testees
                                .OrderByDescending(t => t.Score)
                                .Take(10) 
                                .ToListAsync();


            if (testees == null || testees.Count == 0)
            {
                return NotFound("No testees found.");
            }

            return Ok(testees);
        }


       

    }
}