using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITDIV.Models;

public class MsCustomer
{
    [Key]
    [MaxLength(36)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Customer_id { get; set; }

    [MaxLength(100)]
    public string email { get; set; }

    [MaxLength(100)]
    public string password { get; set; }

    [MaxLength(100)]
    public string name { get; set; }

    [MaxLength(50)]
    public string phone_number { get; set; }

    [MaxLength(500)]
    public string address { get; set; }

    [MaxLength(100)]
    public string? driver_license_number { get; set; }
}
