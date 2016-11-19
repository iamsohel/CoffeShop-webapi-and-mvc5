using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoffeShop.Models
{
    public class Coffe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
    public class CoffeshopContext : DbContext
    {
        public CoffeshopContext()
            : base("Coffe")
        {
        }

        public System.Data.Entity.DbSet<CoffeShop.Models.Coffe> Coffes { get; set; }

        public System.Data.Entity.DbSet<CoffeShop.Models.Company> Companies { get; set; }
    }
}