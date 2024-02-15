using Lb_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lb_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        public IActionResult TaskSecond()
        {
            return View();
        }
        public IActionResult Task_3()
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
    }
}