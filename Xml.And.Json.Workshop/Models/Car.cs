using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml.And.Json.Workshop.Models;

namespace Xml.And.Json.Workshop.Models
{
    public class Car
    {
        private static int IdCount = 0;
        public Car()
        {
            IdCount++;
            this.Id = IdCount;
        }
        public int Id { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }

        public string Model { get; set; }

        public Dealer Dealer { get; set; }

        public TransmisionType TransmissionType { get;  set; }
        public Manufacturer Manufacturer { get;  set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Price: {this.Price}");
            sb.AppendLine($"Manufacturer {this.Manufacturer.Name}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Dealer name: {this.Dealer.Name}");
            sb.AppendLine($"Transmission type: {this.TransmissionType}");
            return sb.ToString();
        }
    }
}
