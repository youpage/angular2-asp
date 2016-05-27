using System.ComponentModel.DataAnnotations.Schema;

namespace angular2_asp.Models
{
    [Table("Order Details")]
    public class OrderDetail
    {
        public virtual Product Product { get; set; }        
        public OrderDetail(){}          
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }                       
    }
}