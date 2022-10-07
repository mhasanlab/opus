using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Models
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        [Required, Display(Name = "Employee Name"), StringLength(75)]
        public string EmployeeName { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Date Of Birth"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required, Display(Name = "Email"), StringLength(30)]
        public string Email { get; set; }
        [Required, Display(Name = "Phone"), StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Image")]
        public string PicturePath { get; set; }
        public IFormFile Pictures { get; set; }
    }
}
