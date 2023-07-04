using TechStoreApi.Application.Interfaces;
using TechStoreApi.Application.Services;
using TechStoreApi.Domain.Interfaces;
using TechStoreApi.Infraestructure.Connections;
using TechStoreApi.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DATABASE CONFIGURATION
string DbDataBase = builder.Configuration.GetValue<string>("ConnectionStrings:Database");
string DbServer = builder.Configuration.GetValue<string>("ConnectionStrings:Server");
string DbUser = builder.Configuration.GetValue<string>("ConnectionStrings:User");
string DbPassword = builder.Configuration.GetValue<string>("ConnectionStrings:Password");
int DbTimeout = builder.Configuration.GetValue<int>("ConnectionStrings:Timeout");
string connectionString = DatabaseConnection.SetConnectionString(DbServer, DbDataBase, DbUser, DbPassword);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBuilderRepository, BuilderRepository>(b => new BuilderRepository(connectionString));
builder.Services.AddSingleton<IProductRepository, ProductRepository>(p => new ProductRepository(connectionString));
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<BuilderService>();

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
