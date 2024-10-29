using System;
using ITDIV.Models;
using Microsoft.EntityFrameworkCore;

namespace ITDIV.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<TrPayment> TrPayment { get; set; }
    public DbSet<MsCar> MsCar { get; set; }
    public DbSet<MsCarImages> MsCarImages { get; set; }
    public DbSet<MsCustomer> MsCustomer { get; set; }
    public DbSet<MsEmployee> MsEmployee { get; set; }
    public DbSet<TrMaintenance> TrMaintenance { get; set; }
    public DbSet<TrRental> TrRental { get; set; }
}
