using System.Net.Http.Json;
using Core;

namespace Blazor1.Service;

public class ToDoServiceServer : TodoService
{
    private string serverUrl = "https://localhost:7005";
    private HttpClient client;

    public ToDoServiceServer(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ToDoItem[]> GetAll()
    {
        try
        {
            return await client.GetFromJsonAsync<ToDoItem[]>($"{serverUrl}/api/todo") ?? Array.Empty<ToDoItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching tasks: {ex.Message}");
            return Array.Empty<ToDoItem>();
        }
    }

    public async Task Add(ToDoItem item)
    {
        try
        {
            await client.PostAsJsonAsync($"{serverUrl}/api/todo", item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding task: {ex.Message}");
        }
    }

    public async Task Remove(ToDoItem item)
    {
        try
        {
            await client.DeleteAsync($"{serverUrl}/api/todo/{item.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing task: {ex.Message}");
        }
    }

    public async Task Update(ToDoItem item)
    {
        try
        {
            await client.PutAsJsonAsync($"{serverUrl}/api/todo/{item.Id}", item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating task: {ex.Message}");
        }
    }
}