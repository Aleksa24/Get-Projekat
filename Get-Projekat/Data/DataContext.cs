using Get_Projekat.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Studenti{ get; set; }
        public DbSet<Ispit> Ispiti{ get; set; }


        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ispit>().HasKey(x=> new { x.BrojIndeksa,x.PredmetId});
        }
    }
}
