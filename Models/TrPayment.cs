using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITDIV.Models;

public class TrPayment
{
    [Key]
    [MaxLength(36)]
    public string Payment_id { get; set; }

    public DateTime payment_date { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal amount { get; set; }
    [MaxLength(100)]
    public string payment_method { get; set; }

    [MaxLength(36)]
    // [ForeignKey("TrRental")]
    [ForeignKey("rental_id")]

    public string rental_id { get; set; } 

    public virtual TrRental Rental { get; set; }
}
