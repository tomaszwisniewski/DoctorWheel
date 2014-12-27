using System.Collections.Generic;

namespace DoctorWheel.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string TownName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}