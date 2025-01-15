using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentConnectionAssignment.Server.Data;
using PresentConnectionAssignment.Server.Data.Models;
using System.Diagnostics;

namespace PresentConnectionAssignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradingController : ControllerBase
    {
        private readonly DBContext _context;

        public GradingController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TestGrader>> PostUnsolvedTest([FromBody] TestGrader testGrader)
        {
            if (testGrader == null)
            {
                return BadRequest("Testee data is required.");
            }

            await calculateScore(testGrader); 
            return Ok();
        }

        private async Task calculateScore(TestGrader testGrader)
        {
            
            Console.WriteLine("Calculating score...");

            float score = 0;

            foreach (var item in testGrader.FormData)
            {
               
                if (Guid.TryParse(item.Key, out Guid questionId))
                {
                   
                    var testEntry = await _context.Test.FindAsync(questionId);
                    int matchCount = item.Value.Count(value => testEntry.QuestionAnswer.Contains(value, StringComparer.OrdinalIgnoreCase));
                   
                    if(testEntry.QuestionType == "CheckBox")
                    {
                        if((matchCount == item.Value.Count) && (matchCount <= testEntry.QuestionAnswer.Count)) score += (float)Math.Ceiling((100 / (float)testEntry.QuestionAnswer.Count) * matchCount);

                    }
                    else
                    {
                        if (matchCount == 1) score+= 100;
                    }
                } 
            }
            Console.WriteLine(score);

            _context.Testees.Add(new Testee
            {
                Email = testGrader.UserEmail,
                Score = (int)score,
                Date = DateTime.Now,
               
            });
            await _context.SaveChangesAsync();

        }
    }
}