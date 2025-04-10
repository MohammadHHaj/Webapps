using Core;
using MongoDB.Driver;

namespace ServerAPI.Repository;

public class ToDoRepositoryMongodb : IToDoRepository
{
    private IMongoClient client;
    private IMongoCollection<ToDoItem> todoCollection;

    public ToDoRepositoryMongodb()
    {
        // local mongodb
        var mongoUri = "mongodb://localhost:27017/";

        try
        {
            client = new MongoClient(mongoUri);
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem connecting to your " +
                              "Atlas cluster. Check that the URI includes a valid " +
                              "username and password, and that your IP address is " +
                              $"in the Access List. Message: {e.Message}");
            throw;
        }

        // Provide the name of the database and collection you want to use.
        var dbName = "ToDo";
        var collectionName = "ToDoItem";

        todoCollection = client.GetDatabase(dbName)
            .GetCollection<ToDoItem>(collectionName);
    }

    public void Add(ToDoItem item)
    {
        var max = 0;
        if (todoCollection.Count(Builders<ToDoItem>.Filter.Empty) > 0)
        {
            max = MaxId();
        }

        item.Id = max + 1;
        todoCollection.InsertOne(item);
    }

    private int MaxId()
    {
        var highestIdItem = todoCollection
            .Find(Builders<ToDoItem>.Filter.Empty)
            .SortByDescending(b => b.Id)
            .Limit(1).FirstOrDefault();
        return highestIdItem?.Id ?? 0;
    }

    public void Remove(ToDoItem item)
    {
        var deleteResult = todoCollection.DeleteOne(x => x.Id == item.Id);
    }

    public ToDoItem[] GetAll()
    {
        var noFilter = Builders<ToDoItem>.Filter.Empty;
        return todoCollection.Find(noFilter).ToList().ToArray();
    }

    public void Update(ToDoItem item)
    {
        var updateDef = Builders<ToDoItem>.Update
            .Set(x => x.Title, item.Title)
            .Set(x => x.IsDone, item.IsDone)
            .Set(x => x.Id, item.Id);
        todoCollection.UpdateOne(x => x.Id == item.Id, updateDef);
    }
}