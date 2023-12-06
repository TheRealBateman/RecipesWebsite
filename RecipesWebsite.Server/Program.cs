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

var recipesTest = new RecipesModel
{
    RecipeName = "Caramelised Potato Bake",
    Description = "Drizzled with golden syrup, this creamy, cheesy potato bake is like nothing you've ever tasted before.",
    Ingredients = new List<string> { "1.25kg white potatoes, peeled, thinly sliced ", "1 brown onion, thinly sliced", "1 cup grated 3 cheese blend", "2 garlic cloves, crushed ",
    "2 tsp finely chopped fresh thyme ", "300ml thickened cream ", "1/4 cup golden syrup ", "Extra fresh thyme sprigs, to serve "},
    Directions = new List<string> { "Preheat oven to 200C/180C fan-forced.", "Grease an 5cm-deep, 21cm x 27cm baking dish. Place potato, onion, cheese, garlic and thyme in a large bowl. Season well with salt and pepper. Toss to combine.",
    "Layer half the potato mixture in prepared pan. Pour over half of the cream. Repeat with remaining potato mixture and cream. Cover dish with baking paper, then tightly in foil. Bake for 50 minutes or until potato is just tender.",
    "Carefully remove foil and baking paper. Bake for a further 15 minutes or until top is golden. Drizzle with golden syrup. Bake for a further 15 minutes or until top is caramelised and potato is tender. Stand 10 minutes. Serve sprinkled with extra thyme sprigs and sea salt flakes."}
};

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
