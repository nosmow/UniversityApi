//1. USing to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using universityApiBackend.DataAccess;

namespace universityApiBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //2. Conenection with SQL Server Developer
            const string CONNECTIONNAME = "UniversityDB";
            var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

            //3. Add Context
            builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
