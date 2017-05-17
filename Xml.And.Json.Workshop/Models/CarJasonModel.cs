using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml.And.Json.Workshop;
using Xml.And.Json.Workshop.Models;
using Xml.And.Json.Workshop.Models.Contracts;

namespace Xml.And.Json.Workshop
{
    public class CarJasonModel : ICarJasonModel
    {

        public Dealer Dealer { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public TransmisionType TransmissionType { get; set; }

        public int Year { get; set; }

        public static Func<CarJasonModel, Car> FromJsonModel
        {
            get
            {
                return jsomModel => new Car
                {
                    Model = jsomModel.Model,
                    Dealer = new Dealer
                    {
                        Name = jsomModel.Dealer.Name,
                        Cities = new List<City> { new City { Name = jsomModel.Dealer.City } }
                    },
                    Manufacturer = new Manufacturer
                    {
                        Name = jsomModel.ManufacturerName
                    },
                    Price = jsomModel.Price,
                    TransmissionType = jsomModel.TransmissionType,
                    Year = jsomModel.Year
                };
            }
        }
    }
}
