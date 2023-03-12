// 1. agreagar uso de EntityFrameworkCore

using Microsoft.EntityFrameworkCore;
using Primer_proyecto.DataAcces;
using Primer_proyecto.Services;

var builder = WebApplication.CreateBuilder(args);

//2. Conexcion con la base de datos
string CONNECTIONNAME = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. add Context-- agregar el contexto de servicio al builder

builder.Services.AddDbContext<UniversityDBContext>(options =>
options.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// 4. Agregar los servicios despues de los controladores
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

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

var app = builder.Build();

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
