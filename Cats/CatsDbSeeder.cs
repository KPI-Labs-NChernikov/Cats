using Cats.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cats;

public sealed class CatsDbSeeder
{
    private readonly Coat[] expectedCoats =
    [
        new Coat { Id = Guid.Parse("019678de-dfef-70fa-8afb-ef0ac157c056"), Name = "long" },
        new Coat { Id = Guid.Parse("019678de-f495-784a-a631-7edcf72bf38f"), Name = "thick" },
        new Coat { Id = Guid.Parse("019678df-04cd-7c29-86da-8cac1f7b5ed2"), Name = "water-repellent" },
        new Coat { Id = Guid.Parse("019678df-0f35-7c30-86c9-6a89a1e797bd"), Name = "short" },
        new Coat { Id = Guid.Parse("019678df-18aa-7b7a-b861-4a2c75ef6881"), Name = "fine" },
        new Coat { Id = Guid.Parse("019678df-275c-778d-85e6-fb03065e6c89"), Name = "sleek" },
        new Coat { Id = Guid.Parse("019678df-3426-7962-999e-f0bb59962915"), Name = "dense" },
        new Coat { Id = Guid.Parse("019678df-42ce-7615-9aae-046d5164d7e4"), Name = "plush" },
        new Coat { Id = Guid.Parse("019678df-5101-7052-a08f-0d881dd9b591"), Name = "soft" },
        new Coat { Id = Guid.Parse("019678df-5c8c-7b83-8de5-922df1b2cb00"), Name = "glittered" },
        new Coat { Id = Guid.Parse("019678df-6ae7-7487-9ecf-73ee03656bba"), Name = "silky" },
        new Coat { Id = Guid.Parse("019678df-79d3-74e2-bfe1-c7e1bc7add75"), Name = "semi-long" },
        new Coat { Id = Guid.Parse("019678df-8613-765a-8281-5d9b9e302175"), Name = "hairless" },
        new Coat { Id = Guid.Parse("019678df-91ae-727b-8ac1-b63d5b58bef9"), Name = "ticked" },
        new Coat { Id = Guid.Parse("019678df-9eeb-7b7b-a178-4b897e1d1c9f"), Name = "luxurious" }
    ];

    private readonly Personality[] expectedPersonalities =
    [
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a3d-a5f2-8b41cc556b5e"), Name = "gentle" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a3e-bd9a-84989ee96eab"), Name = "playful" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a3f-9910-9dfeb7cd2ae0"), Name = "intelligent" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a40-9df5-9a7d1e4fd5a6"), Name = "vocal" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a41-891a-ae1d5095b612"), Name = "social" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a42-8434-83e8ea51c2b5"), Name = "affectionate" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a43-8ab6-806fd0637b5e"), Name = "calm" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a44-bef1-8009487e23cc"), Name = "easygoing" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a45-9633-8cd62f0f6c97"), Name = "independent" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a46-9337-b457adddc839"), Name = "energetic" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a47-9fe8-a8b129d779d3"), Name = "curious" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a48-85ae-8acb83abeb07"), Name = "confident" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a49-b858-bc6ef63a94bd"), Name = "relaxed" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a4a-8734-8c0a984fc358"), Name = "friendly" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a4b-9ecf-85ea3b8bc903"), Name = "lively" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a4c-89d8-8dbacc95e0e6"), Name = "mischievous" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a4d-91f3-b25f39cf0638"), Name = "sweet" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a4e-93e5-84cf623780f0"), Name = "adaptable" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a4f-8b4f-9e5f8d9e6f7e"), Name = "strong climber" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a50-9937-95cfa95761d8"), Name = "adventurous" },
        new Personality { Id = Guid.Parse("018f84c6-8c04-7a51-8712-92a8f740ce3b"), Name = "quiet" },
    ];

    private readonly Cat[] expectedCats = 
    [
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a52-81e9-9c35e1d8b1b2"), Name = "Maine Coon", Description = "One of the largest domestic cat breeds, the Maine Coon is known for its tufted ears, bushy tail, and dog-like loyalty. It's affectionate but not overly needy.", Size = CatSize.Large, MinWeight = 5, MaxWeight = 11 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a53-8a1e-84748c6a69a0"), Name = "Siamese", Description = "Siamese cats are famous for their striking blue almond-shaped eyes and pointed coloration. They are very people-oriented and love conversation.", Size = CatSize.Medium, MinWeight = 3, MaxWeight = 6 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a54-9d28-8c1ab7ee034d"), Name = "British Shorthair", Description = "With a round face and chubby cheeks, the British Shorthair is often described as a \"teddy bear.\" They are quiet companions who enjoy lounging.", Size = CatSize.MediumToLarge, MinWeight = 4, MaxWeight = 8 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a55-8c94-9ba0a74b8a27"), Name = "Bengal", Description = "Bengals look like miniature leopards with their distinctive spotted coats. They are highly active, intelligent, and love interactive play.", Size = CatSize.MediumToLarge, MinWeight = 4, MaxWeight = 7 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a56-9795-b20cf77a5e48"), Name = "Ragdoll", Description = "Ragdolls are named for their tendency to go limp when picked up. They are incredibly docile and loving, making them great lap cats.", Size = CatSize.Large, MinWeight = 4, MaxWeight = 9 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a57-89be-b760f8ea5e4d"), Name = "Sphynx", Description = "Sphynx cats are famous for their lack of fur and wrinkled skin. They are extremely affectionate, often following their humans everywhere.", Size = CatSize.Medium, MinWeight = 3, MaxWeight = 6 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a58-9b0a-b2cc7f9e6893"), Name = "Scottish Fold", Description = "Recognizable by their folded ears, Scottish Folds are easygoing and love cuddles. They often sit in odd, adorable poses (\"the Buddha sit\").", Size = CatSize.Medium, MinWeight = 3, MaxWeight = 6 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a59-93fe-99b43a9edc12"), Name = "Norwegian Forest Cat", Description = "Native to Scandinavia, these cats are built for cold climates. They have a powerful build and love heights, often scaling tall furniture.", Size = CatSize.Large, MinWeight = 5, MaxWeight = 9 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a5a-978d-87e4af1d7b51"), Name = "Abyssinian", Description = "One of the oldest cat breeds, Abyssinians are known for their active, adventurous spirit and beautiful ticked coat that shimmers in the light.", Size = CatSize.Medium, MinWeight = 3, MaxWeight = 5 },
        new Cat { Id = Guid.Parse("018f84d0-8c05-7a5b-92b1-b72cfc416edd"), Name = "Persian", Description = "Persians are iconic for their long flowing coats and flat faces. They are gentle souls who enjoy lounging in serene environments.", Size = CatSize.MediumToLarge, MinWeight = 4, MaxWeight = 7 },
    ];

    private readonly Dictionary<Guid, List<Guid>> expectedCatCoats = new()
    {
        { Guid.Parse("018f84d0-8c05-7a52-81e9-9c35e1d8b1b2"), new List<Guid> { Guid.Parse("019678de-dfef-70fa-8afb-ef0ac157c056"), Guid.Parse("019678de-f495-784a-a631-7edcf72bf38f"), Guid.Parse("019678df-04cd-7c29-86da-8cac1f7b5ed2") } }, // Maine Coon: long, thick, water-repellent
        { Guid.Parse("018f84d0-8c05-7a53-8a1e-84748c6a69a0"), new List<Guid> { Guid.Parse("019678df-0f35-7c30-86c9-6a89a1e797bd"), Guid.Parse("019678df-18aa-7b7a-b861-4a2c75ef6881"), Guid.Parse("019678df-275c-778d-85e6-fb03065e6c89") } }, // Siamese: short, fine, sleek
        { Guid.Parse("018f84d0-8c05-7a54-9d28-8c1ab7ee034d"), new List<Guid> { Guid.Parse("019678df-0f35-7c30-86c9-6a89a1e797bd"), Guid.Parse("019678df-3426-7962-999e-f0bb59962915"), Guid.Parse("019678df-42ce-7615-9aae-046d5164d7e4") } }, // British Shorthair: short, dense, plush
        { Guid.Parse("018f84d0-8c05-7a55-8c94-9ba0a74b8a27"), new List<Guid> { Guid.Parse("019678df-0f35-7c30-86c9-6a89a1e797bd"), Guid.Parse("019678df-5101-7052-a08f-0d881dd9b591"), Guid.Parse("019678df-5c8c-7b83-8de5-922df1b2cb00") } }, // Bengal: short, soft, glittered
        { Guid.Parse("018f84d0-8c05-7a56-9795-b20cf77a5e48"), new List<Guid> { Guid.Parse("019678df-79d3-74e2-bfe1-c7e1bc7add75"), Guid.Parse("019678df-6ae7-7487-9ecf-73ee03656bba") } }, // Ragdoll: semi-long, silky
        { Guid.Parse("018f84d0-8c05-7a57-89be-b760f8ea5e4d"), new List<Guid> { Guid.Parse("019678df-8613-765a-8281-5d9b9e302175") } }, // Sphynx: hairless
        { Guid.Parse("018f84d0-8c05-7a58-9b0a-b2cc7f9e6893"), new List<Guid> { Guid.Parse("019678df-0f35-7c30-86c9-6a89a1e797bd"), Guid.Parse("019678df-3426-7962-999e-f0bb59962915") } }, // Scottish Fold: short, dense
        { Guid.Parse("018f84d0-8c05-7a59-93fe-99b43a9edc12"), new List<Guid> { Guid.Parse("019678de-dfef-70fa-8afb-ef0ac157c056"), Guid.Parse("019678de-f495-784a-a631-7edcf72bf38f") } }, // Norwegian Forest Cat: long, thick
        { Guid.Parse("018f84d0-8c05-7a5a-978d-87e4af1d7b51"), new List<Guid> { Guid.Parse("019678df-0f35-7c30-86c9-6a89a1e797bd"), Guid.Parse("019678df-91ae-727b-8ac1-b63d5b58bef9") } }, // Abyssinian: short, ticked
        { Guid.Parse("018f84d0-8c05-7a5b-92b1-b72cfc416edd"), new List<Guid> { Guid.Parse("019678de-dfef-70fa-8afb-ef0ac157c056"), Guid.Parse("019678df-9eeb-7b7b-a178-4b897e1d1c9f") } }, // Persian: long, luxurious
    };

    private readonly Dictionary<Guid, List<Guid>> expectedCatPersonalities = new()
    {
        { Guid.Parse("018f84d0-8c05-7a52-81e9-9c35e1d8b1b2"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a3d-a5f2-8b41cc556b5e"), Guid.Parse("018f84c6-8c04-7a3e-bd9a-84989ee96eab"), Guid.Parse("018f84c6-8c04-7a3f-9910-9dfeb7cd2ae0") } }, // Maine Coon: gentle, playful, intelligent
        { Guid.Parse("018f84d0-8c05-7a53-8a1e-84748c6a69a0"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a40-9df5-9a7d1e4fd5a6"), Guid.Parse("018f84c6-8c04-7a41-891a-ae1d5095b612"), Guid.Parse("018f84c6-8c04-7a42-8434-83e8ea51c2b5") } }, // Siamese: vocal, social, affectionate
        { Guid.Parse("018f84d0-8c05-7a54-9d28-8c1ab7ee034d"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a43-8ab6-806fd0637b5e"), Guid.Parse("018f84c6-8c04-7a44-bef1-8009487e23cc"), Guid.Parse("018f84c6-8c04-7a45-9633-8cd62f0f6c97") } }, // British Shorthair: calm, easygoing, independent
        { Guid.Parse("018f84d0-8c05-7a55-8c94-9ba0a74b8a27"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a46-9337-b457adddc839"), Guid.Parse("018f84c6-8c04-7a47-9fe8-a8b129d779d3"), Guid.Parse("018f84c6-8c04-7a48-85ae-8acb83abeb07") } }, // Bengal: energetic, curious, confident
        { Guid.Parse("018f84d0-8c05-7a56-9795-b20cf77a5e48"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a3d-a5f2-8b41cc556b5e"), Guid.Parse("018f84c6-8c04-7a49-b858-bc6ef63a94bd"), Guid.Parse("018f84c6-8c04-7a42-8434-83e8ea51c2b5") } }, // Ragdoll: gentle, relaxed, affectionate
        { Guid.Parse("018f84d0-8c05-7a57-89be-b760f8ea5e4d"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a4a-8734-8c0a984fc358"), Guid.Parse("018f84c6-8c04-7a4b-9ecf-85ea3b8bc903"), Guid.Parse("018f84c6-8c04-7a4c-89d8-8dbacc95e0e6") } }, // Sphynx: friendly, lively, mischievous
        { Guid.Parse("018f84d0-8c05-7a58-9b0a-b2cc7f9e6893"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a4d-91f3-b25f39cf0638"), Guid.Parse("018f84c6-8c04-7a4e-93e5-84cf623780f0"), Guid.Parse("018f84c6-8c04-7a3e-bd9a-84989ee96eab") } }, // Scottish Fold: sweet, adaptable, playful
        { Guid.Parse("018f84d0-8c05-7a59-93fe-99b43a9edc12"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a45-9633-8cd62f0f6c97"), Guid.Parse("018f84c6-8c04-7a3d-a5f2-8b41cc556b5e"), Guid.Parse("018f84c6-8c04-7a4f-8b4f-9e5f8d9e6f7e") } }, // Norwegian Forest Cat: independent, gentle, strong climber
        { Guid.Parse("018f84d0-8c05-7a5a-978d-87e4af1d7b51"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a47-9fe8-a8b129d779d3"), Guid.Parse("018f84c6-8c04-7a50-9937-95cfa95761d8"), Guid.Parse("018f84c6-8c04-7a42-8434-83e8ea51c2b5") } }, // Abyssinian: curious, adventurous, affectionate
        { Guid.Parse("018f84d0-8c05-7a5b-92b1-b72cfc416edd"), new List<Guid> { Guid.Parse("018f84c6-8c04-7a43-8ab6-806fd0637b5e"), Guid.Parse("018f84c6-8c04-7a42-8434-83e8ea51c2b5"), Guid.Parse("018f84c6-8c04-7a51-8712-92a8f740ce3b") } }, // Persian: calm, affectionate, quiet
    };

    public void Seed(CatsDbContext dbContext)
    {
        var coats = Seed(dbContext, dbContext.Coats, expectedCoats);;
        
        var personalities = Seed(dbContext, dbContext.Personalities, expectedPersonalities);
        
        var cats = Seed(dbContext, dbContext.Cats.Include(c => c.Coats).Include(c => c.Personalities), expectedCats);

        foreach (var cat in cats)
        {
            var expectedCoatsForCat = expectedCatCoats[cat.Id];
            var coatsToAdd = expectedCoatsForCat.Except(cat.Coats.Select(c => c.Id))
                .Join(coats, i => i, c => c.Id, (_, c) => c)
                .ToList();
            foreach (var coat in coatsToAdd)
            {
                cat.Coats.Add(coat);
            }
            
            var expectedPersonalitiesForCat = expectedCatPersonalities[cat.Id];
            var personalitiesToAdd = expectedPersonalitiesForCat.Except(cat.Personalities.Select(c => c.Id))
                .Join(personalities, i => i, c => c.Id, (_, c) => c);
            foreach (var personality in personalitiesToAdd)
            {
                cat.Personalities.Add(personality);
            }
            
            dbContext.SaveChanges();
        }
    }

    private IList<TEntity> Seed<TEntity>(DbContext dbContext, IQueryable<TEntity> query, IEnumerable<TEntity> expectedEntities)
        where TEntity : class, IIdentifiable
    {
        var existingEntities = query.Where(c => expectedEntities.Select(e => e.Id).Contains(c.Id)).ToList();
        var entitiesToAdd = expectedEntities.ExceptBy(existingEntities.Select(e => e.Id), c => c.Id).ToList();
        dbContext.AddRange(entitiesToAdd);
        dbContext.SaveChanges();
        
        return entitiesToAdd.Union(existingEntities).ToList();
    }

    public async Task SeedAsync(CatsDbContext dbContext, CancellationToken ct)
    {
        var coats = await SeedAsync(dbContext, dbContext.Coats, expectedCoats, ct);
        
        var personalities = await SeedAsync(dbContext, dbContext.Personalities, expectedPersonalities, ct);
        
        var cats = await SeedAsync(dbContext, dbContext.Cats.Include(c => c.Coats).Include(c => c.Personalities), expectedCats, ct);

        foreach (var cat in cats)
        {
            var expectedCoats = expectedCatCoats[cat.Id];
            var coatsToAdd = expectedCoats.Except(cat.Coats.Select(c => c.Id))
                .Join(coats, i => i, c => c.Id, (i, c) => c)
                .ToList();
            foreach (var coat in coatsToAdd)
            {
                cat.Coats.Add(coat);
            }

            var expectedPersonalities = expectedCatPersonalities[cat.Id];
            var personalitiesToAdd = expectedPersonalities.Except(cat.Personalities.Select(c => c.Id))
                .Join(personalities, i => i, c => c.Id, (i, c) => c);
            foreach (var personality in personalitiesToAdd)
            {
                cat.Personalities.Add(personality);
            }

            await dbContext.SaveChangesAsync(ct);
        }
    }
    
    private async Task<IList<TEntity>> SeedAsync<TEntity>(DbContext dbContext, IQueryable<TEntity> query, IEnumerable<TEntity> expectedEntities, CancellationToken ct)
        where TEntity : class, IIdentifiable
    {
        var existingEntities = await query.Where(c => expectedEntities.Select(e => e.Id).Contains(c.Id)).ToListAsync(ct);
        var entitiesToAdd = expectedEntities.ExceptBy(existingEntities.Select(e => e.Id), c => c.Id).ToList();
        dbContext.AddRange(entitiesToAdd);
        await dbContext.SaveChangesAsync(ct);
        
        return entitiesToAdd.Union(existingEntities).ToList();
    }
}
