using EmployeeInfo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext db;
        private readonly IWebHostEnvironment _hostEnv;
        public EmployeeController(EmployeeDbContext db, IWebHostEnvironment hostEnv)
        {
            this.db = db;
            this._hostEnv = hostEnv;
        }

        public IActionResult Index()
        {
            ViewBag.departments = db.Departments.ToList();
            return View(db.Employees.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.departments = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM evm)
        {
            if (ModelState.IsValid)
            {
                if (evm.Pictures !=null)
                {
                    string newFileName = Guid.NewGuid().ToString() + "_" + evm.Pictures.FileName;
                    string newFilePath = Path.Combine("Images", newFileName);
                    string file = Path.Combine(_hostEnv.WebRootPath, newFilePath);
                    evm.Pictures.CopyTo(new FileStream(file, FileMode.Create));

                    Employee emp = new Employee
                    {
                        EmployeeName = evm.EmployeeName,
                        DOB = evm.DOB,
                        Email =evm.Email,
                        Phone =evm.Phone,
                        PicturePath = newFileName
                    };
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }

            ViewBag.departments = db.Departments.ToList();
            return View();
        }

    }
}
