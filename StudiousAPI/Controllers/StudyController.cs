using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudiousAPI.Models;
using StudiousAPI.Services;

namespace StudiousAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudyController(ApplicationDbContext _context)
        {
            this._context = _context;
        }


        [HttpGet("StudySet")]
        public async Task<ActionResult> StudySet(string email, string set)
        {
            List<StudySet> studySet = await _context.FlashCards
                .Where(s => s.USERNAME == email && s.STUDYSET_NAME == set)
                .ToListAsync();


            return Ok(studySet);
        }

    }
}
