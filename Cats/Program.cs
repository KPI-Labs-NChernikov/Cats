using System.Globalization;
using Cats;
using Cats.Components;
using Microsoft.EntityFrameworkCore;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<CatsDbSeeder>();
builder.Services.AddDbContextFactory<CatsDbContext>((sp, options) => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("CatsDb"))
        .UseSeeding((dbContext, _) =>
        {
            var applicationDbContext = (CatsDbContext)dbContext;
            var countrySeeder = sp.GetRequiredService<CatsDbSeeder>();
            countrySeeder.Seed(applicationDbContext);
        })
        .UseAsyncSeeding(async (dbContext, _, ct) =>
        {
            var applicationDbContext = (CatsDbContext)dbContext;
            var countrySeeder = sp.GetRequiredService<CatsDbSeeder>();
            await countrySeeder.SeedAsync(applicationDbContext, ct);

        }));
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var runMigrations = app.Configuration.GetValue("CatsDbSettings:RunMigrations", false);
if (runMigrations)
{
    var dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<CatsDbContext>>();
    var dbContext = dbContextFactory.CreateDbContext();
    await dbContext.Database.MigrateAsync();
}

//app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
