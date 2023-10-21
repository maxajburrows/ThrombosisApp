using Microsoft.EntityFrameworkCore;

namespace ThrombosisApp.Server.Controllers;

public class PatientDB : DbContext
{
    public DbSet<Patient>? Patients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "PatientDB.db");
        string connection = $"Filename={path}";
        Console.WriteLine($"Connection: {connection}");
        optionsBuilder.UseSqlite(connection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Patient meredith = new() { PatientId = 1, FirstName = "Meredith", LastName = "Grey" };
        Patient derek = new() { PatientId = 2, FirstName = "Derek", LastName = "Shepard" };
        Patient izzie = new() { PatientId = 3, FirstName = "Izzie", LastName = "Stephens" };
        Patient christina = new() { PatientId = 4, FirstName = "Christina", LastName = "Yang" };

        modelBuilder.Entity<Patient>()
            .HasData(meredith, derek, izzie, christina);
    }
}