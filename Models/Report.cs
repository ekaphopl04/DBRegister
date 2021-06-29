using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBRegister.Models
{
    public class Report{

[Key]
    public int Id {set ; get ;}
    public string Email {set ; get ;}
    public string Password {set ; get ;}
    public string Name {set ; get ;}
    public string Surname {set ; get ;}
    [DataType(DataType.Date)]
    
    public DateTime Birthday {set ; get ;}


}
    public class ReportContext : DbContext {
    public DbSet<Report> ReportTable {get; set ;}
    public ReportContext(DbContextOptions<ReportContext> options) : base(options){}

}


}