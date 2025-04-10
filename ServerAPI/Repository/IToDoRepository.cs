using System.Collections.Generic;
using Core;

namespace ServerAPI.Repository
{
    public interface IToDoRepository
    {
        ToDoItem[] GetAll();
        void Add(ToDoItem item);
        void Remove(ToDoItem item);

        void Update(ToDoItem item);
    }
}