using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace program1

{   [Serializable]
   public class OrderService
    {

        public void AddOrder(Order order) {
            using(var db=new DataBase())
            {
               db.Orders.Add(order);
                db.SaveChanges();
            }
          
        }

        public void RemoveOrder(string orderNum)
        {
            using (var db = new DataBase())
            {
                var order = db.Orders.Include("OrderDetails").SingleOrDefault(o => o.OrderNum == orderNum);
                db.OrderDetails.RemoveRange(order.OrderDetails);
                db.Orders.Remove(order);
            }

        }

        public void Update(Order order)
        {
            using (var db = new DataBase())
            {
                db.Orders.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.OrderDetails.ForEach(
                    od => db.Entry(od).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public Order GetOrder(String Id)
        {
            using (var db = new DataBase())
            {
                return db.Orders.Include("OrderDetails"). SingleOrDefault(o => o.OrderNum == Id);
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new DataBase())
            {
                return db.Orders.Include("OrderDetails").ToList<Order>();
            }
        }

        public List<Order> FindOrderByClientName(string name)
        {
            using (var db = new DataBase())
            {
                return db.Orders.Include("OrderDetails")
                  .Where(o => o.ClientName.Equals(name)).ToList<Order>();
            }
        }

        public List<Order> FindOrderByProductBrand(Products brand)
        {
            using (var db = new DataBase())
            {
                var query = db.Orders.Include("OrderDetails")
                     .Where(o => o.OrderDetails.Where(
            od => od.Brand.Equals(brand)).Count() > 0);
                return query.ToList();
            }
        }

        public OrderService() { }
        
        public void Export(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderService));
            string xmlFileName = path;

            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            xmlSerializer.Serialize(fs, this);
            fs.Close();

            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, this);
            sw.Close();

            Console.Write(sw.ToString());
        }

        public static OrderService Import(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderService));
            OrderService orderService = (OrderService)xmlSerializer.Deserialize(file);
            file.Close();

            Console.WriteLine("Import: ");

            return orderService;
        }

        public void xslT(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path+".xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(path+".xslt");

                FileStream outFileStream = File.OpenWrite(path + ".html");
                XmlTextWriter writer = new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);


            }
            catch (XmlException e)
            {
                Console.WriteLine("XML Exception:" + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("XSLT Exception:" + e.ToString());
            }
        }

        public static string ConvertXML(XmlDocument InputXMLDocument, string XSLTFilePath, XsltArgumentList XSLTArgs)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            XslCompiledTransform xslTrans = new XslCompiledTransform();
            xslTrans.Load(XSLTFilePath);
            xslTrans.Transform(InputXMLDocument.CreateNavigator(), XSLTArgs, sw);
            return sw.ToString();
        }
    }
}
