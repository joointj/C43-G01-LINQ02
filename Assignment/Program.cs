using static Assignment.ListGenerator ;
namespace Assignment;

class Program
{
    class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            char[] xchars = x?.ToCharArray() ?? new char[0];
            char[] ychars = y?.ToCharArray() ?? new char[0];
            Array.Sort(xchars);
            Array.Sort(ychars);

            return xchars.SequenceEqual(ychars);
        }

        public int GetHashCode(string obj)
        {
            char[] xchars = obj.ToCharArray();
            Array.Sort(xchars);
            HashCode hash = new HashCode();
            foreach (var item in xchars)
            {
                hash.Add(item);
            }

            return hash.ToHashCode();
        }
    }
    static void Main(string[] args)
    {
        #region LINQ - Aggregate Operators

        #region 1. Uses Count to get the number of odd numbers in the array

        // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // int count = Arr.Count(N => N % 2 != 0);
        // Console.WriteLine(count);

        #endregion

        #region 2. Return a list of customers and how many orders each has.
        // var Result = CustomersList.Select(C => new {Customer = C , OrderCount = C.Orders.Count()});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"CustomerID: {item.Customer}, OrderCount: {item.OrderCount}");
        // }
        //

        #endregion

        #region 3. Return a list of categories and how many products each has
        // var Result = ProductsList.GroupBy(P => P.Category , (C , P) => new {Category = C , ProductCount = P.Count()});
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, ProductCount: {item.ProductCount}");
        // }


        #endregion

        #region 4. Get the total of the numbers in an array.

        // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0}; 
        // var Total = Arr.Sum();
        // Console.WriteLine(Total);

        #endregion

        #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

        // string[] Words = System.IO.File.ReadAllLines("dictionary_english.txt");
        // var Result = Words.Sum(W => W.Length);
        // Console.WriteLine(Result);

        #endregion

        #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

        // string[] Words = System.IO.File.ReadAllLines("dictionary_english.txt");
        // var Result = Words.Min(W => W.Length);
        // Console.WriteLine(Result);

        #endregion

        #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

        // string[] Words = File.ReadAllLines("dictionary_english.txt");
        // var Result = Words.Max(W => W.Length);
        // Console.WriteLine(Result);

        #endregion

        #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

        // string[] Words = File.ReadAllLines("dictionary_english.txt");
        // var Result = Words.Average(W => W.Length);
        // Console.WriteLine(Result);

        #endregion

        #region 9. Get the total units in stock for each product category.

        // var Result = ProductsList.GroupBy(P => P.Category , (C , P) => new {Category = C , TotalUnitsInStock = P.Sum(P => P.UnitsInStock)});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, TotalUnitsInStock: {item.TotalUnitsInStock}");
        // }

        #endregion

        #region 10. Get the cheapest price among each category's products

        // var Result = ProductsList.GroupBy(P => P.Category , (C , P) => new {Category = C , CheapestPrice = P.Min(P => P.UnitPrice)});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, CheapestPrice: {item.CheapestPrice}");
        // }

        #endregion

        #region 11. Get the products with the cheapest price in each category (Use Let)

        // var Result = from P in ProductsList
        //     group P by P.Category
        //     into G
        //     let CheapestPrice = G.Min(P => P.UnitPrice)
        //     let Products = G.Where(P => P.UnitPrice == CheapestPrice)
        //     select new {Category = G.Key, CheapestPrice, Products};
        //
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, CheapestPrice: {item.CheapestPrice}");
        //     foreach (var product in item.Products)
        //     {
        //         Console.WriteLine($"Product: {product.ProductName}, Price: {product.UnitPrice}");
        //     }
        // }



        #endregion

        #region 12. Get the most expensive price among each category's products.
        
        // var Result = ProductsList.GroupBy(P => P.Category , (C , P) => new {Category = C , MostExpensivePrice = P.Max(P => P.UnitPrice)});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, MostExpensivePrice: {item.MostExpensivePrice}");
        // }
        //

        #endregion

        #region 13. Get the products with the most expensive price in each category.

        // var Result = ProductsList.GroupBy(P => P.Category , (C , P) => new {Category = C , MostExpensivePrice = P.Max(P => P.UnitPrice) , Products = P})
        //     .Select(PCategory => new {PCategory.Category , PCategory.MostExpensivePrice , Products = PCategory.Products.Where(P => P.UnitPrice == PCategory.MostExpensivePrice)});
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, MostExpensivePrice: {item.MostExpensivePrice}");
        //     foreach (var product in item.Products)
        //     {
        //         Console.WriteLine($"Product: {product.ProductName}, Price: {product.UnitPrice}");
        //     }
        // }
        #endregion

        #region 14. Get the average price of each category's products.

        // var Result = ProductsList.GroupBy(P => P.Category , (C , P) => new {Category = C , AveragePrice = P.Average(P => P.UnitPrice)});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}, AveragePrice: {item.AveragePrice}");
        // }

        #endregion

        #endregion

        #region LINQ - Set Operators

        #region 1. Find the unique Category names from Product List

        // var Result = ProductsList.DistinctBy(P => P.Category);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item.Category);
        // }


        #endregion

        #region 2. Produce a Sequence containing the unique first letter from both product and customer names.
        
        // var ProductCharecters = ProductsList.Select(P => P.ProductName[0]);
        // var CustomerCharecters = CustomersList.Select(C => C.CustomerName[0]);
        // var Result = ProductCharecters.Union(CustomerCharecters);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        #endregion

        #region 3. Create one sequence that contains the common first letter from both product and customer names.

        // var ProductCharecters = ProductsList.Select(P => P.ProductName[0]);
        // var CustomerCharecters = CustomersList.Select(C => C.CustomerName[0]);
        // var Result = ProductCharecters.Intersect(CustomerCharecters);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion

        #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

        // var ProductCharecters = ProductsList.Select(P => P.ProductName[0]);
        // var CustomerCharecters = CustomersList.Select(C => C.CustomerName[0]);
        // var Result = ProductCharecters.Except(CustomerCharecters);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion

        #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

        // var ProductCharecters = ProductsList.Select(P => P.ProductName.Substring(P.ProductName.Length - 3));
        // var CustomerCharecters = CustomersList.Select(C => C.CustomerName.Substring(C.CustomerName.Length - 3));
        // var Result = ProductCharecters.Concat(CustomerCharecters);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        #endregion

        #endregion

        #region LINQ - Partitioning Operators

        #region 1. Get the first 3 orders from customers in Washington
        
        // var Result = CustomersList.Where(C => C.City == "Washington")
        //     .Select(C => new {Customer = C , Orders = C.Orders.Take(3)});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Customer: {item.Customer.CustomerName}");
        //     foreach (var order in item.Orders)
        //     {
        //         Console.WriteLine(order);
        //     }
        // }
        

        #endregion

        #region 2. Get all but the first 2 orders from customers in Washington.

        // var Result = CustomersList.Where(C => C.City == "Washington")
        //     .Select(C => new {Customer = C , Orders = C.Orders.Skip(2)});
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Customer: {item.Customer.CustomerName}");
        //     foreach (var order in item.Orders)
        //     {
        //         Console.WriteLine(order);
        //     }
        // }


        #endregion

        #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

        // int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = numbers.TakeWhile((N , Index) => N > Index);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion

        #region 4.Get the elements of the array starting from the first element divisible by 3.

        // int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = numbers.SkipWhile(N => N % 3 != 0);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion

        #region 5. Get the elements of the array starting from the first element less than its position.

        // int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = numbers.SkipWhile((N , Index) => N >= Index);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion
        

        #endregion

        #region LINQ - Quantifiers

        #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

        // string [] Words = File.ReadAllLines("dictionary_english.txt");
        // Console.WriteLine(Words.Any(W => W.Contains("ei")));
        
        

        #endregion

        #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

        // var Result = from P in ProductsList
        //     group P by P.Category
        //     into G
        //     where G.Any(P => P.UnitsInStock == 0)
        //     select new {Category = G.Key , Products = G};
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}");
        //     foreach (var product in item.Products)
        //     {
        //         Console.WriteLine($"Product: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
        //     }
        // }

        #endregion

        #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

        // var Result = from P in ProductsList
        //     group P by P.Category
        //     into G
        //     where G.All(P => P.UnitsInStock > 0)
        //     select new {Category = G.Key , Products = G};
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Category: {item.Category}");
        //     foreach (var product in item.Products)
        //     {
        //         Console.WriteLine($"Product: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
        //     }
        // }

        #endregion

        #endregion

        #region LINQ – Grouping Operators

        #region 1. Use group by to partition a list of numbers by their remainder when divided by 5

        // List<int> numbers = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        // var Result = numbers.GroupBy(N => N % 5);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Numbers with a remainder of {item.Key} when divided by 5");
        //     foreach (var number in item)
        //     {
        //         Console.WriteLine(number);
        //     }
        // }

        #endregion

        #region 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
        // string[] words = File.ReadAllLines("dictionary_english.txt");
        // var Result = words.GroupBy(W => W[0]);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"Words starting with {item.Key}");
        //     foreach (var word in item)
        //     {
        //         Console.WriteLine(word);
        //     }
        // }

        #endregion

        #region 3. Consider this Array as an Input Use Group By with a custom comparer that matches words that are consists of the same Characters Together

        // String [] Arr = {"from", "salt", "earn", "last", "near", "form" , "rofm"};
        // var Result = Arr.GroupBy(W => W , new StringEqualityComparer());
        // foreach (var item in Result)
        // {
        //     // Console.WriteLine($"Words with the same characters: {item.Key}");
        //     foreach (var word in item)
        //     {
        //         Console.WriteLine(word);
        //     }
        //
        //     Console.WriteLine("--------------------");
        // }

        #endregion

        #endregion


    }
}