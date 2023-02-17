using LibraryApplication.Data;
using LibraryApplication.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//takes the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("No connection string found!");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<AuthorService>();
builder.Services.AddTransient<PublisherService>();
builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<RegistrationService>();


//Connection String
builder.Services.AddDbContextFactory<LibraryDbContext>((DbContextOptionsBuilder options) => options.UseSqlServer(connectionString));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
