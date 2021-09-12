using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Models
{
    public class SalesMove
    {
        [Key]
        public int SalesMoveId { get; set; }
        //product
        //current
        //person
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public  ICollection<Product> Products { get; set; }
        public  ICollection<Current> Currents { get; set; }
        public  ICollection<Person> Persons { get; set; }
    }
}