using System.Collections.Generic;
using DoctorWheel.Models;

namespace DoctorWheel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoctorWheel.DAL.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoctorWheel.DAL.DataBaseContext context)
        {
            var clients = new List<Client>
            {
                new Client{ClientID = 1, FirstName = "DRWheel", LastName = "DRWheel", Age = 0, Debt = 0, IsIndebted = false},
                new Client{ClientID = 2, FirstName = "Tomasz", LastName = "Wisniewski", Age = 21, Debt = 0, IsIndebted = false}
            };

            clients.ForEach(n => context.Clients.AddOrUpdate(p => p.LastName, n));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department{ID = 1, TownName = "Cracow"},
                new Department{ID = 2, TownName = "Raciborz"}
            };

            departments.ForEach(n => context.Departments.AddOrUpdate(p => p.TownName, n));
            context.SaveChanges();

            var cars = new List<Car>
            {
                new Car
                {
                    ID = 1,
                    DepartmentID = departments.Single(s=> s.TownName == "Cracow").ID,
                    ClientID = clients.Single(s => s.LastName == "DRWheel").ClientID,
                    Color = "black-matte",
                    Make="Mercedes",
                    Model = "G63",
                    Year = 2013,
                    LicensePlate = "XXXX",
                    InService = false,
                    IsOrdered = false,
                    FaultName = "",
                    ToSell = true,
                    Price = 320.25,
                    RepairPrecentage = 100
                },
                new Car
                {
                    ID = 2,
                    DepartmentID = departments.Single(s => s.TownName == "Raciborz").ID,
                    ClientID = clients.Single(s => s.LastName == "Wisniewski").ClientID,
                    Make = "Aston Martin",
                    Model = "Vanquish",
                    Color = "Charcoal",
                    InService = true, ToSell = false,
                    IsOrdered = false,
                    FaultName = "Scratched paint",
                    LicensePlate = "SRC 02DS",
                    Price = 0,
                    RepairPrecentage = 55,
                    Year = 2014
                }
            };

            foreach (Car car in cars)
            {
                var carInDataBase = context.Cars.SingleOrDefault(s => s.Department.ID == car.DepartmentID &&
                                                                       s.Client.ClientID == car.ClientID);
                if (carInDataBase == null)
                {
                    context.Cars.Add(car);
                }
            }
            context.SaveChanges();

            var services = new List<Service>
            {
                new Service
                {
                    ID = 1,
                    DepartmentID = departments.Single(s => s.TownName == "Cracow").ID,
                    Name = "DRWheel Cracow Service"
                },
                new Service
                {
                    ID = 2,
                    DepartmentID = departments.Single(s => s.TownName == "Raciborz").ID,
                    Name = "DRWheel Raciborz Service"
                }
            };

            foreach (Service service in services)
            {
                var serviceInDataBase = context.Services.SingleOrDefault(s => s.Department.ID == service.DepartmentID);

                if (serviceInDataBase == null)
                {
                    context.Services.Add(service);
                }
            }
            context.SaveChanges();

            var shops = new List<Shop>
            {
                new Shop
                {
                    ID=1,
                    DepartmentID = departments.Single(s => s.TownName == "Cracow").ID,
                    Name = "DRWheel Cracow Shop"
                },
                new Shop
                {
                    ID=2,
                    DepartmentID = departments.Single(s => s.TownName == "Raciborz").ID,
                    Name = "DRWheel Raciborz Shop"
                }
            };

            foreach (Shop shop in shops)
            {
                var shopInDataBase = context.Shops.SingleOrDefault(s => s.Department.ID == shop.DepartmentID);

                if (shopInDataBase == null)
                {
                    context.Shops.Add(shop);
                }
            }
            context.SaveChanges();
        }
        }
    
}
