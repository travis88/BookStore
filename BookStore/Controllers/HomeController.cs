﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

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
    }
}