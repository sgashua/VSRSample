using DataTablesParser;
using Microsoft.AspNetCore.Mvc;
using VSRSample.Application.Businesses;
using VSRSample.Domain.Entities;

namespace VSRSample.WebUI.Areas.Frontend.Features.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeBusiness _business;
        public HomeController(ILogger<HomeController> logger, IHomeBusiness business)
        {
            _logger = logger;
            _business = business;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Populate(Company company)
        {
            var result = _business.Company.GetAll(x => (string.IsNullOrEmpty(company.Name) || x.Name.Contains(company.Name)));
            var parser = new Parser<Company>(Request.Form, result);

            return Json(parser.Parse());
        }

        [HttpPost]
        public IActionResult Save()
        {
            var company = new Company()
            {
                Name = $"Company {DateTime.Now.ToString("HHmmss")}",
                Employees = new List<Employee>()
                {
                    new Employee() { Name = $"Employee A {DateTime.Now.ToString("HHmmss")}" },
                    new Employee() { Name = $"Employee B {DateTime.Now.ToString("HHmmss")}" },
                    new Employee() { Name = $"Employee C {DateTime.Now.ToString("HHmmss")}" }
                }
            };

            _business.Company.Save(company);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var company = new Company(){ Id = id };
            _business.Company.Delete(company);
            return Json(new { success = true });
        }
    }
}