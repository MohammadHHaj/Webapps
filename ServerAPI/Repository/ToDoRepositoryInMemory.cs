using System.Collections.Generic;
using Core;

namespace ServerAPI.Repository
{
    public class ToDoRepositoryInMemory : IToDoRepository
    {
        private static List<ToDoItem> taskList = new()
        {
            new ToDoItem { Title = "Lave lektier", IsDone = false },
            new ToDoItem { Title = "Købe mælk", IsDone = false },
            new ToDoItem { Title = "Rydde op", IsDone = true }
        };

        public void Add(ToDoItem task)
        {
            taskList.Add(task);
        }

        public ToDoItem[] GetAll()
        {
            return taskList.ToArray();
        }

        public void Remove(ToDoItem task)
        {
            taskList.Remove(task);
        }


        public void Update(ToDoItem updatedItem)
        {
            var existingItem = taskList.FirstOrDefault(t => t.Title == updatedItem.Title);
            if (existingItem != null)
            {
                int index = taskList.IndexOf(existingItem);
                taskList[index] = updatedItem;
            }
        }
    }
}