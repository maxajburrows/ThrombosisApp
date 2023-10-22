using Microsoft.EntityFrameworkCore;

namespace ThrombosisApp.Server.Controllers;

public class PatientDB : DbContext
{
    public DbSet<Patient>? Patients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, $"Models{Path.DirectorySeparatorChar}PatientDB.db");
        string connection = $"Filename={path}";
        Console.WriteLine($"Connection: {connection}");
        optionsBuilder.UseSqlite(connection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Patient meredith = new() { PatientId = 1, FirstName = "Meredith", LastName = "Grey", INR = 2.1F };
        Patient derek = new() { PatientId = 2, FirstName = "Derek", LastName = "Shepard", INR = 1.6F };
        Patient izzie = new() { PatientId = 3, FirstName = "Izzie", LastName = "Stephens", INR = 0.7F };
        Patient christina = new() { PatientId = 4, FirstName = "Christina", LastName = "Yang", INR = 2.9F };

        modelBuilder.Entity<Patient>()
            .HasData(meredith, derek, izzie, christina);
    }
}