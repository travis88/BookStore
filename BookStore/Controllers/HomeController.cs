using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // Создаём контекст данных
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            // Получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // Передаём все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            ViewBag.Message = "Этот частичное представление";
            // Возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy()
        {
            SelectList books = new SelectList(db.Books, "Author", "Name");
            ViewBag.Books = books;
            return View();
        }

        //[HttpPost]
        //public string Buy(Purchase purchase)
        //{
        //    purchase.Date = DateTime.Now;
        //    //// Добавляем информацию о покупке в базу данных
        //    //db.Purchases.Add(purchase);
        //    //// Сохраняем в бд все изменения
        //    //db.SaveChanges();
        //    string userName = purchase.Person;
        //    string pwd = purchase.Password;

        //    return "Спасибо за покупку! " + userName + " " + pwd + " " + purchase.Date;
        //}

        [HttpPost]
        public string Buy(string[] countries)
        {
            string result = "";
            foreach (string s in countries)
            {
                result += s;
                result += "; ";
            }
            return "Вы выбрали: " + result;
        }

        public string Square(int a = 10, int h = 5)
        {
            //int a = Int32.Parse(Request.Params["a"]);
            //int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2;
            return "<h2>Площадь теугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = "../Images/tux.png";
            return new ImageResult(path);
        }

        public ActionResult SomeShiiit()
        {
            ViewBag.Job = "Hello Job";
            ViewBag.Head = "Hello Head";
            return View("SomeView");
        }

        public FileResult GetFile()
        {
            string file_path = Server.MapPath("~/Files/Python.pdf");
            string file_type = "application/pdf";
            string file_name = "Python.pdf";
            return File(file_path, file_type, file_name);
        }

        public ActionResult Info()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            string res = "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url: " +
                url + "</p><p>Referer: " + referer + "</p><p>IP-address: " + ip + "</p>";
            return View(res);
        }

        public string ContextData()
        {
            HttpContext.Response.Write("<h1>Hello World</h1>");

            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string refferer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>User-Agent: " + user_agent + "</p><p>Url request: " + url + "</p><p>Refferer: " + refferer + "</p><p>IP-address" + ip + "</p>";
        }

        //public ActionResult Partial()
        //{
        //    ViewBag.Message = "Этот частичное представление";
        //    return PartialView();
        //}

        [HttpPost]
        public ActionResult MyAction(string product, string action)
        {
            string answer = "";
            if (action == "add")
            {
                answer = product;
            }
            else if (action == "delete")
            {
                answer = "";
            }
            ViewBag.Answer = answer;
            return View("Buy");
        }
    }
}