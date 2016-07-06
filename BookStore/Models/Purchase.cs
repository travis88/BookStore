using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Purchase
    {
        // ID книги
        public int PurchaseId { get; set; }
        // Имя и фамилия покупателя
        public string Person { get; set; }
        // Адрес покупателя
        public string Address { get; set; }
        // ID книги
        public int BookId { get; set; }
        // Дата покупки
        public DateTime Date { get; set; }
    }
}