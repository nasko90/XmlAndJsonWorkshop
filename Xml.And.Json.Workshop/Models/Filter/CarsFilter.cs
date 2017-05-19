using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xml.And.Json.Workshop.Models.Filter;

namespace Xml.And.Json.Workshop.Models
{
    public class CarsFilter 
    {
        const string storagePlace = "D:\\Курсове Телерик\\Бази данни\\Json and Xml workshop\\";
        public static void FilterCars(IEnumerable<XmlQuerry> xmlQuerry, IEnumerable<Car> cars)
        {

            List<XmlQuerry> queryToList = xmlQuerry.ToList();

            for (int i = 0; i < queryToList.Count(); i++)
            {
                
                foreach (var condition in queryToList[i].XmlWhereClause)
                {                    
                    cars = QueryTypeFilter.WhereConditions(condition, cars);                   
                }
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id);
                }


                cars = OrderCarsBy(queryToList[i].OrderBy, cars);
                WriteXmlFileByQuery(cars, storagePlace + queryToList[i].OutputFile);
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

        private static IEnumerable<Car> OrderCarsBy(string orderBy, IEnumerable<Car> carsToOrder)
        {
            IEnumerable<Car> filteredCars = new List<Car>();

            switch (orderBy)
            {
                case "Year": filteredCars = carsToOrder.OrderBy(x => x.Year); return filteredCars;
                case "Price": filteredCars = carsToOrder.OrderBy(x => x.Price); return filteredCars;
                case "Id": filteredCars = carsToOrder.OrderBy(x => x.Id); return filteredCars;
                default: return filteredCars;
            }
        }
        

    }
}
