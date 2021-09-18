using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Models.Classes
{
    public class SalesMove
    {
        [Key]
        public int SalesMoveId { get; set; }
  
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int PersonId { get; set; }
        public  virtual  Product Products { get; set; }
        public virtual Current Currents { get; set; }
        public virtual Person Persons { get; set; }
    }
}