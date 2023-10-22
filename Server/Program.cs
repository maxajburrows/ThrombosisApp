using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Data;
using ThrombosisApp.Server.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
string datbasePath = Path.Combine(Environment.CurrentDirectory, "PatientDB.db");
Console.WriteLine(datbasePath);
builder.Services.AddDbContext<PatientDB>(options =>
    options.UseSqlite($"Data Source={datbasePath}"));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

var optionsBuilder = new DbContextOptionsBuilder<PatientDB>();
optionsBuilder.UseSqlite();

using (PatientDB p = new PatientDB(optionsBuilder.Options))
{
    bool deleted = await p.Database.EnsureDeletedAsync();
    Console.WriteLine($"Database deleted: {deleted}");
    bool created = await p.Database.EnsureCreatedAsync();
    Console.WriteLine($"Database created: {created}");

    foreach (Patient pat in p.Patients)
    {
        Console.WriteLine("{0} {1} has INR value of: {2}",
            pat.FirstName, pat.LastName, pat.INR);
    }
}

app.Run();