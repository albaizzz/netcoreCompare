using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTest.netcore.Models{

[Table("Student")]
public class StudentSQL {
    [Key]
    public int studentid { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email {get; set; }
    public string Gender { get; set; }
    public string IPAddress { get; set; }
 }
}