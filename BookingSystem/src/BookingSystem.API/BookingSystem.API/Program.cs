
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Persistance;
using BookingSystem.Infrastucture;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using BookingSystem.Application;

namespace BookingSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

         //   builder.Services.AddApplication(builder.Environment);
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDataAccess(builder.Configuration);
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "User"));
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Admin"));
            });
            builder.Services.AddHttpContextAccessor();
            var env = builder.Environment;

            builder.Services.AddApplication();

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
