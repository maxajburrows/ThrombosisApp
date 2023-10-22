using Microsoft.AspNetCore.ResponseCompression;
using ThrombosisApp.Server.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

using (PatientDB p = new())
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