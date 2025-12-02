using Demo.Data;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Aggregate Operators
            #region 1. Get the total units in stock for each product category.

            var groupedResult = ListGenerator.ProductList
                .GroupBy(item => item.Category)
                .Select(group => new
                {
                    CategoryName = group.Key,
                    StockCount = group.Sum(p => p.UnitsInStock)
                });

            foreach (var entry in groupedResult)
            {
                Console.WriteLine($"{entry.CategoryName}: {entry.StockCount}");
            }

            #endregion
            #region 2. Get the cheapest product in each category

            var result = ListGenerator.ProductList
                .GroupBy(p => p.Category)
                .Select(g => g.OrderBy(p => p.UnitPrice).First()); // نجيب المنتج الأرخص في كل فئة
             
            foreach (var product in result)
            {

                 Console.WriteLine($"Category: {product.Category}, Product: {product.ProductName}, Price: {product.UnitPrice}");
            }

            #endregion
            #region 3. Get cheapest products per category (refactored)

            //var cheapestPerCategory = ListGenerator.ProductList
            //    .GroupBy(item => item.Category)
            //    .Select(group =>
            //    {
            //        decimal minPrice = group.Min(p => p.UnitPrice); // أقل سعر في الفئة
            //        var cheapestProducts = group.Where(p => p.UnitPrice == minPrice).ToList();
            //        return new
            //        {
            //            CategoryName = group.Key,
            //            Products = cheapestProducts
            //        };
            //    });

            //foreach (var category in cheapestPerCategory)
            //{
            //    Console.WriteLine($"Category: {category.CategoryName}");
            //    foreach (var product in category.Products)
            //    {
            //        Console.WriteLine($"\t{product.ProductName} - ${product.UnitPrice}");
            //    }
            //}

            #endregion


            #region 4. Get the most expensive price among each category's products.

            //var Result = ListGenerator.ProductList.GroupBy(P=> P.Category).Select(P => new
            //{
            //    Category = P.Key,
            //    MostExpensivePrice = P.Max(Q => Q.UnitPrice)
            //});

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 5. Get the products with the most expensive price in each category.

            //var Result = ListGenerator.ProductList.GroupBy(P => P.Category).Select(P => new
            //{
            //    Category = P.Key,
            //    MostExpensivePrice = (from Q in P
            //                          let MaxPrice = P.Max(R => R.UnitPrice)
            //                          where Q.UnitPrice == MaxPrice
            //                          select Q)
            //});

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Category: {item.Category}");
            //    foreach (var product in item.MostExpensivePrice)
            //    {
            //        Console.WriteLine($"\tProduct: {product.ProductName}, Price: {product.UnitPrice}");
            //    }
            //}

            #endregion

            #region 6. Get the average price of each category's products.

            //var Result = ListGenerator.ProductList.GroupBy(P => P.Category).Select(P => new
            //{
            //    Category = P.Key,
            //    AveragePrice = P.Average(Q => Q.UnitPrice)
            //});

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #endregion

            #region LINQ - Set Operators

            #region 1. Find the unique Category names from Product List.

            //var Result = ListGenerator.ProductList.Select(P => P.Category).Distinct();

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.

            //var Seq01 = ListGenerator.ProductList.Select(P => P.ProductName[0]);
            //var Seq02 = ListGenerator.CustomerList.Select(C => C.CustomerName[0]);

            //var Result = Seq01.Union(Seq02).Distinct();

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.

            //var Seq01 = ListGenerator.ProductList.Select(P => P.ProductName[0]);
            //var Seq02 = ListGenerator.CustomerList.Select(C => C.CustomerName[0]);

            //var Result = Seq01.Intersect(Seq02);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            //var Seq01 = ListGenerator.ProductList.Select(P => P.ProductName[0]);
            //var Seq02 = ListGenerator.CustomerList.Select(C => C.CustomerName[0]);

            //var Result = Seq01.Except(Seq02);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates.

            //var Seq01 = ListGenerator.ProductList.Select(P => P.ProductName.Length >= 3 ? P.ProductName[^3..] : P.ProductName);
            //var Seq02 = ListGenerator.CustomerList.Select(C => C.CustomerName.Length >= 3 ? C.CustomerName[^3..] : C.CustomerName);

            //var Result = Seq01.Concat(Seq02);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #endregion

            #region LINQ - Partitioning Operators

            #region 1. Get the first 3 orders from customers in Washington.

            //var Result = ListGenerator.CustomerList.Where(C => C.City == "Washington").SelectMany(C => C.Orders).Take(3);
            //// Washington has 0 customers in the provided data.
            //// So, I chose London instead

            //Result = ListGenerator.CustomerList.Where(C => C.City == "London").SelectMany(C => C.Orders).Take(3);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington.

            //var Result = ListGenerator.CustomerList.Where(C => C.City == "Washington").SelectMany(C => C.Orders).Skip(2);
            //// Washington has 0 customers in the provided data.
            //// So, I chose London instead

            //Result = ListGenerator.CustomerList.Where(C => C.City == "London").SelectMany(C => C.Orders).Skip(2);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var Result = numbers.TakeWhile((N, I) => I < N);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 4.Get the elements of the array starting from the first element divisible by 3.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var Result = numbers.SkipWhile(N => N % 3 != 0);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 5. Get the elements of the array starting from the first element less than its position.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var Result = numbers.SkipWhile((N, I) => I < N);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #endregion

            #region LINQ - Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            //var Result = ListGenerator.DictionaryEnglish.Any(W => W.Contains("ei"));

            //Console.WriteLine(Result);

            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            //var Result = ListGenerator.ProductList.GroupBy(P => P.Category).Where(C => C.Any(P => P.UnitsInStock == 0));

            //foreach (var group in Result)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"\tProduct: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
            //    }
            //}

            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

            //var Result = ListGenerator.ProductList.GroupBy(P => P.Category).Where(C => C.All(P => P.UnitsInStock > 0));

            //foreach (var group in Result)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"\tProduct: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
            //    }
            //}

            #endregion

            #endregion

            #region LINQ – Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5.

            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //var Result = numbers.GroupBy(N => N % 5);

            //foreach (var group in Result)
            //{
            //    Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
            //    foreach (var number in group)
            //    {
            //        Console.WriteLine($"\t{number}");
            //    }
            //}

            #endregion

            #region 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input.

            //var Result = ListGenerator.DictionaryEnglish.GroupBy(W => W[0]);

            //foreach (var group in Result)
            //{
            //    Console.WriteLine($"Words that start with the letter '{group.Key}':");
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine($"\t{word}");
            //    }
            //}

            #endregion

            #region 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together.

            //String[] Arr = { "from", "salt", "earn", "last", "near", "form" };

            //var Result = Arr.GroupBy(W => new string(W.OrderBy(C => C).ToArray()));

            //foreach (var group in Result)
            //{
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine($"{word}");
            //    }
            //    Console.WriteLine("....");
            //}

            #endregion

            #endregion
        }
    }
}
