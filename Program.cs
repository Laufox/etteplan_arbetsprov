using System;
using System.Xml;
using System.IO;

namespace Etteplan {
    class Program {
        static void Main() {

            // Define new xml document and load it with content from xml file
            XmlDocument doc = new XmlDocument();
            doc.Load("sma_gentext.xml");

            if (doc.DocumentElement == null) {
                return;
            }

            // Find root element of xml document
            XmlNode root = doc.DocumentElement;

            if (root == null) {
                return;
            }

            // Find node of tag name 'target' inside of 'trans-unit' tag with a specific id attribute
            XmlNodeList? nodeList = root.SelectNodes("descendant::trans-unit[@id='42007']/target");
            if (nodeList is null || nodeList[0]!.InnerText is null) {
                return;
            }
            
            // Get text context of node
            string? content = nodeList[0]!.InnerText;
            
            // Write content to file in data folder of project root
            using (StreamWriter outputFile = new StreamWriter("data/content.txt"))
            {
                outputFile.WriteLine(content);
            }

            Console.WriteLine("Successfully wrote to file content.txt in /data");
            
        }
    }
}