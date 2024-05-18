using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.Mapper;
using KeuzeWijzerApi.Repositories;
using KeuzeWijzerApi.Repositories.Interfaces;
using KeuzeWijzerApi.Services;
using KeuzeWijzerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi()
        .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
        .AddInMemoryTokenCaches();

// Fix recursive lookups
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    string? tenantId = builder.Configuration.GetSection("AzureAd").GetValue<string>("TenantId");
    string? clientId = builder.Configuration.GetSection("AzureAd").GetValue<string>("ClientId");

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "KeuzeWijzerApi", Version = "V1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize"),
                TokenUrl = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token"),
                Scopes = new Dictionary<string, string> {
                    { $"api://keuzewijzer/All", "Do everything" }
                }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


// Use the DB_CONNECTION_STRING envvar from our docker pipeline, otherwise default to local sqlite
// Tip: Using a different database provider also means you need to run from a different migration file due to column type differences between sqlite and sql server
// Tip 2: If testing by setting an envvar locally while running this project, restart VS first! 
if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")))
{
    var dbstring = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    builder.Services.AddDbContext<KeuzeWijzerContext>(options =>
      options.UseSqlServer(dbstring));
}
else
{
    builder.Services.AddDbContext<KeuzeWijzerContext>(options =>
       options.UseSqlite(builder.Configuration.GetConnectionString("DeveloptmentConnection")));
}


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost",
            "https://localhost",
            "https://*.hbo-ict.dev");
    });
});

// Add Automapper profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services
    .AddScoped<IModuleRepo, ModuleRepo>()
    .AddScoped<ISchoolYearRepo, SchoolYearRepo>()
    .AddScoped<IAppUserService, AppUserService>()
    .AddScoped<IAppUserRepo, AppUserRepo>()
    .AddScoped<IAppUserService, AppUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthAppName("Swagger client");
        options.OAuthClientId(builder.Configuration.GetSection("AzureAd").GetValue<string>("ClientId"));
        options.OAuthClientSecret(builder.Configuration.GetSection("AzureAd").GetValue<string>("ClientSecret"));
        options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
