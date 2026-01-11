using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosAPI.DTOs;
using TodosAPI.Models;

namespace TodosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodosContext _context;
        public TodosController(TodosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _context.Todos.Select(t => new TodoDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description ?? "",
                IsCompleted = t.IsCompleted
            }).ToListAsync();

            if (todos.Count == 0)
            {
                return NotFound();
            }

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            var todo = await _context.Todos.Where(t => t.Id == id).Select(t => TodoToDTO(t)).FirstOrDefaultAsync();

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTodo(Todo entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.CreatedDate = DateTime.Now;

            _context.Todos.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodo), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTodo(int id, Todo entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            todo.Id = entity.Id;
            todo.Title = entity.Title;
            todo.Description = entity.Description;
            todo.IsCompleted = entity.IsCompleted;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTodo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }


        public static TodoDTO TodoToDTO(Todo p)
        {
            var entity = new TodoDTO();
            if (p != null)
            {
                entity.Id = p.Id;
                entity.Title = p.Title;
                entity.Description = p.Description ?? "";
                entity.IsCompleted = p.IsCompleted;
            }

            return entity;
        }
    }
}
