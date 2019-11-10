using CityApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<City> Cities { get; set; }
        
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
    }
}
