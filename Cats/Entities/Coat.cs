﻿namespace Cats.Entities;

public class Coat : IIdentifiable
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public IList<Breed> Breeds { get; set; } = new List<Breed>();
}
