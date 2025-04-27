namespace Cats.Entities;

public class Breed : IIdentifiable
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MinWeight { get; set; }
    public decimal MaxWeight { get; set; }
    public CatSize Size { get; set; }
    
    public IList<Coat> Coats { get; set; } = new List<Coat>();
    public IList<Personality> Personalities { get; set; } = new List<Personality>();
}

