using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xml.And.Json.Workshop
{
    public class XmlQuerry
    {
        
        public string OrderBy { get; set; }
        public string OutputFile { get; set; }
        
        public IEnumerable<XmlWhereClause> XmlWhereClause { get; set; }

        public static IEnumerable<XmlQuerry> ParseQuerry(string xmlQuerry)
        {
            XDocument querryXml = XDocument.Load(xmlQuerry);

            IEnumerable<XmlQuerry> querrys =
                from querry in querryXml.Descendants("Query")
                select new XmlQuerry
                {

                    OutputFile = (string)querry.Attribute("OutputFileName"),
                    OrderBy = querry.Element("OrderBy").Value,
                    XmlWhereClause =
                                     from whereClause in querry.Descendants("WhereClause")
                                     select new XmlWhereClause()
                                     {
                                         PropertyName = (string)whereClause.Attribute("PropertyName"),
                                         Type = (string)whereClause.Attribute("Type"),
                                         Value = whereClause.Value
                                     }                   
                };

            return querrys;        
        }
    }
}
