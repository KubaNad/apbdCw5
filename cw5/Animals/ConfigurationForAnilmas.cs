namespace WebApplication1.Animals;

public static class ConfigurationForAnimals
{
    public static void RegisterEndpointsForAnimals(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/animals", (IAnimalService service, string orderBy = "name") => 
            Results.Ok(service.GetAnimals(orderBy)));

        app.MapGet("/api/animals/{id}", (int id, IAnimalService service) => 
            service.GetAnimalById(id) is Animal animal ? Results.Ok(animal) : Results.NotFound());

        app.MapPost("/api/animals", (Animal animal, IAnimalService service) => 
            Results.Created($"/api/animals/{animal.Id}", service.AddAnimal(animal)));

        app.MapPut("/api/animals/{id}", (int id, Animal updateAnimal, IAnimalService service) => 
            service.UpdateAnimal(id, updateAnimal) is Animal animal ? Results.Ok(animal) : Results.NotFound());

        app.MapDelete("/api/animals/{id}", (int id, IAnimalService service) => 
            service.DeleteAnimal(id) ? Results.NoContent() : Results.NotFound());
    }
}