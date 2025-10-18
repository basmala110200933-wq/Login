using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login_Admin.Model;
using Microsoft.EntityFrameworkCore;

namespace login_Admin.Data
{
    public class ContextDegree:DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Admin> Administration { get; set; }
        public DbSet<StudentCourses> studentscourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0OSQ4LI;Initial Catalog=schoolDB;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>().HasKey(x => new { x.coid, x.stid });
        }

    }
}