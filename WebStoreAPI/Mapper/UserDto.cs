using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Mapper
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
