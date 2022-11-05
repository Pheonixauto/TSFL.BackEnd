using WinWin.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.IAddServicePersistance(builder.Configuration);
builder.Services.IAddDependencyInjection();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
