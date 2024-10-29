using System;

namespace ITDIV.Models.SewaView;

public class SewaView
{
    public string image_link { get; set; } 

    public string Car_id { get; set; }


    public string name { get; set; }

    public string model { get; set; } 

    public int year { get; set; } 
    public int number_of_car_seats { get; set; } 

    public string transmission { get; set; } 
    public decimal price_per_day { get; set; }

}
