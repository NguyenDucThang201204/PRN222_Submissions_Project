using Microsoft.EntityFrameworkCore;
using PantherPetManagement.Repository;
using PantherPetManagement.Repository.Models;
using PantherPetManagement.Service;

namespace PantherPetManagement_PhanKhanhDuong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IPantherProfileRepo, PantherProfileRepo>();
            builder.Services.AddScoped<IPantherTypeRepo, PantherTypeRepo>();

            builder.Services.AddScoped<IPantherAccountRepo, PantherAccountRepo>();
            builder.Services.AddScoped<IPantherProfileService, PantherProfileService>();
            builder.Services.AddScoped<IPantherAccountService, PantherAccountService>();
            builder.Services.AddScoped<IPantherTypeService, PantherTypeService>();
            
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
                options.Cookie.HttpOnly = true; // For security
                options.Cookie.IsEssential = true; // Ensure session cookie is always created
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
