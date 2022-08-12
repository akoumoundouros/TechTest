using Microsoft.AspNetCore.Authentication.Negotiate;
using TechTest.Components;
using TechTest.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});




builder.Services.AddScoped<IProductRepository, ProductRepository>();

AppConfig settings = builder.Configuration.GetSection("AppConfig").Get<AppConfig>();
builder.Services.AddSingleton(settings);

// Add SQLite DbContext
builder.Services.AddSqlite<TechTest.Data.TTContext>(builder.Configuration.GetConnectionString("Default"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
