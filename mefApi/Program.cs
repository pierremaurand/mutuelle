using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mefApi.Data;
using mefApi.Helpers;
using mefApi.Interfaces;
using mefApi.Middlewares;
using mefApi.HubConfig;

var builder = WebApplication.CreateBuilder(args);

// Use WebApplicationBuilder.Configuration directly instead of ConfigureHostConfiguration
var secretKey = builder.Configuration.GetSection("AppSettings:Key").Value;
if (string.IsNullOrEmpty(secretKey))
{
    throw new InvalidOperationException("The secret key cannot be null or empty. Please check the configuration.");
}
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
builder.Configuration.AddEnvironmentVariables(prefix: "MEF_");

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var conBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("Default")
);
conBuilder.Password = builder.Configuration.GetSection("DBPassword").Value;
var connectionString = conBuilder.ConnectionString;

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapHub<SignalrServer>("/signalrServer");

app.Run();
