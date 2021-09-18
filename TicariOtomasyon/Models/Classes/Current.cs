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
        [StringLength(30,ErrorMessage = "max.30 character")]
        [Required(ErrorMessage ="CurrentName Required!!")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "max.30 character")]
        [Required(ErrorMessage = "CurrentSurName Required!!")]
        public string CurrentSurName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "max.15 character")]
        [Required(ErrorMessage = "CurrentCity Required!!")]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "max.30 character")]
        [Required(ErrorMessage = "CurrentMail Required!!")]
        public string CurrentMail { get; set; }

        public bool Status { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}