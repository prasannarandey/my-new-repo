using ContinuousIntegrationAndDeployment.Data.EF;
using ContinuousIntegrationAndDeployment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContinuousIntegrationAndDeployment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PeopleContext _peopleContext;
        public HomeController(ILogger<HomeController> logger, PeopleContext peopleContext)
        {
            _logger = logger;
            _peopleContext = peopleContext;
        }

        public IActionResult Index()
        {
            var people = _peopleContext.People.OrderByDescending(x => x.Id).Take(10);
            var data = people.Select(x => new PersonDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
            return View(data);
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
