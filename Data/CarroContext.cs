using CarroAPI.Controllers;
using CarroAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarroAPI.Data
{
    public class CarroContext : DbContext
    {      
        public CarroContext(DbContextOptions<CarroContext> opt) : base(opt)
        {

        }
        public DbSet<Carro> Carros { get; set; }
    }
}
