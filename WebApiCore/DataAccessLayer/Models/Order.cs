using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int CustomerId { get; set; }
    }
}
