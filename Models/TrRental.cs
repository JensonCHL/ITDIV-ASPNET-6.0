using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITDIV.Models;

public class TrRental
{
    [Key]
    [MaxLength(36)]
    public string Rental_id { get; set; } 

    public DateTime rental_date { get; set; }

    public DateTime return_date { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal total_price { get; set; }

    public bool payment_status { get; set; } 

    [MaxLength(36)]
    public string customer_id { get; set; } 

    [MaxLength(36)]
    public string car_id { get; set; } 

    [ForeignKey("customer_id")]
    public virtual MsCustomer Customer { get; set; } 

    [ForeignKey("car_id")]
    public virtual MsCar Car { get; set; }
}
