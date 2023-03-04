// using System.Net;
// using Microsoft.OpenApi.Models;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Primer_proyecto.DataAcces;
// using Primer_proyecto.Univer;

var builder = WebApplication.CreateBuilder(args);

//Conexcion con la base de datos
string CONNECTIONNAME = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// add Context

builder.Services.AddDbContext<UniversityDBContext>(options =>
options.UseNpgsql(connectionString));







// await using var conn = new NpgsqlConnection(connectionString);
// await conn.OpenAsync();
// //consulta a  base de datos
// await using (var cmd = new NpgsqlCommand("SELECT first_name FROM actor LIMIT 10;", conn))
// await using (var reader = await cmd.ExecuteReaderAsync())
// {
//     while (await reader.ReadAsync())
//         Console.WriteLine(reader.GetString(0));
// }



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddHttpsRedirection(
//     options =>
// {
//     options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
//     options.HttpsPort = 5001;
// }
// );

builder.Services.AddSwaggerGen();

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
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
