using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;

using ThrombosisApp.Server.Services;

namespace ThrombosisApp.Server.Data;

public class PatientDB : DbContext //Db
{
    public PatientDB(DbContextOptions<PatientDB> options) : base(options)
    {
    }
    public DbSet<Patient>? Patients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("In model configuring method");
        string path = Path.Combine(Environment.CurrentDirectory, "PatientDB.db");
        string connection = $"Filename={path}";
        Console.WriteLine($"Connection: {connection}");
        optionsBuilder.UseSqlite(connection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Console.WriteLine("In model creating method.");

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.DoseDescriptions)
            .WithOne()
            .HasForeignKey(d => d.PatientId);
        
        
        Patient meredith = new() { PatientId = 1, FirstName = "Meredith", LastName = "Grey", INR = 2.1F };
        Patient derek = new() { PatientId = 2, FirstName = "Derek", LastName = "Shepard", INR = 1.6F, };
        Patient izzie = new() { PatientId = 3, FirstName = "Izzie", LastName = "Stephens", INR = 0.7F, };
        Patient christina = new() { PatientId = 4, FirstName = "Christina", LastName = "Yang", INR = 2.9F, };

        IEnumerable<DoseDescription> meredithDoses = Enumerable.Range(1, 30)
            .Select(i => new DoseDescription { 
                    Id = i,
                    PatientId = 1,
                    Day = i,
                    Dose = (float)(Math.Max(2+(3-2.1F)*3, 0)*Math.Pow(0.95, i)) 
                    });


        
        modelBuilder.Entity<Patient>()
            .HasData(meredith, derek, izzie, christina);
        modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i,
                            PatientId = 1,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-2.1F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
            modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i+30,
                            PatientId = 2,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-1.6F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
            modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i+60,
                            PatientId = 3,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-0.7F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
            modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i+90,
                            PatientId = 4,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-2.9F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
        
    }
}