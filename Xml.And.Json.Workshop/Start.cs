using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xml.And.Json.Workshop;
using System.Collections;
using Xml.And.Json.Workshop.Models.Contracts;
using Xml.And.Json.Workshop.Models;
using System.Xml;
using System.Xml.Linq;

namespace Xml.And.Json.Workshop
{
    class Start
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("D:\\Курсове Телерик\\Бази данни\\Json and Xml workshop\\data.number.txt");


            IEnumerable <CarJasonModel> carJsonModels = JsonConvert.DeserializeObject<List<CarJasonModel>>(json);
            IEnumerable<Car> cars = carJsonModels.Select(CarJasonModel.FromJsonModel);

            var querry = XmlQuerry.ParseQuerry("D:\\Курсове Телерик\\Бази данни\\Json and Xml workshop\\Querry.xml");
            

            CarsFilter.FilterCars(querry,cars); 

           
        }
    }
}
