using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TodoController(TodoContext context, IMapper mapper)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
            _mapper = mapper;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItem()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }


        // AddShapeDto
        // PastShapeDto
        // 10 other dtos for post operation

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemDto todoDtoItem)
        {
            // First transform the input dto to backend cmd
            var todoItemEngineCmd = _mapper.Map<string>(todoDtoItem);

            Console.WriteLine(
                ">>>>>>>>>>>>>>>>>>>>>>>>>>> DTO transformed into a backend string command"
            );
            Console.WriteLine(todoItemEngineCmd);

            // Next transform the same dto to todoitem so that it be saved in db
            var todoItem = _mapper.Map<TodoItem>(todoDtoItem);
            _context.TodoItems.Add(todoItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);

            // Think about data transformations between versions 
        }


        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(PocDto todoDtoItem)
        {
            // First transform the input dto to backend cmd
            var todoItemEngineCmd = _mapper.Map<string>(todoDtoItem);

            Console.WriteLine(
                ">>>>>>>>>>>>>>>>>>>>>>>>>>> DTO transformed into a backend string command"
            );
            Console.WriteLine(todoItemEngineCmd);

            // Next transform the same dto to todoitem so that it be saved in db
            var todoItem = _mapper.Map<TodoItem>(todoDtoItem);
            _context.TodoItems.Add(todoItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);

            // Think about data transformations between versions 
        }
    }
}
