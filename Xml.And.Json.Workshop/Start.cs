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

namespace Xml.And.Json.Workshop
{
    class Start
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("C:\\Users\\NADIA\\Desktop\\data.number.txt");


            IEnumerable <CarJasonModel> carJsonModels = JsonConvert.DeserializeObject<List<CarJasonModel>>(json);
            IEnumerable<Car> cars = carJsonModels.Select(CarJasonModel.FromJsonModel);

            var ordered = cars.OrderBy(x => x.Year);

            foreach (var item in ordered)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
