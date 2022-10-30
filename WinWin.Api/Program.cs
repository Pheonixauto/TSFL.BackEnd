using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WinWin.Api.Data;
using WinWin.Api.IRepositories;
using WinWin.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Cors
builder.Services.AddCors(options=> options.AddDefaultPolicy(policy=> policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Add Connect to DB
builder.Services.AddIdentity<WinwinUser, IdentityRole>().AddEntityFrameworkStores<WinWinContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<WinWinContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WinWinConnectionString"));
});

//Register Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Life Cycle DI :
builder.Services.AddScoped<ICardsRepository, CardsRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Add auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
}).
AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience=true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))

    };
});

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

app.Run();
