using System.ComponentModel.DataAnnotations;

namespace DoctorWheel.Models
{
    public class Shop
    {
        public int ID { get; set; }
        [Display(Name = "Shop Name")]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public virtual  Department Department{ get; set; }
    }
}