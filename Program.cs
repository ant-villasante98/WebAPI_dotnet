// 1. agreagar uso de EntityFrameworkCore

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NpgsqlTypes;
using Primer_proyecto;
using Primer_proyecto.DataAcces;
using Primer_proyecto.Services;

// 10. Use Serilog to log events
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);


IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
{
    {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
    {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
    {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
    {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
    {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
    {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
    {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
    {"machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
};

//2. Conexcion con la base de datos
string CONNECTIONNAME = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//11. Config Serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf
        .WriteTo.Console()
        .WriteTo.Debug()
        .WriteTo.PostgreSQL(connectionString, "Logs", columnWriters, restrictedToMinimumLevel: LogEventLevel.Warning,
            needAutoCreateTable: true,
            respectCase: true,
            useCopy: false)
        .ReadFrom.Configuration(hostBuilderCtx.Configuration);
});
// 3. add Context-- agregar el contexto de servicio al builder

builder.Services.AddDbContext<UniversityDBContext>(options =>
options.UseNpgsql(connectionString));



// 7. add Services of JWT Authorization
builder.Services.AddJwtTokenServices(builder.Configuration);

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

// Configure the HTTP request pipeline.
if (true)
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}
// 12. Tell app to use Serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 6. Decir a la aplicacion que use los cors
app.UseCors("CorsPolicy");

app.Run();
