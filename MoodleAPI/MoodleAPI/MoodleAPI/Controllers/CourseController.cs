using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoodleAPI.Data;
using MoodleAPI.Models;

namespace Moodle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Courses.ToListAsync());
        }

        // GET: api/Courses/ShowSearchForm
        [HttpGet("ShowSearchForm")]
        public async Task<IActionResult> ShowSearchForm()
        {
            return Ok();
        }

        // POST: api/Courses/ShowSearchResults
        [HttpPost("ShowSearchResults")]
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return Ok(await _context.Courses.Where(j => j.Name.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: api/Courses/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        // POST: api/Courses/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Credit")] Course courses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return Ok(courses);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Courses/Edit/5
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Credit")] Course courses)
        {
            if (id != courses.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesExists(courses.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Courses/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}

