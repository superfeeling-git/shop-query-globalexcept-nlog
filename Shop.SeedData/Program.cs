using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL;
using Shop.Model;
using System.Xml;
using System.Xml.Linq;

namespace Shop.SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();
            //加载XML文档
            xmldoc.Load(@"C:\Users\Administrator\Desktop\SetBsmInfo.xml");

            //测试代码
            try
            {
                XmlElement node = xmldoc.GetElementsByTagName("msgFrame")[0] as XmlElement;

                var node1 = node.GetXmlElement("request", "setBsmInfo", "position3D", "latitude1");
                Console.WriteLine(node1.Name);

                var node2 = node.GetXmlElement("request", "setBsmInfo", "position3D1", "latitude");
                Console.WriteLine(node2.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public static class XMLExt
    {
        public static XmlElement GetXmlElement(this XmlElement xml,params string[] name)
        {
            string path = string.Empty;
            foreach (var item in name)
            {
                var nodeList = xml.GetElementsByTagName(item);
                if(nodeList.Count == 0)
                {
                    throw new Exception(string.Format("异常路径：{0}", path));
                }
                else
                {
                    xml = nodeList[0] as XmlElement;
                }
                path += item + "/";
            }
            return xml;
        }
    }
}
