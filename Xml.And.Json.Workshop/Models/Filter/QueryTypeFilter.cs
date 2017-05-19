using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml.And.Json.Workshop.Models.Filter
{
    public class QueryTypeFilter
    {
        public static IEnumerable<Car> WhereConditions(XmlWhereClause condition, IEnumerable<Car> carsToOrder)
        {

            
                if (condition.Type.Equals("GreaterThan"))
                {
                    return carsToOrder = WhereGreater(condition, carsToOrder);
                }
                else if (condition.Type.Equals("LessThan"))
                {
                    return carsToOrder = WhereLessThan(condition, carsToOrder);
                }
                else if (condition.Type.Equals("Equals"))
                {
                return carsToOrder = WhereEquals(condition, carsToOrder);
                }
                else if (condition.Type.Equals("Contains"))
                {
                    return carsToOrder = WhereContains(condition, carsToOrder);
                }
                else
                {
                    return carsToOrder;
                }       
        }

        private static IEnumerable<Car> WhereGreater(XmlWhereClause whereConditions, IEnumerable<Car> carsToOrder)
        {
            IEnumerable<Car> filteredCars = new List<Car>();

            
                switch (whereConditions.PropertyName.ToString())
                {
                    case "Year": filteredCars = carsToOrder.Where(x => x.Year > int.Parse(whereConditions.Value)); return filteredCars; 
                    case "Price": filteredCars = carsToOrder.Where(x => x.Price > int.Parse(whereConditions.Value)); return filteredCars;
                    case "Id": filteredCars = carsToOrder.Where(x => x.Id > int.Parse(whereConditions.Value)); return filteredCars;
                    default: return filteredCars;
                }
        }

        private static IEnumerable<Car> WhereLessThan(XmlWhereClause whereConditions, IEnumerable<Car> carsToOrder)
        {
            IEnumerable<Car> filteredCars = new List<Car>();
                        
                switch (whereConditions.PropertyName.ToString())
                {
                    case "Year": filteredCars = carsToOrder.Where(x => x.Year < int.Parse(whereConditions.Value)); return filteredCars;
                    case "Price": filteredCars = carsToOrder.Where(x => x.Price < int.Parse(whereConditions.Value)); return filteredCars;
                    case "Id": filteredCars = carsToOrder.OrderBy(x => x.Id < int.Parse(whereConditions.Value)); return filteredCars;
                    default: return filteredCars;
                }
        }

        private static IEnumerable<Car> WhereEquals(XmlWhereClause whereConditions, IEnumerable<Car> carsToOrder)
        {
            IEnumerable<Car> filteredCars = new List<Car>();
       
                switch (whereConditions.PropertyName.ToString())
                {
                    case "Year": filteredCars = carsToOrder.Where(x => x.Year == int.Parse(whereConditions.Value));  ; return filteredCars;
                    case "Price": filteredCars = carsToOrder.Where(x => x.Price == int.Parse(whereConditions.Value)); return filteredCars;
                    case "Id": filteredCars = carsToOrder.Where(x => x.Id == int.Parse(whereConditions.Value)); return filteredCars;
                    case "Model": filteredCars = carsToOrder.Where(x => x.Model.Equals(whereConditions.Value)); return filteredCars;
                default: return filteredCars;
                }
        }

        private static IEnumerable<Car> WhereContains(XmlWhereClause whereConditions, IEnumerable<Car> carsToOrder)
        {
            IEnumerable<Car> filteredCars = new List<Car>();
           
                switch (whereConditions.PropertyName.ToString())
                {
                    case "Manufacturer": filteredCars = carsToOrder.Where(x => x.Manufacturer.Name.Contains(whereConditions.Value)); return filteredCars;
                    case "Model": filteredCars = carsToOrder.Where(x => x.Model.Contains(whereConditions.Value)); return filteredCars;
                    case "Dealer": filteredCars = carsToOrder.Where(x => x.Dealer.Name.Contains(whereConditions.Value)); return filteredCars;
                    default: return filteredCars;
                }
        }

    }
}
