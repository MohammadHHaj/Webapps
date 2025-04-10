using ServerAPI.Repository;

namespace ServerAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<IToDoRepository, ToDoRepositoryMongodb>();
        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("policy",
                policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
        });


        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseCors("policy");
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}