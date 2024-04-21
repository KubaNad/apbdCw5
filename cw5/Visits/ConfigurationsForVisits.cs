namespace WebApplication1.Visits;


public static class ConfigurationsForVisits
{
    public static void RegisterEndpointsForVisits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/animals/{animalId}/visits", (int animalId, IVisitsService service) => 
            service.GetVisitsForAnimal(animalId));
        app.MapPost("/visits", (Visit visit, IVisitsService service) => 
            Results.Created($"/visits/{visit.Id}", service.AddVisit(visit)));
    }
}