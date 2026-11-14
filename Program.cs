using Microsoft.EntityFrameworkCore;
using StudyMate.Services;
using StudyMate.Data;
using StudyMate.Components;

var builder = WebApplication.CreateBuilder(args);

// DATABASES

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=studymate.db"));

builder.Services.AddDbContext<NoteDbContext>(options =>
    options.UseSqlite("Data Source=studymate_notes.db"));

builder.Services.AddDbContext<SettingsDbContext>(options =>
    options.UseSqlite("Data Source=studymate_settings.db"));

// SERVICES

builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<NoteService>();
builder.Services.AddScoped<PomodoroService>();
builder.Services.AddScoped<SettingsService>();
builder.Services.AddScoped<RecommendationService>();
builder.Services.AddScoped<ValidationService>();

// STATE MANAGEMENT
builder.Services.AddScoped<AppState>();

// BLAZOR

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// CREATE DATABASES

using (var scope = app.Services.CreateScope())
{
    var notes = scope.ServiceProvider
        .GetRequiredService<NoteDbContext>();

    notes.Database.EnsureCreated();

    var settings = scope.ServiceProvider
        .GetRequiredService<SettingsDbContext>();

    settings.Database.EnsureCreated();
}

// HTTP PIPELINE

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();