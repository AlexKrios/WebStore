namespace WebStoreAPI.Requests.Cities
{
    public class GetCitiesRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}