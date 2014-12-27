using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorWheel.Models;

namespace DoctorWheel.DAL
{
    public class DataBaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            var cars = new List<Car>
            {
                new Car{ID = 1,Color = "black-matte", DepartmentID = 1, Make="Mercedes", Model = "G63", Year = 2013, LicensePlate = "XXXX", InService = false, IsOrdered = false, FaultName = "", ToSell = true, Price = 320.25, RepairPrecentage = 100},
                new Car{ID = 2, DepartmentID = 2, ClientID = 1, Make = "Aston Martin", Model = "Vanquish", Color = "Charcoal", InService = true, ToSell = false, IsOrdered = false, FaultName = "Scratched paint", LicensePlate = "SRC 02DS", Price = 0, RepairPrecentage = 55, Year = 2014}
            };
            
            cars.ForEach(n => context.Cars.Add(n));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{ClientID = 1, FirstName = "Tomasz", LastName = "Wisniewski", Age = 21, Debt = 0, IsIndebted = false}
            };

            clients.ForEach(n => context.Clients.Add(n));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department{ID = 1, TownName = "Cracow"},
                new Department{ID = 2, TownName = "Raciborz"}
            };

            departments.ForEach(n => context.Departments.Add(n));
            context.SaveChanges();

            var services = new List<Service>
            {
                new Service{ID = 1, DepartmentID = 1, Name = "DRWheel Cracow Service"},
                new Service{ID = 2, DepartmentID = 2, Name = "DRWheel Raciborz Service"}
            };

            services.ForEach(n => context.Services.Add(n));
            context.SaveChanges();

            var shops = new List<Shop>
            {
                new Shop{ID=1, DepartmentID = 1, Name = "DRWheel Cracow Shop"},
                new Shop{ID=2, DepartmentID = 2, Name = "DRWheel Raciborz Shop"}
            };

            shops.ForEach(n => context.Shops.Add(n));
            context.SaveChanges();

        }
    }
}