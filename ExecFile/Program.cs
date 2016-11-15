using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XMLParserApplication.Models;

namespace ExecFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Item s = new Item();
            s.Title = "sss";

            string uri = "https://www.lagboken.se/Lagboken/RSS-floden/LagbokenNyheter/";
            string path = "C:\\Users\\Benjamin\\Desktop\\laddaned.xml";

            var xmlPareser = new XmlParser<Rss>();
            var Rss = xmlPareser.Parse(uri);
            var g = Rss.Channel.Items.Take(5);

            Console.ReadLine();






            /*  switch (reader.NodeType)
              {
                  case XmlNodeType.Element: // The node is an element.
                      Console.Write("<" + reader.Name);

                      while (reader.MoveToNextAttribute()) // Read the attributes.
                          Console.Write(" " + reader.Name + "='" + reader.Value + "'");
             
                      Console.WriteLine(">");
                      break;
                  case XmlNodeType.Text: //Display the text in each element.
                      Console.WriteLine(reader.Value);
                      break;
                  case XmlNodeType.EndElement: //Display the end of the element.
                      Console.Write("</" + reader.Name);
                      Console.WriteLine(">");
                      break;
         
            }*/
        }


        public static async  void Testf()
        {
            string uri = "https://www.lagboken.se/Lagboken/RSS-floden/LagbokenNyheter/";
            string path = "C:\\Users\\Benjamin\\Desktop\\laddaned.xml";

            var XmlP = new XmlParser<Rss>();
            var s = await XmlP.ParseAsync(uri);

        }

    }
}
