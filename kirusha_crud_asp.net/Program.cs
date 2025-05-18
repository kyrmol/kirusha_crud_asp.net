using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using kirusha_crud_asp.net.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<kirusha_crud_aspnetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("kirusha_crud_aspnetContext") ?? throw new InvalidOperationException("Connection string 'kirusha_crud_aspnetContext' not found.")));

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

app.Run();
