using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração DB
DotNetEnv.Env.Load();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

Console.WriteLine($"Connection String: {Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")}");
builder.Services.AddAutoMapper(typeof(Program));

// Serviços
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IBancoService, BancoService>();

builder.Services.AddControllersWithViews();  // MVC

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