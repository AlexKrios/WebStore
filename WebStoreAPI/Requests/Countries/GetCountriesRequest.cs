namespace WebStoreAPI.Requests.Countries
{
    public class GetCountriesRequest
    {
        public string Name { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
