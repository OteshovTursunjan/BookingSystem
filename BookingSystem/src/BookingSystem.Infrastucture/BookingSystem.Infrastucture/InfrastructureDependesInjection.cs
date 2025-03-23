﻿using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Persistance;
using BookingSystem.Infrastucture.Repository;
using BookingSystem.Infrastucture.Repository.lmpl;
using BookingSystem.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastucture;

public static  class InfrastructureDependesInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddIdentity();

        services.AddRepositories();

        return services;
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IPayment,PaymentRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IClaimService , ClaimService>();
    }



    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

        if (databaseConfig.UseInMemoryDatabase)
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("BookingSystem");
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
        else
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(databaseConfig.ConnectionString,
                    opt => opt.MigrationsAssembly("BookingSystem.Infrastucture")));  // Убедитесь, что здесь указана правильная сборка миграций
    }
    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }
}
public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public string ConnectionString { get; set; }
}
