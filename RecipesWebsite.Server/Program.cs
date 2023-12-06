using MongoDB.Driver;
using RecipesWebsite.Server.Models;
using System;


string connectionString = "mongodb://127.0.0.1:27017";
string databaseName = "recipes_db";
string collectionName = "recipes";
var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<RecipesModel>(collectionName);
var builder = WebApplication.CreateBuilder(args);

var recipesTest = new RecipesModel {RecipeName = "Pizza", Description = "Test"};

await collection.InsertOneAsync(recipesTest);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoCollection<RecipesModel>>(collection);
builder.Services.AddCors(x=>x.AddDefaultPolicy(y=>y.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
