namespace WebStoreAPI.Requests.Cities
{
    public class GetCitiesRequest
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}