using UltimateStadium.Components;
using UltimateStadium.Services;
using UltimateStadium.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IStadiumService, StadiumService>();
builder.Services.AddScoped<IStadiumStorage, StadiumStorage>();
builder.Services.AddScoped<IUserStorage, UserStorage>();
builder.Services.AddScoped<IDashBoardStorage, DashBoardStorage>();
builder.Services.AddScoped<IDashBoardService, DashBoardService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IReservationStorage, ReservationStorage>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/login"; 
        options.AccessDeniedPath = "/access-denied"; 
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("EditorPolicy", policy => policy.RequireClaim("Department", "Editors"));
});

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
    .AddInteractiveServerRenderMode()
   ;

app.Run();