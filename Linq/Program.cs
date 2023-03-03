using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static L2O___D09.ListGenerators;
namespace Linq_day1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task1
            /*
            //-----------------1.1---------------/
            var result = ProductList.Where(prd => prd.UnitsInStock == 0).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            
            //-----------------1.2---------------/

            var result = ProductList.Where(prd => (prd.UnitsInStock != 0) && (prd.UnitPrice>3));
         
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            //-----------------1.3---------------/
            

            List<string> Numbers = new List<string>(){ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = Numbers.Where((p, i) => p.Length<i).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }

            */
            #endregion
            #region task2

            //-----------------2.1---------------/
            /*
               var result = ProductList.FirstOrDefault(prd => prd.UnitsInStock == 0); 
                Console.WriteLine(result!=null?result:"null");
            
            //-----------------2.2---------------/

            
            var result = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(result != null ? result : "null");
            
            //-----------------2.3---------------/
            List<int> Numbers = new List<int>(){ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result = Numbers.Where(val => val > 5).ToList();
            Console.WriteLine(result.ElementAt(1));
            */
            #endregion
            #region task3
            /*
            //-----------------3.1---------------/
              var result = ProductList.Select(prd => prd.Category).Distinct();
                 foreach (var item in result)
                       
                        {
                            Console.WriteLine($"{item} ");
                        }
                  
      //-----------------3.2---------------/

      var productN = ProductList.Select(prd => prd.ProductName[0]).ToList();
      var customerN = CustomerList.Select(cust => cust.CustomerID[0]).ToList();
      var result = productN.Union(customerN);
      foreach (var item in result)
      {
          Console.WriteLine($"{item} ");
      }

      //-----------------3.3---------------/
      var productN = ProductList.Select(prd => prd.ProductName[0]).ToList();
      var customerN = CustomerList.Select(cust => cust.CustomerID[0]).ToList();
      var result = productN.Intersect(customerN);
      foreach (var item in result)
      {
          Console.WriteLine($"{item} ");
      }
             //-----------------3.4---------------/
      var productN = ProductList.Select(prd => prd.ProductName[0]).ToList();
      var customerN = CustomerList.Select(cust => cust.CustomerID[0]).ToList();
      var result = productN.Except(customerN);
      foreach (var item in result)
      {
          Console.WriteLine($"{item} ");
      }

            //-----------------3.5---------------/
            var productN = ProductList.Select(prd =>prd.ProductName.Substring(prd.ProductName.Length-3,3)).ToList();
            var customerN = CustomerList.Select(cust => cust.CustomerID.Substring(cust.CustomerID.Length-3,3)).ToList();
            var result = productN.Concat(customerN);
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }

*/
            #endregion
            #region task4
            /*
            //-----------------4.1---------------/
            List<int> Numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result = Numbers.Where(val=>val%2!=0).Count();
                Console.WriteLine(result);
            
            
            //-----------------4.2---------------/

            var result = CustomerList.Select(cust => new {Customer=cust.CompanyName,OrdersNumber=cust.Orders.Length });
         
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            

            //-----------------4.3---------------/

            var result = from p in ProductList
                     
                         group p by p.Category;

            foreach (var item in result)
            {
                Console.WriteLine(item.Key +" "+ item.Count());
            }
           
            //-----------------4.4---------------/
            List<int> list = new List<int> { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result = list.Sum();
            Console.WriteLine(result);
            //-----------------4.5---------------/
           List<string> dicList = new List<string>();
            using (StreamReader reader = File.OpenText("dictionary_english.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    dicList.Add(line);
                }
            }

            var result= dicList.Select(dic => dic.Count()).Sum();

            Console.WriteLine(result);
            //-----------------4.6---------------/


            var result = from prd in ProductList
                         group prd by prd.Category;
            var Total=0;
            foreach (var item in result)
            {
                Total= item.Select(prd => prd.UnitsInStock).Sum();
                Console.WriteLine(item.Key+" "+Total);
                
            }
            //-----------------4.7---------------/

            List<string> dicList = new List<string>();
            using (StreamReader reader = File.OpenText("dictionary_english.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    dicList.Add(line);
                }
            }

            var result = dicList.Min(val => val.Count());
            Console.WriteLine(result);
          
           
            //-----------------4.8---------------/
            var result = from prd in ProductList
                         group prd by prd.Category;
            
            foreach (var item in result)
            {
                var Cheap = item.Min(prd => prd.UnitPrice);

                Console.WriteLine(item.Key + " " + Cheap);

            }
            //-----------------4.9---------------/
            var categoryList = from prd in ProductList
                           group prd by prd.Category;
            var result = from item in categoryList
                         from product in item
                         let price = item.Min(prd => prd.UnitPrice)
                         where product.UnitPrice == price
                         select product;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            
            //-----------------4.10---------------/
            List<string> dicList = new List<string>();
            using (StreamReader reader = File.OpenText("dictionary_english.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    dicList.Add(line);
                }
            }

            var result = dicList.Max(val => val.Count());
            Console.WriteLine(result);
            

            //-----------------4.11---------------/
            var result = from prd in ProductList
                         group prd by prd.Category;

            foreach (var item in result)
            {
                var expensive = item.Max(prd => prd.UnitPrice);

                Console.WriteLine(item.Key + " " + expensive);

            }
            
            //-----------------4.12---------------/

             var categoryList = from prd in ProductList
                           group prd by prd.Category;
            var result = from item in categoryList
                         from product in item
                         let price = item.Max(prd => prd.UnitPrice)
                         where product.UnitPrice == price
                         select product;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
            //-----------------4.13---------------/
            List<string> dicList = new List<string>();
            using (StreamReader reader = File.OpenText("dictionary_english.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    dicList.Add(line);
                }
            }

            //-----------------4.14---------------/
            var result = dicList.Average(val => val.Count());
            Console.WriteLine(result);
            var result = from prd in ProductList
                         group prd by prd.Category;

            foreach (var item in result)
            {
                var expensive = item.Average(prd => prd.UnitPrice);

                Console.WriteLine(item.Key + " " + expensive);

            }

            */
            #endregion
            #region task5
            /*
            //-----------------5.1---------------/
            var result = from prd in ProductList
                         orderby prd.ProductName
                          select prd ;
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            
            //-----------------5.2---------------/

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            
            var result= Arr.OrderBy(x => x, new SortMyArray());
            foreach (var item in result)
            {
                Console.Write($"{item}  ");
            }
           
            //-----------------5.3---------------/

            var result = from prd in ProductList
                         orderby prd.UnitsInStock descending
                         select prd;

            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }

            
            //-----------------5.4---------------/
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = Arr.OrderBy(x => x.Length).ThenBy(x => x, new SortMyArray());
            foreach (var item in result)
            {
                Console.Write($"{item}  ");
            }
            //-----------------5.5---------------/
              string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            
            var result= Arr.OrderBy(x => x.Length).ThenBy(x => x, new SortMyArray());
            foreach (var item in result)
            {
                Console.Write($"{item}  ");
            }
            
            //-----------------5.6---------------/

            var result = from prd in ProductList
                         orderby prd.Category,prd.UnitPrice descending
                         select prd;

            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            
            //-----------------5.7---------------/
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = Arr.OrderByDescending(x => x.Length).ThenByDescending(x => x, new SortMyArray());
            foreach (var item in result)
            {
                Console.Write($"{item}  ");
            }
            
            //-----------------5.8---------------/

            List<string> Numbers = new List<string>{ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = Numbers.Where(n => n[1] == 'i').Reverse().ToList();
            foreach (var item in result)
            {
                Console.Write($"{item}  ");
            }
            */
            #endregion
            #region task6

            //-----------------6.1---------------/
            /* var Region = (from cut in CustomerList
                           from ord in cut.Orders
                           where cut.Region == "WA"
                           select new { cut.CustomerID, ord }).Take(3);

             foreach (var item in Region)
             {
                 Console.WriteLine($"{item} ");
             }
            //-----------------6.2---------------/

            var Region = (from cut in CustomerList
                          from ord in cut.Orders
                          where cut.Region == "WA"
                          select new { cut.CustomerID, ord }).Skip(2);

            foreach (var item in Region)
            {
                Console.WriteLine($"{item} ");

               
            }

            //-----------------6.4---------------/
            List<int> Numbers = new List<int> { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result = Numbers.SkipWhile(n => n % 3 != 0);

            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
           

            //-----------------6.5---------------/
            List<int> Numbers = new List<int> { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result = Numbers.SkipWhile((n,i) => n>= i);

            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }*/
            #endregion
            #region task7

            //-----------------7.1---------------/
            /* var result = ProductList.Select(prd => prd.ProductName).ToList();
             foreach (var item in result)
             {
                 Console.WriteLine($"{item} ");
             }
            //-----------------7.2---------------/
            string[] Words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var result = Words.ToList().Select(x => new { upper = x.ToUpper(), lower = x.ToLower() });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            //-----------------7.3---------------/
            var result = ProductList.Select(prd => new { Name=prd.ProductName, Price =prd.UnitPrice}).ToList();
             foreach (var item in result)
             {
                 Console.WriteLine($"{item} ");
             }
             //-----------------7.4---------------/
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result = Arr.ToList().Select((x, i) => new { x, f= x == i });
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
            //-----------------7.5---------------/
           
           int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var result = from a in numbersA
                         from b in numbersB
                         where a < b
                         select new { a, b };
            foreach(var x in result )
            {
                Console.WriteLine(x);
            
            //-----------------7.6---------------/

            var result = from cut in CustomerList
                          from ord in cut.Orders
                          where ord.Total<500.00M 
                          select  ord ;

            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            //-----------------7.7---------------/

            var result = from cut in CustomerList
                         from ord in cut.Orders
                         where ord.OrderDate.Year >=1988
                         select ord;

            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
            */
            #endregion
            #region task8
            /* //-----------------8.1---------------/
             List<string> list = new List<string>();
             using (StreamReader reader = File.OpenText("dictionary_english.txt"))
             {
                 while (!reader.EndOfStream)
                 {
                     string line = reader.ReadLine();
                     list.Add(line);
                 }
             }
             Console.WriteLine(list.Any(x => x.Contains("ei")));

            //-----------------8.2---------------/
             
             var products = from prd in ProductList
                            group prd by prd.Category into x
                            where x.Any(prd => prd.UnitsInStock == 0)
                            select (new { category = x.Key, products = x.ToList() })
             foreach (var item in products)
             {
                 Console.WriteLine(item);

             }

             //-----------------8.3---------------/
             var products = from prd in ProductList
                            group prd by prd.Category into x
                            where x.All(p => prd.UnitsInStock > 0)
                            select (new { category = x.Key, products = x.ToList() });


             foreach (var item in products)
             {
                 Console.WriteLine(item);

             }
            */

            #endregion
            #region task9

            //-----------------9.1---------------/
            /* int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0,10,11 };
             var result = from N in Arr
                         group N by N % 5 into x
                         select new { Rem = x.Key, Num = x };

            foreach (var item in result)
            {
                Console.WriteLine("Numbers with a remainder of 0 when divided by 5", item.Rem);
                foreach (var i in item.Num)
                {
                    Console.WriteLine(i);
                }

            }
            //-----------------9.2---------------/

            List<string> dicList = new List<string>();
            using (StreamReader reader = File.OpenText("dictionary_english.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    dicList.Add(line);
                }
            }

            var result = from d in dicList
                         group d by d[0] into x
                         select new { x.Key, x };


            foreach (var item in result)
            {

                foreach (var i in item.x)
                {
                    Console.WriteLine(i);
                }

            }

            //-----------------9.3---------------/
            string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var result = Arr.GroupBy(
                   w => w.Trim(),
                   new AnagramEqualityComparer()
                   ).ToList();

            foreach (var v in result)
            {
                foreach (var i in v)
                {

                    Console.WriteLine(i);
                }

            }
            */

            #endregion

        }
    }
}
