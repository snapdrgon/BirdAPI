namespace BirdAPI.Persistence.Respositores
{
    public interface IBirdBreed
    {
        int ID { get; set; }
        string Name { get; set; }
        string Range { get; set; }
        string ScientificName { get; set; }
    }
}