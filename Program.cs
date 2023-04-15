// 1. agreagar uso de EntityFrameworkCore

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Primer_proyecto;
using Primer_proyecto.DataAcces;
using Primer_proyecto.Services;

var builder = WebApplication.CreateBuilder(args);

//2. Conexcion con la base de datos
string CONNECTIONNAME = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. add Context-- agregar el contexto de servicio al builder

builder.Services.AddDbContext<UniversityDBContext>(options =>
options.UseNpgsql(connectionString));



// 7. add Services of JWT Authorization
builder.Services.AddJwtTokenServices(builder.Configuration);

// Localizacion
builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// 4. Agregar los servicios despues de los controladores
builder.Services.AddScoped<IStudentService, StudentService>();

// 8. Agregar Autorizacion
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

builder.Services.AddEndpointsApiExplorer();

// 9. Configuracion de Swagger para que tome el JWT
builder.Services.AddSwaggerGen(options =>
    {
        // Definimos la Security for authorization
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization Heaer using Bearer Scheme"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
                },
                new string[]{}
            }
        });
    }

);

// 5. Habilitar el cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


/*
    Para usar JWT se deben instalar los siguientes paquetes
    - System.IdentityModel.Tokens.Jwt
    - Microsoft.AspNetCore.Authentication.JwtBearer
    - Microsoft.IdentityModel.JsonWebTokens
*/

var app = builder.Build();

// Suported Cultures
var suportedCultures = new[] { "en-US", "es-ES", "fr-FR", "de-DE" }; // idiomas soportados
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(suportedCultures[0])
    .AddSupportedCultures(suportedCultures)
    .AddSupportedUICultures(suportedCultures);
// Add Localization
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (true)
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 6. Decir a la aplicacion que use los cors
app.UseCors("CorsPolicy");

app.Run();
