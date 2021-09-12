using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Classes
{
    public class Admin
    {
          [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UserPassword { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Authorization { get; set; }
    }
}