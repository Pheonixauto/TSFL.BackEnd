using FluentValidation.AspNetCore;
using TSFL.Application.Validators.Cards;
using TSFL.Infrastructure.Filters;
using TSFL.Persistance;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

ConfigurationManager configurationManager = builder.Configuration;

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200",
                                                  "https://localhost:4200")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

// Add services to the container.

builder.Services.IAddServicePersistance(configurationManager);
//builder.Services.AddServicePersistance();


builder.Services.AddControllers(option=>option.Filters.Add<ValidationFilter>())
    .AddFluentValidation(config=>config.RegisterValidatorsFromAssemblyContaining<CreateCardValidator>())
    .ConfigureApiBehaviorOptions(option=>option.SuppressModelStateInvalidFilter=true);

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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
