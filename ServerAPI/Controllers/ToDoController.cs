using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repository;
using Core;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public void Add([FromBody] ToDoItem task)
        {
            _repo.Add(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var item = _repo.GetAll().FirstOrDefault(t => t.Id == id);
            if (item == null)
                return NotFound("ToDo item not found");

            _repo.Remove(item);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ToDoItem task)
        {
            var existingItem = _repo.GetAll().FirstOrDefault(t => t.Id == id);
            if (existingItem == null)
                return NotFound("ToDo item not found");

            _repo.Update(task);
            return Ok();
        }
    }
}