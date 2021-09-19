using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Classes
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonSurName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string PersonImage { get; set; }

        public bool Status { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}