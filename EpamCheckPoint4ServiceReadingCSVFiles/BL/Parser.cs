using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALClassLibrary;
using System.IO;
using System.Text.RegularExpressions;
using DALClassLibrary.DAL;

namespace BL
{
   public class Parser
    {
       private readonly OrdersRepository _orders = new OrdersRepository();

       public void ParserFiles(string filePath, string fileName)
       {
           try
           {
               using (var r = new StreamReader(filePath))
               {
                   string line;
                   var nameManager = Regex.Split(fileName, @"_");
                   while ((line = r.ReadLine()) != null)
                   {
                       var data = Regex.Split(line, @";");
                       CreateOrder(data, nameManager[0]);
                   }
                   _orders.SaveOrders();
               }
           }
           catch (Exception exception)
           {
               Console.WriteLine(exception);
           }
       }

       private void CreateOrder(string[] item, string nameManager)
       {
           var date = Convert.ToDateTime(item[0]);
           var client = new Client(item [1],null,0);
           var product = new Product(item[2]);
           var sum = (float)Convert.ToDouble(item[3]);
           var manager = new Manager(nameManager,"");
           _orders.Add(new Order(date,client,product,manager,sum));
       }
    }
}
