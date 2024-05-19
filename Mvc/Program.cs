using KeuzeWijzerCore.Models;
using KeuzeWijzerMvc.Services;
using KeuzeWijzerMvc.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("ApiClient");
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IService<SchoolModuleDto>, Service<SchoolModuleDto>>();
builder.Services.AddScoped<IService<SchoolYearDto>, Service<SchoolYearDto>>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
