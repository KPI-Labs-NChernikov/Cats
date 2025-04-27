namespace Cats.Entities;

public class Personality : IIdentifiable
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public IList<Cat> Cats { get; set; } = new List<Cat>();
}
