using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace int_core_test_2.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
      
        public string DoctorName { get; set; }
        public List<Patient> Patients { get; set; }
    }


    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Patient> Patients { get; set; }
    }

    public class Patient
    {
        public int PatientId { get; set; }
        [StringLength(maximumLength:50,MinimumLength =5,ErrorMessage ="Required length are not mathch")]
        public string Name { get; set; }
        [Required]
        public string  Gender { get; set; }
        [Required,DataType(DataType.Date)]
        public DateTime visitDate { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [Range(500,2000)]
        public int Fee { get; set; }
        [Display(Name ="status")]
        public bool Isadmitted { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string Picture { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Department  Department { get; set; }
    }

    public class PatientDbcontext : DbContext
    {
        public PatientDbcontext(DbContextOptions<PatientDbcontext>options):base(options)
        {
                
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
