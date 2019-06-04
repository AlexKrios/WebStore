using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    public class RefreshToken
    {
        [Key, StringLength(450)]
        public string Id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
        [Required, StringLength(450)]
        public string Token { get; set; }
        [ForeignKey("User") ,StringLength(450)]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
