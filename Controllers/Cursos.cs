using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primer_proyecto.DataAcces;
using Primer_proyecto.Models.DataModels;

namespace Primer_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cursos : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ILogger<Cursos> _logger;

        public Cursos(UniversityDBContext context, ILogger<Cursos> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            _logger.LogInformation($"{nameof(Cursos)} - {nameof(GetCursos)} Info Level Log");

            if (_context.Cursos == null)
            {
                return NotFound();
            }
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            _logger.LogInformation($"{nameof(Cursos)} - {nameof(GetCurso)} Info Level Log");

            if (_context.Cursos == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            _logger.LogInformation($"{nameof(Cursos)} - {nameof(PutCurso)} Info Level Log");

            if (id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogError($"{nameof(Cursos)} - {nameof(PutCurso)} Info Level Log");

                if (!CursoExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _logger.LogInformation($"{nameof(Cursos)} - {nameof(PostCurso)} Info Level Log");

            if (_context.Cursos == null)
            {
                return Problem("Entity set 'UniversityDBContext.Cursos'  is null.");
            }
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.Id }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            _logger.LogInformation($"{nameof(Cursos)} - {nameof(DeleteCurso)} Info Level Log");

            if (_context.Cursos == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int id)
        {
            return (_context.Cursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
