using System.ComponentModel.DataAnnotations;

namespace Khalid_ASPMVC.Models
{
    public class Employees
    {

        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int phonenumeber { get; set; }
        
        public  string Email  { get; set; }

        public  string Job_id { get; set; }
       
        public int Salary { get; set; }


    }
}
