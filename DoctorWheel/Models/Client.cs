using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorWheel.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsIndebted { get; set; }
        public decimal Debt { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}