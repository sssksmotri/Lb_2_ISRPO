using Lb_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lb_2.Controllers
{
    public class HomeController : Controller
    {
        private Libary library; 

        public HomeController()
        {
            library = new Libary(); 
        }

        private static List<Book> catalog = new List<Book>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(catalog);
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("AllBooks");
            }

            var result = catalog.Where(b =>
                b.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                b.Year.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return View("AllBooks", result);
        }
        
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            book.Id = nextId++; 
            catalog.Add(book);
            library.AddBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TaskFirst()
        {
            return View();
        }
       
        public IActionResult AllBooks()
        {
            return View(catalog);
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        public IActionResult Task_3()
        {
            return View();

        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskFirst(int k)
        {
            Random random = new Random();
            int[] numbers = new int[k];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-10, 31);
            }

            double average = numbers.Where(n => n > 0).Average();

            ViewBag.Array = string.Join(", ", numbers);
            ViewBag.Average = average;

            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(string text)
        {
            int countPlus = 0;
            int countMinus = 0;

            if (!string.IsNullOrEmpty(text))
            {
                foreach (char c in text)
                {
                    if (c == '+')
                    {
                        countPlus++;
                    }
                    else if (c == '-')
                    {
                        countMinus++;
                    }
                }
            }

            ViewBag.Text = text;
            ViewBag.CountPlus = countPlus;
            ViewBag.CountMinus = countMinus;

            return View();
        }


        [HttpPost]
        public IActionResult Task_3(string searchString)
        {
            var result = catalog.Where(b =>
                b.Author.Contains(searchString) ||
                b.Title.Contains(searchString) ||
                b.Year.ToString().Contains(searchString)
            ).ToList();

            return View("AllBooks", result);
        }

        
        [HttpPost]

        public IActionResult Delete(int id)
        {
            Book bookToRemove = catalog.FirstOrDefault(b => b.Id == id);

            if (bookToRemove != null)
            {
                catalog.Remove(bookToRemove);
            }

            return RedirectToAction("Index");
        }
    }
}
