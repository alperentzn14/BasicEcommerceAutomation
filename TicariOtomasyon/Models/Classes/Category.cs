using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }

        //ICollection İnterface We are buildig our relationship!!
        public ICollection<Product> Products { get; set; }
    }
}