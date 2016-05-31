using System.ComponentModel.DataAnnotations;

namespace angular2_asp.Models
{
    public class Customer
    {         
        public Customer(){}    
        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }
        [StringLength(30)]       
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        
        //I hate this but fkit
        public void DeepCopy(Customer item){                         
             this.CompanyName = item.CompanyName;
             this.ContactName = item.ContactName;
             this.Address = item.Address;
             this.City = item.City;
             this.PostalCode = item.PostalCode;
             this.Country = item.Country;
             this.Phone = item.Phone; 
        }
    }
}