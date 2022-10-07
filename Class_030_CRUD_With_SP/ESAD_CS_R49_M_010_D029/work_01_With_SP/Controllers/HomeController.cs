using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using work_01_With_SP.Models;

namespace work_01_With_SP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private r49DBContext context;
        public HomeController(ILogger<HomeController> logger, r49DBContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Customers> customers = this.context.SearchCustomer("").ToList();
            return View(customers);
        }
        [HttpPost]
        public IActionResult Index(string name)
        {
            List<Customers> customers = this.context.SearchCustomer(!string.IsNullOrEmpty(name) ? name : "").ToList();
            return View(customers);
        }
        [HttpPost]
        public IActionResult Insert(Customers customers)
        {
            Customers model = new Customers()
            {
                Name = customers.Name,
                Country = customers.Country
            };
            this.context.InsertCustomer(model);
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public IActionResult Edit(Customers customers)
        {
            Customers model = new Customers()
            {
                CustomerId=customers.CustomerId,
                Name = customers.Name,
                Country = customers.Country
            };
            this.context.UpdateCustomer(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Customers customers)
        {
            this.context.DeleteCustomer(customers.CustomerId);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
