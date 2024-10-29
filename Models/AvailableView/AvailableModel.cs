using System;

namespace ITDIV.Models.AvailableView;

public class AvailableModel
{
    public string Car_id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string ImageLink { get; set; } // Include image link
}
