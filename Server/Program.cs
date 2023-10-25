using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Data;
using ThrombosisApp.Server.Repositories;
using ThrombosisApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
string datbasePath = Path.Combine(Environment.CurrentDirectory, "PatientDB.db");
builder.Services.AddDbContext<PatientDB>(options =>
    options.UseSqlite($"Data Source={datbasePath}"));
    
builder.Services.AddScoped<IPatientRepository, PatientRepository>(); //AddSingleton
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
    bool deleted = await p.Database.EnsureDeletedAsync();
    bool created = await p.Database.EnsureCreatedAsync();

    foreach (Patient pat in p.Patients)
    {
        Console.WriteLine("{0} {1} has INR value of: {2}",
            pat.FirstName, pat.LastName, pat.INR);
    }
}

app.Run();