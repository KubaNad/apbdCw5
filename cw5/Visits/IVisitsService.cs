using WebApplication1.Visits;

namespace WebApplication1.Visits;

public interface IVisitsService
{
    IEnumerable<Visit> GetVisitsForAnimal(int animalId);
    Visit AddVisit(Visit visit);
}
