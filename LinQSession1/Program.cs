using System.Net.WebSockets;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;


namespace LinQSession1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Book b1 = new Book() { Id = 1, Title = "Hello World", Author = "Mohamed Ali", Category = "Programming", Price = 100, ShelfId = "A2" };
			Book b2 = new Book() { Id = 2, Title = "Math", Author = "Ahmed Saleh", Category = "Mathematics", Price = 150, ShelfId = "A2" };

			List<Book> Books = new List<Book>();

			Books.Add(b1);
			Books.Add(b2);

			// Adding more objects
			Book b3 = new Book() { Id = 3, Title = "Medical Science", Author = "Fatima Salim", Category = "Science", Price = 180, ShelfId = "A2" };
			Book b4 = new Book() { Id = 4, Title = "Pharaohs", Author = "Ali Hassan", Category = "History", Price = 200, ShelfId = "A2" };
			Book b5 = new Book() { Id = 5, Title = "Fiction", Author = "Nadia Ahmed", Category = "Fiction", Price = 134.5, ShelfId = "A2" };
			Book b6 = new Book() { Id = 6, Title = "Africa Map", Author = "Hassan Ali", Category = "Geography", Price = 102, ShelfId = "A2" };
			Book b7 = new Book() { Id = 7, Title = "Poetry", Author = "Salma Youssef", Category = "Literature", Price = 120, ShelfId = "A2" };
			Book b8 = new Book() { Id = 8, Title = "Economics", Author = "Khaled Rami", Category = "Economics", Price = 160, ShelfId = "A2" };
			Book b9 = new Book() { Id = 9, Title = "Biology", Author = "Fatima Salim", Category = "Science", Price = 350, ShelfId = "A2" };
			Book b10 = new Book() { Id = 10, Title = "Chemistry", Author = "Karim Mostafa", Category = "Science", Price = 350, ShelfId = "A2" };
			Book b11 = new Book() { Id = 11, Title = "Novel", Author = "Sara Nabil", Category = "Fiction", Price = 400, ShelfId = "A2" };
			Book b12 = new Book() { Id = 12, Title = "Algebra", Author = "Mohamed Ahmed", Category = "Mathematics", Price = 450, ShelfId = "A2" };

			// Adding the objects to the list
			Books.Add(b3);
			Books.Add(b4);
			Books.Add(b5);
			Books.Add(b6);
			Books.Add(b7);
			Books.Add(b8);
			Books.Add(b9);
			Books.Add(b10);
			Books.Add(b11);
			Books.Add(b12);

			//--------------------------------------------------------------------------------------------------------------
			//! Where => Filtiration

			// var BookWithId3 = Books.Where(B => B.Id == 3).FirstOrDefault();
			// var BooksWithSCience = Books.Where(B => B.Category == "Science");
			// foreach (Book book in BooksWithSCience)
			//     Console.WriteLine(book);

			//--------------------------------------------------------------------------------------------------------------

			//! Order By => Order ASC
			//! Order By Desc => Order Desc
			//! Then By => Order Asc Again if 2 Elements is Equals at the first way of ordering 
			//! Then By Desc =>Order Desc Again if 2 Elements is Equals at the first way of ordering 
			// var booksWithOrdering = Books.OrderBy(B => B.Price);//Asc
			// var booksWithOrderingDesc = Books.OrderByDescending(B => B.Price).Last();//Desc
			// Console.WriteLine(booksWithOrderingDesc);
			//--------------------------------------------------------------------------------------------------------------
			//? Any vs All => Bool
			//? Any => Sequance at least one Element Matched The Condition  ->True
			//? All => All Elements at the sequance Matched The Condition -> True
			// if (Books.Any(b => b.Category == "Hamada"))
			//     Console.WriteLine("Hello there is one Element At Least with that Category");
			// else
			//     Console.WriteLine("Hello there is no Elements with that Category");

			// if (Books.All(b => b.Price == 100))
			//     Console.WriteLine("Hello there is one Element At Least with that Price");
			// else
			//     Console.WriteLine("Hello there is no Elements with that Price");

			//--------------------------------------------------------------------------------------------------------------
			//! Take vs Skip
			//? Take => Take first Elements from Sequance depeneds on Count
			//? Skip => Skip first Elements from Sequance depeneds on Count
			//? TakeLast => Take Last Elements from Sequance depeneds on Count
			//? SkipLast => Skip Last Elements from Sequance depeneds on Count
			//? SkipWhile
			//? TakeWhile

			// var Bookswithoutfirst5Elements = Books.OrderBy(B => B.Price).SkipLast(5);
			// var BooksWithPrice100 = Books.SkipWhile(B => B.Price != 100);
			// var BooksWithPrice1000 = Books.TakeWhile(B => B.Price == 1000);
			// foreach (var book in Bookswithoutfirst5Elements)
			//     Console.WriteLine(book);
			//--------------------------------------------------------------------------------------------------------------
			//! Projection operation

			//? Select 
			//? Select Many => like inner query in sql
			//? zip
			//! Select and Select many

			// var booksTitles = Books.Select(b => b.Title);

			// var MostScienceBookPrice = Books.Where(B => B.Category == "Science").OrderByDescending(B => B.Price).Select(b => b.Title).FirstOrDefault();
			// {
			//     Title = b.Title,
			//     Author = b.Author,
			// });

			// Console.WriteLine(MostScienceBookPrice);

			// foreach (var book in SelectedBooksWithTitleAndAuthorName)
			//     Console.WriteLine(book);

			// var CheckAlphabet = Books.SelectMany(b => b.Title.ToCharArray());

			// foreach (var char1 in CheckAlphabet)
			//     Console.WriteLine(char1);

			//* zip
			//* it neglect the extra items in the second collection mean it take the min count of the two collections
			// string[] colorHEX = { "#FF0000", "#00FF00", "#0000FF" };
			// string[] colorName = { "Red", "Green", "Blue" };
			// var coolors = colorHEX.Zip(colorName, (name, HEX) => $"{name} is {HEX}");
			// Console.WriteLine(coolors);

			//--------------------------------------------------------------------------------------------------------------

			//! Aggregate Operations

			// var numbers = new[] { 1, 2, 3, 4, 5 };
			// var sum = numbers.Aggregate(100, (a, b) => a + b); // like reduce in javascript

			//? Count
			// var Count = Books.Where(b => b.Price > 150).Count();
			// Console.WriteLine(numbers.Count());
			// Console.WriteLine(numbers.Count(x => x % 2 == 0));


			//? Maxby
			//? Minby
			//? Sum
			//? Average
			//! Count Max Min Sum Avg
			// var MaxPrice = Books.MaxBy(b => b.Price);
			// var MinPric = Books.MinBy(b => b.Price);
			// var SumSciencePrices = Books.Where(b => b.Category == "Science").Sum(b => b.Price);
			// var AvgSciencePrices = Books.Where(b => b.Category == "Science").Average(b => b.Price);
			// Console.WriteLine(AvgSciencePrices);
			//--------------------------------------------------------------------------------------------------------------
			//? casting 
			//! ToList
			//? ToArray
			//! ElementAt
			//? ElementAtOrDefault

			// var BookWithPriceUnder350 = Books.Where(b => b.Price < 350).ToList();
			// var BookWithPriceUnder350AtArreay = Books.Where(b => b.Price < 350).ToArray();
			//--------------------------------------------------------------------------------------------------------------

			//! Indexing
			//! FirstOrDefualt =>FirstElement || Default =>Null
			//! LastOrDefualt => LastElement  || Default =>Null
			//! First => If Sequance have no Elements => program throw Exception
			//! Last =>If Sequance have no Elements => program throw Exception

			// var ElementAtIndex1 = Books.ElementAt(1);// it return the element at index 1
			// var ElementAtIndex10 = Books.ElementAtOrDefault(100); // it return the element at index 100 or null

			// var FirstBook = Books.First(x=> x.Id==10);//it return the first Book that match the condition
			// var FirstBookOrDefault = Books.FirstOrDefault(x=> x.Id==100);//it return the first Book that match the condition or null

			// var LastBook = Books.Last(x=> x.Id==10);//it return the last Book that match the condition
			// var LastBookOrDefault = Books.LastOrDefault(x=> x.Id==100);//it return the last Book that match the condition or null
			//--------------------------------------------------------------------------------------------------------------
			//? Group By and ToLookup
			// var GroupedBooks = Books.GroupBy(b => b.Category);
			// foreach (var book in GroupedBooks)
			//     Console.WriteLine(book);

			// var ToLookUpBooks = Books.ToLookup(b => b.Category);
			// foreach (var book in ToLookUpBooks)
			//     Console.WriteLine(book);

			//! GroupBy is Uses defered execeution but ToLookup uses immediate execution
			//? GroupBy in each iterate  => Group again but Tolookup buffer the result in memory 
			//* GroupBy return IEnuerable <IGrouping<TKey,TSource>> but ToLookup is return ILookup<TKey,TSource>

			//--------------------------------------------------------------------------------------------------------------
			//! join and GroupJoin

			//? join
			// var query = employees.Join(departments,
			// emp => emp.DepartmentId,
			//   dept => dept.Id,
			//   (emp, dept) => new { emp.FullName, dept.Name });
			// foreach (var item in query)
			//     Console.WriteLine($"{item.FullName} [{item.Name}]");


			//? GroupJoin
			// var query = departments.GroupJoin
			//     (employees,
			//       dept => dept.Id,
			//       emp => emp.DepartmentId,
			//       (dept, emps) => new
			//       {
			//           Department = dept.Name,
			//           Employees = emps
			//       });

			// foreach (var group in query)
			// {
			//     Console.WriteLine($"********************** {group.Department} ***********************");
			//     foreach (var item in group.Employees)
			//         Console.WriteLine($"{item.FullName}");
			// }

			//--------------------------------------------------------------------------------------------------------------

			//!  Generation Operations

			// var MyBook1 =new List<Book>(); //empty list => defered execution 
			// var MyBook2 = Enumerable.Empty<Book>(); //empty list => defered execution but more performance 
			// Console.WriteLine(default (int)); // the default is a function that return the default value of the type
			// var myBook3=MyBook2.DefaultIfEmpty(); // it return the default value of the type if the list is empty
			// var reange = Enumerable.Range(1, 10); // it return sequance of numbers from 1 to 10 and this is defered execution
			// var B=new Book() => var AllBooks=Enumerable.Repeat(B,10); // it return sequance of 10 books and this is defered execution

			//--------------------------------------------------------------------------------------------------------------

			//!  Equality Operations

			//var isEqual=Book1.SequenceEqual(Book2); // it return true if the two sequances are equal
			//--------------------------------------------------------------------------------------------------------------

			//! Sets Operations

			//* Distinct and DistinctBy
			// var disBooks = Books.Distinct();// it return distinct sequance and it depend on Equals method 
			// var disBooks1 = Books.DistinctBy(b => b.Id);// it return distinct sequance by Id
			// var disBooks2 = Books.DistinctBy(b => b.Category);// it return distinct sequance by Category
			// var disBooks3 = Books.DistinctBy(b => b.Author);// it return distinct sequance by Author

			//* Except and ExceptBy 
			// var ExceptBooks = Books.Except(Book1);// it return sequance that is not in Book1

			//* Intersect and IntersectBy
			// var IntersectBooks = Books.Intersect(Book1);// it return sequance that is in Book1

			//* Union and UnionBy
			// var unionBooks = Books.Union(Book1); // it returns a sequence that contains all unique elements from both Books and Book1
			// var unionBooksByCategory = Books.UnionBy(Book1, b => b.Category); // it returns a sequence that contains all unique elements from both Books and Book1, based on the Category property

			//--------------------------------------------------------------------------------------------------------------
				

				
		}
	}
}