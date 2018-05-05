using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp_netCore.Database;
using ToDoApp_netCore.Model;

namespace ToDoApp_netCore.Service
{
    public class TodoService:ITodoService
    {
        private readonly TodoContext _dbContext;

        public TodoService(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TodoItem> GetToDo()
        {
            return _dbContext.TodoItems.ToList();
        }

        public TodoItem GetById(int Id)
        {
            return _dbContext.TodoItems.FirstOrDefault(item => item.Id == Id);
        }

        public int Add(TodoItem item)
        {
            _dbContext.TodoItems.Add(item);
            return _dbContext.SaveChanges();
        }

        public int Update(TodoItem item)
        {
            _dbContext.TodoItems.Update(item);
            return _dbContext.SaveChanges();
        }

        public int Delete(TodoItem item)
        {
            _dbContext.TodoItems.Remove(item);
            return _dbContext.SaveChanges();
        }
    }
}
