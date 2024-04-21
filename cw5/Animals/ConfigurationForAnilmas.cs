namespace WebApplication1.Animals;

public static class ConfigurationForAnilmas
{
    public static void RegisterEndpointsForAnimals(this IEndpointRouteBuilder app)
    {
        app.MapGet("/animals", (IAnimalsService service) => service.GetAnimals());
        app.MapGet("/animals/{id}", (int id, IAnimalsService service) => 
            service.GetAnimalById(id) is Animal animal ? Results.Ok(animal) : Results.NotFound());
        app.MapPost("/animals", (Animal animal, IAnimalsService service) => 
            Results.Created($"/animals/{animal.Id}", service.AddAnimal(animal)));
        app.MapPut("/animals/{id}", (int id, Animal updateAnimal, IAnimalsService service) => 
            service.UpdateAnimal(id, updateAnimal) is Animal animal ? Results.Ok(animal) : Results.NotFound());
        app.MapDelete("/animals/{id}", (int id, IAnimalsService service) => {
            service.DeleteAnimal(id);
            return Results.Ok();
        });

        // app.MapGet("/api/animals", (IAnimalsService service) => Results.Ok(service.GetAnimals()))
        //     .WithName("GetAnimals")
        //     .WithOpenApi();
        //
        // app.MapGet("/api/animals/{id:int}", (int id, IAnimalsService service) => 
        //     {
        //         var animal = service.GetAnimalById(id);
        //         return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
        //     })
        //     .WithName("GetAnimal")
        //     .WithOpenApi();
        //
        // app.MapPost("/api/animals", (Animal animal, IAnimalsService service) => 
        //     {
        //         service.AddAnimal(animal);
        //         return Results.Created($"/api/animals/{animal.Id}", animal);
        //     })
        //     .WithName("CreateAnimal")
        //     .WithOpenApi();
        //
        // app.MapPut("/api/animals/{id:int}", (int id, Animal updateAnimal, IAnimalsService service) => 
        //     {
        //         var animalToUpdate = service.GetAnimalById(id);
        //         if (animalToUpdate == null)
        //         {
        //             return Results.NotFound($"Animal with id {id} was not found");
        //         }
        //         service.UpdateAnimal(id, updateAnimal);
        //         return Results.Ok(updateAnimal);
        //     })
        //     .WithName("UpdateAnimal")
        //     .WithOpenApi();
        //
        // app.MapDelete("/api/animals/{id:int}", (int id, IAnimalsService service) => 
        //     {
        //         if (service.GetAnimalById(id) == null)
        //         {
        //             return Results.NotFound($"Animal with id {id} was not found");
        //         }
        //         service.DeleteAnimal(id);
        //         return Results.NoContent();
        //     })
        //     .WithName("DeleteAnimal")
        //     .WithOpenApi();
    }
}