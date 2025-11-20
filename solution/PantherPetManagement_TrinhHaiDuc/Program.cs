using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement.BLL.Services;
using PantherPetManagement.DAL;
using PantherPetManagement.DAL.Repositories;

namespace PantherPetManagement_TrinhHaiDuc
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<Su25pantherDbContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPantherAccountRepository, PantherAccountRepository>();
            builder.Services.AddScoped<IPantherProfileRepository, PantherProfileRepository>();
            builder.Services.AddScoped<IPantherTypeRepository, PantherTypeRepository>();
            builder.Services.AddScoped<IPantherAccountService, PantherAccountService>();
            builder.Services.AddScoped<IPantherProfileService, PantherProfileService>();
            builder.Services.AddScoped<IPantherTypeService, PantherTypeService>();
            builder.Services.AddSignalR();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/Error";
                });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Full", policy => policy.RequireRole("2"));
                options.AddPolicy("View", policy => policy.RequireRole("2", "3"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();


            //*
            app.MapHub<HubServer>("/hub");

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Login");
                return Task.CompletedTask;
            });
            //*

            app.Run();
        }
    }
}
