using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string InvoiceOrderNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string InvoiceTaxOffice { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string InvoiceHour { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoiceToSubmit { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoiceReceive { get; set; }
        public decimal Total { get; set; }

        public ICollection<InvoicePen> InvoicePens { get; set; }


    }
}