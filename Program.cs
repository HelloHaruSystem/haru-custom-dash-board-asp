using Microsoft.EntityFrameworkCore;
using PersonalDashBoard.Api.Data;
using PersonalDashBoard.Api.Interfaces;
using PersonalDashBoard.Api.Repositories;
using PersonalDashBoard.Api.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add controllers
builder.Services.AddControllers();

// custom services and repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Register Entity Framework DbContext - SQLite for development, PostgreSQL for production
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<DashboardDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DevelopmentConnection"));
    });
}
else
{
    builder.Services.AddDbContext<DashboardDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ProductionConnection")));
}

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// map controllers
app.MapControllers();

app.Run();