using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjectionExample.Controllers
{
    // dependency injection -> add service in program.cs
    public class HomeController : Controller
    {
        //construction injection make it avaliable for all actions
        private readonly ICitiesService _citiesSevice1;
        private readonly ICitiesService _citiesSevice2;
        private readonly ICitiesService _citiesSevice3;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceScopeFactory serviceScopeFactory)
        {
            // instantiate citiesService
            _citiesSevice1 = citiesService1; //new CitiesService();
            _citiesSevice2 = citiesService2; //new CitiesService();
            _citiesSevice3 = citiesService3; //new CitiesService();
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index(
            //[FromServices] ICitiesService citiesSevice
            )// method injection make it avalible only for this action
        {
            List<string> cities = _citiesSevice1.GetCities();

            ViewBag.CityId1 = _citiesSevice1.ServiceInstanceId;
            ViewBag.CityId2 = _citiesSevice2.ServiceInstanceId;
            ViewBag.CityId3 = _citiesSevice3.ServiceInstanceId;

            using(IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                // inject CitiesService 
                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
                //work with DB

                ViewBag.CityId4 = citiesService.ServiceInstanceId;
            }// end of scope, it calls CitiesService.Dispose() automatically

            return View(cities);
        }
    }
}
