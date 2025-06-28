using AzureTestApp;
using AzureTestApp.Components;
using AzureTestApp.Models;
using AzureTestApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PrimaryConnection")));
builder.Services.AddSingleton<BlobTestService>();
builder.Services.AddSingleton<LandingPageServic>();
builder.Services.AddSingleton<ProfileData>();
builder.Services.AddSingleton<ApiPathManagement>();
builder.Services.AddScoped<ExpensesService>();
builder.Services.AddScoped<NotesService>();
builder.Services.AddScoped<HabitService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<HttpClientService>();
builder.Services.AddScoped<ProtectedSessionStorage>();


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
