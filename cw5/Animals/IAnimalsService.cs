namespace WebApplication1.Animals;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderBy = "name");
    
    Animal? GetAnimalById(int id);
   
    Animal AddAnimal(Animal animal);
    
    Animal? UpdateAnimal(int id, Animal animal);
    
    bool DeleteAnimal(int id);
}