
using DemoClasswork1.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add session

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind") ?? throw new InvalidOperationException("Connection string 'Northwind' not found."))); 

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

app.UseSession();

app.MapRazorPages();

app.Run();
