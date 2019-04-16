namespace WebStoreAPI.Requests.Cities
{
    public class GetCityRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
