using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml.And.Json.Workshop.Models.Contracts;

namespace Xml.And.Json.Workshop.Models
{
    public class Dealer 
    {
        public Dealer(string name, List<City> cities)
        {
            this.Name = name;
            this.Cities = cities;
        }
        
        public  Dealer()
        {

        }

        public string Name { get; set; }

        public List<City> Cities { get; set; }
        public string City { get; set; }
    }
}
