using System.Globalization;
using Cats;
using Cats.Components;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddOptions<FileStorageOptions>()
    .Bind(builder.Configuration.GetSection(nameof(FileStorageOptions)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton<IContentTypeProvider, FileExtensionContentTypeProvider>();

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

StaticWebAssetsLoader.UseStaticWebAssets(app.Environment, app.Configuration);

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/images/{filename}", (string filename, IOptions<FileStorageOptions> options, IContentTypeProvider contentTypeProvider) =>
{
    var filePath = Path.Combine(options.Value.BasePath, "images", filename);

    if (!File.Exists(filePath))
        return Results.NotFound();

    var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

    if (!contentTypeProvider.TryGetContentType(filePath, out var contentType))
    {
        contentType = "application/octet-stream"; // fallback
    }
    
    return Results.Stream(stream, contentType);
});

app.Run();
