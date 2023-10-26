using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Data;
using ThrombosisApp.Server.Repositories;
using ThrombosisApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
string datbasePath = Path.Combine(Environment.CurrentDirectory, "PatientDB.db");
builder.Services.AddDbContext<PatientDB>(options =>
    options.UseSqlite($"Data Source={datbasePath}"));
    
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<PatientsService>();

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseRouting();
app.UseStaticFiles();
app.UseBlazorFrameworkFiles();
app.MapControllers();

var optionsBuilder = new DbContextOptionsBuilder<PatientDB>();
optionsBuilder.UseSqlite();

using (PatientDB p = new PatientDB(optionsBuilder.Options))
{
    await p.Database.EnsureDeletedAsync();
    await p.Database.EnsureCreatedAsync();
}

app.Run();