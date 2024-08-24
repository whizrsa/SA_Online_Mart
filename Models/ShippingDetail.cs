using System.ComponentModel.DataAnnotations;

namespace SA_Online_Mart.Models
{
    public class ShippingDetail
    {
        [Key]
        public int ShippingDetailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
