using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA_Online_Mart.Models
{
    public class Cart
    {
        [Key]
        public int CartItemId { get; set; }

        [ForeignKey("AppUser")] // Explicitly specifies that UserId is a foreign key
        public string UserId { get; set; }

        [ForeignKey("Product")] // Explicitly specifies that ProductId is a foreign key
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        // Navigation properties
        public AppUser User { get; set; }
        public Product Product { get; set; }

    }
}
