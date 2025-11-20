using BLL;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IPantherTypeRepo, PantherTypeRepo>();
builder.Services.AddScoped<IPantherProfileRepo, PantherProfileRepo>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPantherTypeService, PantherTypeService>();
builder.Services.AddScoped<IPantherProfileService, PantherProfileService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
            );

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
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/Login");
        return;
    }
    await next();
});

app.Run();
