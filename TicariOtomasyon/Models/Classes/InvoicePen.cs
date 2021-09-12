using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Classes
{
    public class InvoicePen
    {
        [Key]
        public int InvoicePenId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoiceDescription { get; set; }
        public int InvoiceQuantity { get; set; }
        public decimal InvoiceUnitPrice  { get; set; }
        public decimal InvoiceAmount  { get; set; }

        public Invoice Invoice { get; set; }

    }
}
