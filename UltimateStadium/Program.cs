using UltimateStadium.Components;
using UltimateStadium.Services;
using UltimateStadium.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IStadiumService, StadiumService>();
builder.Services.AddScoped<IStadiumStorage, StadiumStorage>();
builder.Services.AddScoped<IDashBoardStorage, DashBoardStorage>();
builder.Services.AddScoped<IDashBoardService, DashBoardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();