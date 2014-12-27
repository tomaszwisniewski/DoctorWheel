using System.Collections.Generic;

namespace DoctorWheel.Models
{
    public class Service
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public virtual Department Department { get; set; }
    }
}