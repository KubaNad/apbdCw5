using WebApplication1.Animals;
using WebApplication1.Visits;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAnimalsService, AnimalService>();
builder.Services.AddScoped<IVisitsService, VisitService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterEndpointsForAnimals();
app.RegisterEndpointsForVisits();


app.UseHttpsRedirection();

app.Run();