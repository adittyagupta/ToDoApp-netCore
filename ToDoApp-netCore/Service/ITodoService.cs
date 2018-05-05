using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp_netCore.Database;
using ToDoApp_netCore.Model;

namespace ToDoApp_netCore.Service
{
    public interface ITodoService
    {
        List<TodoItem> GetToDo();

        TodoItem GetById(int Id);

        int Add(TodoItem item);

        int Update(TodoItem item);

        int Delete(TodoItem item);
    }
}
