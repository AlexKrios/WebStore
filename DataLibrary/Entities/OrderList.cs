using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    public class OrderList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
