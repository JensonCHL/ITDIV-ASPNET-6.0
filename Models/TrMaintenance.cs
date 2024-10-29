using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITDIV.Models;

public class TrMaintenance
{
    [Key]
    [MaxLength(36)]
    public string Maintenance_id { get; set; }

    public DateTime maintenance_date { get; set; }

    [MaxLength(400)]
    public string description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal cost { get; set; }

    [MaxLength(36)]
    public string car_id { get; set; }

    [MaxLength(36)]
    public string employee_id { get; set; }

    [ForeignKey("car_id")]
    public virtual MsCar Car { get; set; }

    [ForeignKey("employee_id")]
    public virtual MsEmployee Employee { get; set; }
}
