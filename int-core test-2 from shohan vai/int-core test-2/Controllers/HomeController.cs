using int_core_test_2.Interfaces;
using int_core_test_2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace int_core_test_2.Controllers
{
    public class HomeController : Controller
    {

        private readonly PatientDbcontext db;
        private readonly IWebHostEnvironment env;
        private readonly Igeneric<Patient> pa;
        public HomeController(PatientDbcontext db, IWebHostEnvironment env, Igeneric<Patient> pa)
        {
            this.db = db;
            this.env = env;
            this.pa = pa;
        }

        public IActionResult Index()
        {
            
            multipletable m = new multipletable();
            
            m.Doctors = db.Doctors.ToList();
            m.Departments = db.Departments.ToList();
            m.Patients = db.Patients.ToList();
            return View(m); 
        }

        public IActionResult Create()
        {
            ViewBag.departments = db.Departments.ToList();
            ViewBag.doctors = db.Doctors.ToList();
            
            return PartialView("~/Views/Shared/_patient.cshtml");
        }
        [HttpPost]
        public IActionResult Create(Patient p)
        {
            if (p.Image != null)
            {
                p.Picture = fileupload(p);
            }
            pa.Create(p);
            pa.Save();
            ViewBag.doctors = db.Doctors.ToList();
            ViewBag.departments = db.Departments.ToList();
            return RedirectToAction("Index");
        }

        public string fileupload(Patient p)
        {
            string uniqueFileName = null;

            if (p.Image != null)
            {
                string uploadsFolder = Path.Combine(env.WebRootPath, "Images");
                uniqueFileName = p.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    p.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult Edit(int id)
        {
            var c = pa.GetById(id);
             ViewBag.departments = db.Departments.ToList();
            ViewBag.doctors = db.Doctors.ToList();
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(Patient p)
        {
            if (p.Image != null)
            {
                p.Picture = fileupload(p);
            }
            pa.Edit(p);
            pa.Save();
            ViewBag.departments = db.Departments.ToList();
            ViewBag.doctors = db.Doctors.ToList();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var c = pa.GetById(id);
            ViewBag.departments = db.Departments.ToList();
            ViewBag.doctors = db.Doctors.ToList();
            return View(c);
        }

        [HttpPost]
        public IActionResult Delete(Patient p)
        {
            pa.Delete(p);
            pa.Save();
            ViewBag.departments = db.Departments.ToList();
            ViewBag.doctors = db.Doctors.ToList();
            return RedirectToAction("Index");
        }
    }
}
