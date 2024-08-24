using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA_Online_Mart.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }

        // Navigation properties
        public AppUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
