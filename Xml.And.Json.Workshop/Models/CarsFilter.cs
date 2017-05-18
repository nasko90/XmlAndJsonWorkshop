using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xml.And.Json.Workshop.Models
{
    public class CarsFilter 
    {
        const string storagePlace = "D:\\Курсове Телерик\\Бази данни\\Json and Xml workshop\\";
        public static void FilterCars(IEnumerable<XmlQuerry> xmlQuerry, IEnumerable<Car> cars)
        {
            
            foreach (var querys in xmlQuerry)
            {
                WriteXmlFileByQuery(cars, storagePlace+querys.OutputFile);                               
            }
        }

        private static void WriteXmlFileByQuery(IEnumerable<Car> cars, string pathToSave)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(pathToSave, settings))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");

                foreach (var car in cars)
                {
                    writer.WriteStartElement("Car");
                    writer.WriteAttributeString("Price", car.Price.ToString());
                    writer.WriteAttributeString("Year", car.Year.ToString());
                    writer.WriteAttributeString("Model", car.Model);
                    writer.WriteAttributeString("Manufacturer", car.Manufacturer.Name);
                    writer.WriteElementString("TransmisionType", car.TransmissionType.ToString());
                    writer.WriteStartElement("Dealer");
                    writer.WriteAttributeString("Name", car.Dealer.Name);
                    writer.WriteStartElement("Cities");
                    foreach (var city in car.Dealer.Cities)
                    {
                        writer.WriteElementString("City", city.Name);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
