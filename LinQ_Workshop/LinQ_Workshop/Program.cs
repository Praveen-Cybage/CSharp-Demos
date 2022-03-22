using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            //(1)Linq to objects
            //create a csv file and fill of with data
            //create that file using that data to c# console application
            //perform filtering operations on that
            //perform sum/Avg/Min/Max
            //perform aggreagation


            //(2) Linq to objects
            //generate a list class product - Done
            //populate with proper Data in properties  - Done
            //use it peform queries - Done
            //use ordering (ascending , descending ) - Done
            //perform filtering based on a particular property e.g Price - Done

            //1. Obtained that DataSource
            var dataSource = new List<Product>()
            {
                new Product(){ProductID = 01, ProductName = "SamsungGalaxyM30S", Quantity = 5, Price = 17800},
                new Product(){ProductID = 02, ProductName = "MotoG3", Quantity = 7, Price = 13000},
                new Product(){ProductID = 03, ProductName = "RedMINote5", Quantity = 9, Price = 18000},
                new Product(){ProductID = 01, ProductName = "Nokia6600", Quantity = 3, Price = 10000},
            };


            //2. Query
            //2.1 QuerySyntax
            var querySyntax = from prdk in dataSource
                              where prdk.Price > 10000
                              select prdk;

            //2.2 MethodSyntax
            var methodSyntax = dataSource.Where(x => x.Price > 15000);


            //2.1.1 QuerySyntax
            var querySyntaxOrd = from prdk in dataSource
                                 orderby prdk.Price
                                 select prdk;

            var querySyntaxSelectMany = (from pdkSM in dataSource
                                         from pdSM1 in pdkSM.ProductName
                                         select pdSM1).ToList();

           

            //2.2.1 MethodSyntax
            var methodSyntaxOrdAsc = dataSource.OrderBy(x => x.Quantity); // Ascending
            var methodSyntaxOrdDesc = dataSource.OrderByDescending(x => x.ProductID); // Descending

            var methodSyntaxOrdDescAsc = dataSource.OrderByDescending(x => x.ProductID).ThenBy(x=> x.Price); //ProductID in Descending and Price in Ascending 

            var methodSyntaxOrdAscDesc = dataSource.OrderBy(x => x.ProductID).ThenByDescending(x => x.Price); //ProductID in Descending and Price in Ascending 



            //3. Execution

            Console.WriteLine("Price of items greater than 10,000/-");
            foreach (var item in querySyntax)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Price of items greater than 15,000/-");
            foreach (var item in methodSyntax)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }


            Console.WriteLine("-----------------------------");
            Console.WriteLine("Price of porduct in Ascending order ");
            foreach (var item in querySyntaxOrd)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Quantity of porduct in Acending order ");
            foreach (var item in methodSyntaxOrdAsc)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("ProductId of product in Descending order ");
            foreach (var item in methodSyntaxOrdDesc)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("ProductId of product in Descending order and Price in Ascending");
            foreach (var item in methodSyntaxOrdDescAsc)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("ProductId of product in Ascending order and Price in Descending");
            foreach (var item in methodSyntaxOrdAscDesc)
            {
                Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}, Quantity = {item.Quantity}, Price = {item.Price}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            foreach (var item in querySyntaxSelectMany)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            

        }
    }
}
