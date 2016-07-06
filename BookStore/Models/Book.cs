using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        // ID книги
        public int Id { get; set; }
        // Название книги
        public string Name { get; set; }
        // Автор книги
        public string Author { get; set; }
        // Цена книги
        public int Price { get; set; }
    }
}