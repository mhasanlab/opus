using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required, Display(Name = "Department Name"), StringLength(75)]
        public string DepartmentName { get; set; }
        //Nev
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, Display(Name ="Employee Name"), StringLength(75)]
        public string EmployeeName { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Date Of Birth"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required, Display(Name = "Email"), StringLength(30)]
        public string Email { get; set; }
        [Required, Display(Name = "Phone"), StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Image")]
        public string PicturePath { get; set; }
        // Nev
        public virtual Department Department { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

}
