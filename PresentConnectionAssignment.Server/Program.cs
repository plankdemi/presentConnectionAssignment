using Microsoft.EntityFrameworkCore;
using PresentConnectionAssignment.Server.Data;


namespace PresentConnectionAssignment.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DBContext>(options =>
            {

                options.UseInMemoryDatabase("TestTestees");


            });
  

            builder.Services.AddControllers();

            var app = builder.Build();


            
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
                dbContext.Database.EnsureCreated(); 
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");
            app.Run();
        }
    }
}
