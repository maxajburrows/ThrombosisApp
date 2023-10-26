using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThrombosisApp.Server.Models;

public class Doctor
{     
     [Key]
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DoctorId { get; set; }
     [Required]
     [StringLength(60)]
    public string? FullName { get; set; }
     [Required]
     [StringLength(60)]
    public string? Postion { get; set; }
     [Required]
    public int Tenure { get; set; }
}