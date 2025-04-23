using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities = new List<string>();
        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId { 
            get 
            {
                return _serviceInstanceId;
            } 
        }

        // from db
        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            };
            // add logic open db connection
        }

        // fetching database
        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            //add logic to close db connection
        }
    }
}
