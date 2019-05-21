namespace WebStoreAPI.Requests.Cities
{
    public class GetCitiesRequest
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}