using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using kirusha_crud_asp.net.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<kirusha_crud_aspnetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("kirusha_crud_aspnetContext") ?? throw new InvalidOperationException("Connection string 'kirusha_crud_aspnetContext' not found.")));

var app = builder.Build();


//services.Configure<CookiePolicyOptions>(options =>
//{
//    options.CheckConsentNeeded = context => false; // Для разработки
//    options.MinimumSameSitePolicy = SameSiteMode.Lax;
//    options.Secure = CookieSecurePolicy.SameAsRequest; // Вместо Always
//});

//services.ConfigureApplicationCookie(options =>
//{
//    options.SameSite = SameSiteMode.Lax;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//});
//}

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
