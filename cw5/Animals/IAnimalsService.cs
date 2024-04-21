namespace WebApplication1.Animals;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimalById(int id);
    Animal AddAnimal(Animal animal);
    Animal UpdateAnimal(int id, Animal animal);
    void DeleteAnimal(int id);
}
