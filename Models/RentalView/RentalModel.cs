using System;

namespace ITDIV.Models.RentalView;

public class RentalModel
{
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Price_per_day { get; set; }
    public bool PaymentStatus { get; set; }
    public string CarName { get; set; }
    
}
