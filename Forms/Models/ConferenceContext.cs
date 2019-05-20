using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class ConferenceContext:DbContext
    {
        //public ConferenceContext(DbContextOptions options) : base(options)
        //{
        //}

        public DbSet<ConferenceUsers> ConferenceUsers { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=Conference3;Integrated Security=True");
        //    //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-R5CKH1O;Database=Conference3;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=desktop-r5ckh1o;initial catalog=ConferenceUsersDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConferenceUsers>().ToTable("ConferenceUsers");
        }
       


        
        
       
    }
}
