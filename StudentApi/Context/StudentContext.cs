using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApi.Models;

namespace StudentApi.Context
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> student_table { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-7LJ7HTPU\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Seeding data into table on creation done here
        //    modelBuilder.Ignore<DateOnly>();

        //}
     
    }
}
