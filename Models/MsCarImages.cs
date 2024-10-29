using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITDIV.Models;

public class MsCarImages
{
    [Key]
    [MaxLength(36)]
    public string Image_car_id { get; set; } 

    [MaxLength(36)]
    public string Car_id { get; set; } 

    [MaxLength(2000)]
    public string image_link { get; set; } 

    [ForeignKey("CarId")]
    public virtual MsCar Car { get; set; } 
}