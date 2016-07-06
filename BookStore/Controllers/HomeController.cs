﻿using System;
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
            // Возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // Добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // Сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + purchase.Person + ", за покупку!";
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
    }
}