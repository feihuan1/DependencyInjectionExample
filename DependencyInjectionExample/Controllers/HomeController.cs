using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjectionExample.Controllers
{
    // dependency injection -> add service in program.cs
    public class HomeController : Controller
    {
        // construction injection make it avaliable for all actions
        //private readonly ICitiesService _citiesSevice;
        //public HomeController(ICitiesService citiesService)
        //{
        //    // instantiate citiesService
        //    _citiesSevice = citiesService; //new CitiesService();
        //}

        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService citiesSevice)// method injection make it avalible only for this action
        {
            List<string> cities = citiesSevice.GetCities();
            return View(cities);
        }
    }
}
