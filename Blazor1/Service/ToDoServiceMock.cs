using Core;

namespace Blazor1.Service;

public class ToDoServiceMock : TodoService
{
    private List<ToDoItem> mitems = new();

    public async Task<ToDoItem[]> GetAll()
    {
        return mitems.ToArray();
    }

    public async Task Add(ToDoItem item)
    {
        int max = 0;
        if (mitems.Count > 0)
            max = mitems.Select(b => b.Id).Max();
        item.Id = max + 1;
        mitems.Add(item);
    }

    public async Task Remove(ToDoItem item)
    {
        mitems.RemoveAll(x => x.Id == item.Id);
    }

    public async Task Update(ToDoItem item)
    {
        var existingItem = mitems.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            int index = mitems.IndexOf(existingItem);
            mitems[index] = item;
        }
    }
}