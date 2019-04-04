using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Models
{
    //Model for object user
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Age { get; set; }
    }
}
