namespace WebApplication1.Animals;

public class AnimalService : IAnimalsService
{
    private static List<Animal> _animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Max", Category = "Dog", Weight = 24.5, FurColor = "Black" },
        new Animal { Id = 2, Name = "Whiskers", Category = "Cat", Weight = 5.3, FurColor = "White" },
        new Animal { Id = 3, Name = "Buddy", Category = "Dog", Weight = 30.0, FurColor = "Brown" },
        new Animal { Id = 4, Name = "Shadow", Category = "Cat", Weight = 4.2, FurColor = "Gray" }
    };

    private static int _nextId = 5;

    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal GetAnimalById(int id)
    {
        return _animals.FirstOrDefault(a => a.Id == id);
    }

    public Animal AddAnimal(Animal animal)
    {
        animal.Id = _nextId++;
        _animals.Add(animal);
        return animal;
    }

    public Animal UpdateAnimal(int id, Animal updateAnimal)
    {
        var animal = GetAnimalById(id);
        if (animal == null) return null;

        animal.Name = updateAnimal.Name;
        animal.Category = updateAnimal.Category;
        animal.Weight = updateAnimal.Weight;
        animal.FurColor = updateAnimal.FurColor;
        return animal;
    }

    public void DeleteAnimal(int id)
    {
        var animal = GetAnimalById(id);
        if (animal != null)
        {
            _animals.Remove(animal);
        }
    }
}
