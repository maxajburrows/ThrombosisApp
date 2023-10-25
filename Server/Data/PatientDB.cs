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
        //optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Console.WriteLine("In model creating method.");

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.DoseDescriptions)
            .WithOne()
            .HasForeignKey(d => d.PatientId);
        modelBuilder.Entity<DoseDescription>()
            .HasData(
                new DoseDescription { Id = 1, PatientId = 1, Day = 1, Dose = 5f },
                new DoseDescription { Id = 2, PatientId = 1, Day = 2, Dose = 7f }
            );
        

        // Patient meredith = new() { 
        //     PatientId = 1, 
        //     FirstName = "Meredith", 
        //     LastName = "Grey", 
        //     INR = 2.1F, 
        //     DoseDescriptions = Enumerable.Range(1, 30).Select(i => new DoseDescription { Dose = (float)(Math.Max(2+(3-2.1F)*3, 0)*Math.Pow(0.95, i)) }).ToList()};
        // List<DoseDescription> meredithDoses = BuildDoseDescription(meredith);

        // Patient derek = new() { PatientId = 2, FirstName = "Derek", LastName = "Shepard", INR = 1.6F, };
        // List<DoseDescription> derekDoses = BuildDoseDescription(derek);

        // Patient izzie = new() { PatientId = 3, FirstName = "Izzie", LastName = "Stephens", INR = 0.7F, };
        // List<DoseDescription> izzieDoses = BuildDoseDescription(derek);

        // Patient christina = new() { PatientId = 4, FirstName = "Christina", LastName = "Yang", INR = 2.9F, };
        // List<DoseDescription> christinaDoses = BuildDoseDescription(christina);


        // modelBuilder.Entity<Patient>()
        //     .HasData(meredith, derek, izzie, christina);
        // modelBuilder.Entity<Patient>()   
        //     .OwnsMany(p => p.DoseDescriptions);
        modelBuilder.Entity<Patient>()
            .HasData(
                new Patient{ 
            PatientId = 1, 
            FirstName = "Meredith", 
            LastName = "Grey", 
            INR = 2.1F
            });
        
    }
    // private int counterId = 1;
    // public List<DoseDescription> BuildDoseDescription(Patient patient)
    // {
    //     List<DoseDescription> doseList = new();
    //     float dose = Math.Max(2+(3-patient.INR)*3, 0);
    //     for (int i = 1; i <= 30; i++)
    //     {
    //         DoseDescription doseDescription = new() { Id = counterId, PatientId = patient.PatientId, Day = i, Dose = dose, Patient = patient };
    //         doseList.Add(doseDescription);
    //         counterId++;
    //     }
    //     return doseList;
    // }
}