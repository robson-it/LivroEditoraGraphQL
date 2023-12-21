using APIGraphQLHotChocolate.src.Api;
using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create;
using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read;
using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Create;
using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Read;
using APIGraphQLHotChocolate.src.BusinessRules.Validators;
using APIGraphQLHotChocolate.src.BusinessRules.Validators.Abstractions;
using APIGraphQLHotChocolate.src.Database;
using APIGraphQLHotChocolate.src.Database.Repositories;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ContextDB>(options =>
                    options.UseSqlServer(connectionString)
                );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IEditoraRepository, EditoraRepository>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

builder.Services.AddScoped<IEditoraValidator, EditoraValidator>();
builder.Services.AddScoped<IEstoqueValidator, EstoqueValidator>();
builder.Services.AddScoped<ILivroValidator, LivroValidator>();

builder.Services.AddScoped<IEditoraReadHandler, EditoraReadHandler>();
builder.Services.AddScoped<IEstoqueReadHandler, EstoqueReadHandler>();
builder.Services.AddScoped<ILivroReadHandler, LivroReadHandler>();

builder.Services.AddScoped<IEditoraCreateHandler, EditoraCreateHandler>();
builder.Services.AddScoped<IEstoqueCreateHandler, EstoqueCreateHandler>();
builder.Services.AddScoped<ILivroCreateHandler, LivroCreateHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContextDB>();
    dbContext.Database.EnsureCreated();
}

app.UseAuthorization();

app.MapGraphQL();

app.MapControllers();

app.Run();
