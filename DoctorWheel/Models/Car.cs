namespace DoctorWheel.Models
{
    public class Car
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int ClientID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public bool InService { get; set; }
        public bool ToSell { get; set; }
        public string FaultName { get; set; }
        public decimal RepairPrecentage { get; set; }
        public double Price { get; set; }
        public bool IsOrdered { get; set; }
        public virtual Department Department { get; set; }
        public virtual Client Client { get; set; }

    }
}