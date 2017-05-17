using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml.And.Json.Workshop.Models;

namespace Xml.And.Json.Workshop.Models.Contracts
{
    public interface ICarJasonModel
    {

        int Year { get; set; }

        TransmisionType TransmissionType { get; set; }

        string ManufacturerName { get; set; }

        string Model { get; set; }

        double Price { get; set; }

        Dealer Dealer { get; set; }

        
    }
}
