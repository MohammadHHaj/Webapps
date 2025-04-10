using Core;

namespace Blazor1.Service;

public interface TodoService
{
    Task<ToDoItem[]> GetAll();
    Task Add(ToDoItem item);
    Task Remove(ToDoItem item);
    Task Update(ToDoItem item);
}