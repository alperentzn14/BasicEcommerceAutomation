using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentMail { get; set; }


        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}