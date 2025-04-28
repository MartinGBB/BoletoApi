using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração DB
DotNetEnv.Env.Load();
string? connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("A variável de ambiente DATABASE_CONNECTION_STRING não foi definida.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Serviços
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IBancoService, BancoService>();

builder.Services.AddControllers();

// Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();