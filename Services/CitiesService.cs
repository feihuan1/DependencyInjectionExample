using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities = new List<string>();
        // from db
        public CitiesService()
        {
            _cities = new List<string>()
            {
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            };
        }

        // fetching database
        public List<string> GetCities()
        {
            return _cities;
        }

    }
}
