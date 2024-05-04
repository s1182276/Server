using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.Mapper;
using KeuzeWijzerApi.Repositories;
using KeuzeWijzerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<KeuzeWijzerContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("DeveloptmentConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost",
                                              "https://localhost",
                                              "https://*.hbo-ict.dev");
                      });
});

// Add Automapper profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IModuleRepo, ModuleRepo>();
builder.Services.AddScoped<ISchoolYearRepo, SchoolYearRepo>();

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
app.UseCors(MyAllowSpecificOrigins);

app.Run();
