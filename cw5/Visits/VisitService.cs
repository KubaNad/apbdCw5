using WebApplication1.Animals;

namespace WebApplication1.Visits;

public class VisitService : IVisitsService
{
    private static List<Visit> _visits = new List<Visit>
    {
        new Visit { Id = 1, AnimalId = 1, Date = DateTime.Parse("2023-04-01T14:00:00"), Description = "Annual vaccination", Price = 250.00m },
        new Visit { Id = 2, AnimalId = 2, Date = DateTime.Parse("2023-04-02T15:30:00"), Description = "General checkup", Price = 200.00m },
        new Visit { Id = 3, AnimalId = 3, Date = DateTime.Parse("2023-04-03T16:45:00"), Description = "Dental cleaning", Price = 300.00m },
        new Visit { Id = 4, AnimalId = 4, Date = DateTime.Parse("2023-04-04T11:00:00"), Description = "Emergency visit - injured paw", Price = 500.00m },
        new Visit { Id = 5, AnimalId = 1, Date = DateTime.Parse("2023-04-05T09:20:00"), Description = "Follow-up for vaccination", Price = 150.00m }
    };

    private static int _nextId = 6;

    public IEnumerable<Visit> GetVisitsForAnimal(int animalId)
    {
        return _visits.Where(v => v.AnimalId == animalId).ToList();
    }

    public Visit AddVisit(Visit visit)
    {
        visit.Id = _nextId++;
        _visits.Add(visit);
        return visit;
    }
}
