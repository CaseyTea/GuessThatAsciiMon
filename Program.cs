using GuessThatAsciiMon.Components;
using GuessThatAsciiMon.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Interfaces
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IAsciiService, AsciiService>();
builder.Services.AddScoped<IGameService, GameService>();

//PokeAPI
builder.Services.AddHttpClient(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Allow iframe embedding from your personal website
app.Use(async (context, next) =>
{
    // Use OnStarting to ensure our headers are set last (after Blazor's defaults)
    context.Response.OnStarting(() =>
    {
        // Remove any CSP headers that were added
        context.Response.Headers.Remove("Content-Security-Policy");
        context.Response.Headers.Remove("X-Frame-Options");

        // Add our custom CSP header
        context.Response.Headers.Append("Content-Security-Policy",
            "frame-ancestors 'self' https://caseytea.github.io http://localhost:*");

        return Task.CompletedTask;
    });

    await next();
});

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
