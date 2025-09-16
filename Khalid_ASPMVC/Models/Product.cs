using System.ComponentModel.DataAnnotations;

namespace Khalid_ASPMVC.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }
      
        public  string Description { get; set; }
       
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public  string Category { get; set; }

        public  DateTime CreatedDate { get; set; }
        public bool IsAvailable { get; set; }
        public  string img {  get; set; }
            


    }
}
