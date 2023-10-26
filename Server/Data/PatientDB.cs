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
    public DbSet<Doctor>? Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "PatientDB.db");
        string connection = $"Filename={path}";
        optionsBuilder.UseSqlite(connection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.DoseDescriptions)
            .WithOne()
            .HasForeignKey(d => d.PatientId);

        Doctor meredith = new() { DoctorId = 1, FullName = "Meredith Grey", Postion = "Resident", Tenure = 3 };
        Doctor derek = new() { DoctorId = 2, FullName = "Derek Shepard", Postion = "Attending", Tenure = 15 };
        Doctor izzie = new() { DoctorId = 3, FullName = "Izzie Stephens", Postion = "Resident", Tenure = 3 };
        Doctor christina = new() { DoctorId = 4, FullName = "Christina Yang", Postion = "Resident", Tenure = 4 };
        
        Patient tom = new() { PatientId = 1, FirstName = "Tom", LastName = "Cruise", INR = 2.1F };
        Patient zoe = new() { PatientId = 2, FirstName = "Zoe", LastName = "Saldana", INR = 1.6F, };
        Patient jason = new() { PatientId = 3, FirstName = "Jason", LastName = "Statham", INR = 0.7F, };
        Patient scarlett = new() { PatientId = 4, FirstName = "Scarlett", LastName = "Johansson", INR = 2.9F, };
        Patient matt = new() { PatientId = 5, FirstName = "Matt", LastName = "Damon", INR = 1.2F, };
        Patient daniel = new() { PatientId = 6, FirstName = "Daniel", LastName = "Craig", INR = 0.5F, };
        Patient chris = new() { PatientId = 7, FirstName = "Chris", LastName = "Hemsworth", INR = 2.4F, };


        modelBuilder.Entity<Doctor>()
            .HasData(meredith, derek, izzie, christina);
        modelBuilder.Entity<Patient>()
            .HasData(tom, zoe, jason, scarlett, matt, daniel, chris);
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
            modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i+120,
                            PatientId = 5,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-1.2F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
            modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i+150,
                            PatientId = 6,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-0.5F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
            modelBuilder.Entity<DoseDescription>()
            .HasData(
                Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = i+180,
                            PatientId = 7,
                            Day = i,
                            Dose = (float)(Math.Max(2+(3-2.4F)*3, 0)*Math.Pow(0.95, i)) 
                            })
            );
        
    }
}