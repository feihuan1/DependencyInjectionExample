using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// a service lifetime indicates when a new object of the service has to be created by the IoC/ DI container.
// Transient -> per injecttion
// Scoped -> Per scope (browser request)
// Singleton -> For entire application lifetime

// this get 3 different id, refresh get 3 different again
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Transient
//));
//builder.Services.AddTransient<ICitiesService, CitiesService>();

// this get 3 same ID, refresh get 3 same Id diffrent than first 3
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Scoped
//));

//builder.Services.AddScoped<ICitiesService, CitiesService>();

// this gets 3 same ID after refresh
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Singleton
//));
builder.Services.AddSingleton<ICitiesService, CitiesService>();

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.MapControllers();


app.Run();
