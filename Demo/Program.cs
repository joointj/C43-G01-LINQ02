using System.Collections.Immutable;
using System.Text.RegularExpressions;
using static Demo.ListGenerator;
namespace Demo;


class Program
{
    class ProductComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            return x?.UnitsInStock.CompareTo(y?.UnitsInStock) ?? (y is null ? 0 : -1);
        }
    }

    class ProductComparerTwo : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
    class StringEqulityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            return x?.ToLower().Equals(y?.ToLower()) ?? (y is null);
        }

        public int GetHashCode(string obj)
        {
            return obj?.ToLower().GetHashCode() ?? 0;
        }
    }
    class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            return x?.ProductID.Equals(y?.ProductID) ?? (y is null);
        }

        public int GetHashCode(Product obj)
        {
            return obj?.ProductID.GetHashCode() ?? 0;
        }
    }
    static void Main(string[] args)
    {
        #region Aggregate operators - [Immediate execution] Count , GetNonEnumeratedCount
        // 1- Get the number of products in the product list 
        // var Result = ProductsList.Count();
        // Result = ProductsList.Count;
        // Console.WriteLine(Result);
        
        // 2- Try to get number of elements in IEnumerable of 100 number 
        // IEnumerable<int> Numbers = Enumerable.Range(1, 100);
        // var Result = Numbers.Count();
        
        // 3- Get number of products out of stock
        // var Result = ProductsList.Where(P => P.UnitsInStock == 0).Count();
        // Result = ProductsList.Count(P => P.UnitsInStock == 0); // overload of count method
        // Console.WriteLine(Result);
        
        // 4- get number of products in product list 
        // bool Result = ProductsList.TryGetNonEnumeratedCount(out int count);
        // Console.WriteLine(count);
        
        // 5- get number of elements in list [GetNonEnumeratedCount]
        // List<int> Numbers = new List<int> {1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10};
        // bool Result = Numbers.TryGetNonEnumeratedCount(out int count);
        // Console.WriteLine(count);    
        
        // var Result = ProductsList.Where(P => P.UnitPrice > 0).TryGetNonEnumeratedCount(out int count);
        // Console.WriteLine(count);
        
        // IEnumerable<int> Numbers = Enumerable.Range(1, 10);
        // var Result = Numbers.TryGetNonEnumeratedCount(out int count);
        // Console.WriteLine(count);

        #endregion

        #region Aggregate operators - [Immediate execution] Sum , Average 
        // 1- Get sum of prices of all products
        // var Result = ProductsList.Sum(P => P.UnitPrice);
        // Console.WriteLine(Result);

        // 2- Get the avg of prices of all products 
        // var Result = ProductsList.Average(P => P.UnitPrice);
        // Console.WriteLine(Result);

        #endregion

        #region Aggregate operators - [Immediate execution] - Min , Max , MinBy , MaxBy
        // // 1- get the max , min product
        // // var Result = ProductsList.Max();
        // // Result = ProductsList.Min();
        // // Console.WriteLine(Result);
        //
        // // 2- get the max , min product based on different conditions [Product Comparator]
        // // var Result = ProductsList.Max(new ProductComparer());
        // // Result = ProductsList.Min(new ProductComparer());
        // // Console.WriteLine(Result);
        //
        // // 3- get max , min product based on unit in stock [order by]
        // // var Result = ProductsList.OrderByDescending(P => P.UnitsInStock).FirstOrDefault();
        // // Result = ProductsList.OrderBy(P => P.UnitsInStock).FirstOrDefault();
        // // Console.WriteLine(Result);
        //
        //
        // // .NET 6
        // // 4- find max , min product due to the unit price
        // // var Result = ProductsList.MaxBy(P => P.UnitPrice);
        // // Result = ProductsList.MinBy(P => P.UnitPrice);
        // // Console.WriteLine(Result);
        //
        // // 5- find max , min product due to the unit in stock
        // // var Result = ProductsList.MaxBy(P => P.UnitsInStock , new ProductComparerTwo());
        // // // Result = ProductsList.MinBy(P => P.UnitsInStock);
        // // Console.WriteLine(Result);
        //
        // // 11 overload of Min , Max
        // // 6- find the highest , lowest value of the price in the product prices 
        // // var Result = ProductsList.Max(P => P.UnitPrice);
        // // Result = ProductsList.Min(P => P.UnitPrice);
        // // Console.WriteLine(Result);
        //
        // // 7- find the highest , lowest value of the name of the product
        // var Result = ProductsList.Max(P => P.ProductName);
        // // Result = ProductsList.Min(P => P.ProductName);
        // Console.WriteLine(Result); 





        #endregion

        #region Agfregate operators - Aggregate , Aggregate
        // // to make custom aggregation function 
        // // try to combine names 
        // string [] names = {"Ahmed" , "Mohamed" , "Ali" , "Hassan"};
        // // string FullName = names.Aggregate((str1 , str2) => str1 + " " + str2);
        // // Console.WriteLine(FullName);
        //
        // // second overload --> seed value
        // // string FullName = names.Aggregate("Hello : " , (str1 , str2) => str1 + " " + str2);
        // // Console.WriteLine(FullName);
        //
        // // third overload --> seed value , aggregation function , modification of the result 
        // string FullName = names.Aggregate("Hello : " , (str1 , str2) => str1 + " " + str2 , TAcc => TAcc.Replace(" " , "$"));
        // Console.WriteLine(FullName);

        #endregion

        #region Casting/Conversion operators [Immediate execution] 
        // // 1- get all products out of stock and convert them to list
        // List<Product> Result = ProductsList.Where(P => P.UnitsInStock == 0).ToList();
        //
        // // 2- get all products out of stock and convert them to array
        // Product [] Result2 = ProductsList.Where(P => P.UnitsInStock == 0).ToArray();
        //
        // // 3- get products Id and products for products out of stock and store them in dictionary
        // Dictionary <long , Product> Result3 = ProductsList.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductID);
        //
        // Dictionary<long , string> Result4 = ProductsList.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductID , P => P.ProductName);
        //
        // Dictionary<string , Product > Result5 = ProductsList.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductName , P => P , new StringEqulityComparer());
        //
        // Dictionary<string , long> Result6 = ProductsList.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductName , P => P.ProductID , new StringEqulityComparer());
        //
        // // 5- get products out of stock and convert them to hashset
        // HashSet<Product> Result7 = ProductsList.Where(P => P.UnitsInStock == 0).ToHashSet();
        // HashSet<Product> Result8 = ProductsList.Where(P => P.UnitsInStock == 0).ToHashSet(new ProductEqualityComparer());
        //
        // //  6- get products out of stock and store them in Immutable Sorted Set
        //
        // ImmutableSortedSet<Product> Result9 = ProductsList.Where(P => P.UnitsInStock == 0).ToImmutableSortedSet();
        // Result9.Add(new Product() { ProductName = "Hamada" });
        // foreach (var item in Result9)
        // {
        //     Console.WriteLine(item);
        // }





        #endregion

        #region Generation Operators [Range , Repeat , Empty ]
        // // 1- create sequence of numbers from 0 to 99
        // // var Result = Enumerable.Range(0, 100);
        // // foreach (var item in Result)
        // // {
        // //     Console.Write(item + " ");
        // // }
        // //
        // // 2- Repeat number 2 --> 100 times 
        // // var Result = Enumerable.Repeat(2, 100);
        // // var Result = Enumerable.Repeat(new Product() { Category = "Meat" }, 100);
        // // foreach (var item in Result)
        // // {
        // //     Console.WriteLine(item );
        // // }
        //
        // // 3- Generate empty sequence
        // var Result = Enumerable.Empty<int>(); // must define the generic type 
        
        



        #endregion

        #region Set Operators [Union , Concat , Except , Intersect]
        // work based on equals and gethashcode
        // add sequence 0 , 100 , square 50 , 100
        // var Sequence1 = Enumerable.Range(0, 100); // 0 99
        // var Sequence2 = Enumerable.Range(50, 100); // 50 149
        
        // foreach (var item in Sequence1)
        // {
        //     Console.Write(item + " ");
        // }
        // Console.WriteLine();
        // foreach (var item in Sequence2)
        // {
        //     Console.Write(item + " ");
        // }
        
        // union
        // 1- merge two sequences and remove duplicates
        // var Result = Sequence1.Union(Sequence2);
        // Result = Sequence1.Concat(Sequence2);
        // Result = Sequence1.Distinct();
        // Result = Sequence1.Intersect(Sequence2);
        // Result = Sequence1.Except(Sequence2);
        // foreach (var item in Result)
        // {
        //     Console.Write(item + " ");
        // }
        //
        //
        // var Seq1 = new List<Product>()
        // {
        //     new Product()
        //         { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100 },
        //     new Product()
        //         { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
        //     new Product()
        //         { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 }
        //     
        // };
        // var Seq2 = new List<Product>()
        // {
        //     new Product()
        //         { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100 },
        //     new Product()
        //         { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
        //     new Product()
        //         { ProductID = 4, ProductName = "Chef Aston's Cajun Seasoning", Category = "Condiments", UnitPrice = 18.00M, UnitsInStock = 39 },
        //     new Product()
        //         { ProductID = 5, ProductName = "Chef Aston's Gumbo Mix", Category = "Condiments", UnitPrice = 18.00M, UnitsInStock = 0 },
        // };
        
        // var Result = Seq1.Union(Seq2);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        
        // merge two sequences and remove duplicates but modify the comparing logic
        // Result = Seq1.Union(Seq2, new ProductEqualityComparer());
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        
        
        // union by
        // var Result = Seq1.UnionBy(Seq2, P => P.ProductName);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        
        // intersect 
        // var Result = Seq1.Intersect(Seq2);
        // Result = Seq1.Intersect(Seq2, new ProductEqualityComparer());
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        // var Result = Seq1.IntersectBy(Seq2.Select(P => P.ProductID), P => P.UnitsInStock);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        
        // var Result = Seq1.Except(Seq2);
        // var Result = Seq1.ExceptBy(Seq2.Select(P => P.UnitPrice), P => P.UnitPrice);
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // var Result = Seq1.DistinctBy(P => P.Category);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }



        #endregion

        #region Quantifier operators [Any , All , SequenceEqual , Contains]
        // return boolean value
        // determine is the sequence contain any element or not
        // Console.WriteLine(ProductsList.Any());
        
        // determine is the sequence contain any element or not based on condition
        // Console.WriteLine(ProductsList.Any(P => P.UnitsInStock == 100000000));
        
        // determine if weather all the elements in unit in stock are greater than 0
        // Console.WriteLine(ProductsList.All(P => P.UnitsInStock > 0));
        
        // check if sequence contains specific element or not 
        // Console.WriteLine(ProductsList.Contains(new Product() { ProductID = 1 , ProductName = "Chai" , Category = "Beverages" , UnitPrice = 18.00M , UnitsInStock = 100 }));
        
        // var Seq1 = new List<Product>()
        // {
        //     new Product()
        //         { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100 },
        //     new Product()
        //         { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
        //     new Product()
        //         { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 }
        //     
        // };
        // var Seq2 = new List<Product>()
        // {
        //     new Product()
        //         { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100 },
        //     new Product()
        //         { ProductID = 2, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
        //     new Product()
        //         { ProductID = 3, ProductName = "Chef Aston's Cajun Seasoning", Category = "Condiments", UnitPrice = 18.00M, UnitsInStock = 39 },
        //     new Product()
        //         { ProductID = 3, ProductName = "Chef Aston's Gumbo Mix", Category = "Condiments", UnitPrice = 18.00M, UnitsInStock = 0 },
        // };
        //
        // Console.WriteLine(Seq1.SequenceEqual(Seq2 , new ProductEqualityComparer()));
        
        

        #endregion

        #region Transformation operators - Zip
        // // 1- create list of strings , array numbers 
        // string[] Names = {"Ten" , "Twenty" , "Thirty" , "Fourty" };
        // int [] numbers = {10 , 20 , 30 , 40 , 50 , 60};
        //
        // // first overload takes one sequence and return sequence of tuples of 2
        // var Result = Names.Zip(numbers);
        // // foreach (var item in Result)
        // // {
        // //     Console.WriteLine(item);
        // // }
        //
        // // second overload takes two sequences and return sequence of tuples of 3
        // var Result2 = Names.Zip(numbers, new int[] { 100, 200, 300, 400 });
        // //
        // // foreach (var item in Result2)
        // // {
        // //     Console.WriteLine(item);
        // // }
        //
        // // third overload takes two sequences and return sequence of resultSelector
        // var Result3 = Names.Zip(numbers , (N , Num) => $"{N} :: {Num}");
        // foreach (var item in Result3)
        // {
        //     Console.WriteLine(item);
        // }


        #endregion

        #region Grouping Operators [GroupBy , Chunk]

        // var Result = from P in ProductsList
        //     group P by P.Category;
        //
        // Result = ProductsList.GroupBy(P => P.Category);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine("*********************** " + item.Key);
        //
        //     foreach (var product in item)
        //     {
        //         Console.WriteLine(product);
        //     }
        // }
        
        // group products that have products in stock and each category have more than 10 products 
        // and return the category name along with the count of products
        // query syntax
        
        
        // var Result = from P in ProductsList
        //     where P.UnitsInStock > 0
        //     group P by P.Category
        //     into ProdcutGroup
        //     where ProdcutGroup.Count() > 10
        //     select new
        //     {
        //         ProductCategory = ProdcutGroup.Key , 
        //         ProductCount = ProdcutGroup.Count() 
        //     };
        //
        // Result = ProductsList.Where(P => P.UnitsInStock > 0)
        //     .GroupBy(P => P.Category)
        //     .Where(PG => PG.Count() > 10)
        //     .Select(PG => new
        //     {
        //         ProductCategory = PG.Key,
        //         ProductCount = PG.Count()
        //     });
        // foreach(var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // group by overloads 
        // var Result =  ProductsList.GroupBy(P => P.Category , new StringEqulityComparer());
        // foreach (var item in Result)
        // {
        //     Console.WriteLine("*********************** " + item.Key);
        //     foreach (var product in item)
        //     {
        //         Console.WriteLine(product);
        //     }
        // }
        
        // var Result = ProductsList.GroupBy(P => P.Category , P => P.ProductName);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine("*********************** " + item.Key);
        //     foreach (var product in item)
        //     {
        //         Console.WriteLine(product);
        //     }
        // }
        
        // var Result = ProductsList.GroupBy(P => P.Category , P => P.ProductName , new StringEqulityComparer());
        // foreach (var item in Result)
        // {
        //     Console.WriteLine("*********************** " + item.Key);
        //     foreach (var product in item)
        //     {
        //         Console.WriteLine(product);
        //     }
        // }
        
        // var Result = ProductsList.GroupBy(P => P.Category , P => new {P.Category , P.ProductName} , new StringEqulityComparer());
        // foreach (var item in Result)
        // {
        //     Console.WriteLine("*********************** " + item.Key);
        //     foreach (var product in item)
        //     {
        //         Console.WriteLine(product);
        //     }
        // }
        // var Result = ProductsList.GroupBy(P => P.Category,
        //     P => new { ProductId = P.ProductID, ProductName = P.ProductName } ,
        //     (C, P) => new { C , P = P.Count()} , new StringEqulityComparer());
        //
        // foreach (var item in Result)
        // {
        //     Console.WriteLine("*********************** " + item.C);
        //     Console.WriteLine(item.P);
        //     // foreach (var product in item.P)
        //     // {
        //     //     Console.WriteLine(product);
        //     // }
        // }
        
        // var fruits = new [] { "Banana" , "Pear" , "Apple" , "Orange" , "Plum" , "Lemon"  , "Watermelon"};
        // var chunks = fruits.Chunk(2);
        // foreach (var chunk in chunks)
        // {
        //     foreach (var item in chunk)
        //     {
        //         Console.Write(item + " ");
        //     }
        //     Console.WriteLine();
        // }
        #endregion

        #region Partitioning Operators [Take , Skip , TakeLast , SkipLast , TakeWhile , SkipWhile]
        
        // 1- get first and last 3 products our of stock
        // var Result = ProductsList.Where(P => P.UnitsInStock == 0).Take(3);
        // Result = ProductsList.Where(P => P.UnitsInStock == 0).TakeLast(3);
        // foreach (var item in Result)
        // {
            // Console.WriteLine(item);
        // }
        // 2- Skip , SkipLast
        // var Result = ProductsList.Where(P => P.UnitsInStock == 0).Skip(2);
        // Result = ProductsList.Where(P => P.UnitsInStock == 0).SkipLast(2);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        //
        // Result = ProductsList.SkipLast(3);
        
        // 3- Pagination
        // int PageIndex = 4 , PageSize = 10;
        // var Result = ProductsList.Skip((PageIndex - 1) * PageSize).Take(PageSize); 
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }
        
        // 4- TakeWhile , SkipWhile
        // int [] Numbers = {-1 , -2 , -3 ,1 , 20 , 4};
        // var Result = Numbers.TakeWhile((N, I) => N < I);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // int [] Numbers = {1 , 2 , 3 ,1 , 20 , 4};
        // var Result = Numbers.SkipWhile(N => N % 3 != 0);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion

        #region Let & Into

        // string [] names = {"Ahmed" , "Mohamed" , "Ali" , "Hassan" , "Abdelrahman"};
        //
        // var Result = from N in names
        //     select Regex.Replace(N, "[aeiouAEIOU]", "")
        //     into NonVowelName
        //     where NonVowelName.Length > 3
        //     select NonVowelName;
        //
        // Result = from N in names 
        //     let NonVowelName = Regex.Replace(N, "[aeiouAEIOU]", "")
        //     where NonVowelName.Length >= 3
        //     select NonVowelName;
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        #endregion
    }
}