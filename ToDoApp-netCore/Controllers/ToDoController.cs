using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp_netCore.Model;
using ToDoApp_netCore.Service;

namespace ToDoApp_netCore.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        // GET api/todo
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _todoService.GetToDo();
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _todoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(item);
            }
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var result = _todoService.Add(item);
            if (result > 0)
            {
                return new JsonResult(new { Success= true});
            }
            else
            {
                return new JsonResult(new { Success = false });
            }
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TodoItem item)
        {
            var existingItem = _todoService.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            else
            {
                existingItem.Name = item.Name;
                existingItem.IsComplete = item.IsComplete;
                var result = _todoService.Update(existingItem);
                if (result > 0)
                {
                    return new JsonResult(new { Success = true });
                }
                else
                {
                    return new JsonResult(new { Success = false });
                }
            }
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _todoService.GetById(id);
            if(item == null)
            {
                return NotFound();
            }
            else
            {
                var result = _todoService.Delete(item);
                if (result > 0)
                {
                    return new JsonResult(new { Success = true });
                }
                else
                {
                    return new JsonResult(new { Success = false });
                }
            }
        }
    }
}
