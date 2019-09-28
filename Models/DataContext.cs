using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Admission> Admitted { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }
        public DbSet<Classes> Class { get; set; }
        public DbSet<Sections> Section { get; set; }
        public DbSet<Groups> Group { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public DbSet<ExamTypes> ExamType { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Actors> Actor { get; set; }
        public DbSet<Results> Result { get; set; }
        
    }
}
