using Microsoft.EntityFrameworkCore;
using NationalProblemsApp.Entities;

namespace NationalProblemsApp.Data
{
    public class NationalProblemsDbContext : DbContext
    {
        public NationalProblemsDbContext()
        {
        }
        public NationalProblemsDbContext(DbContextOptions<NationalProblemsDbContext> options) : base(options)
        {
        }
        //private readonly IConfiguration configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackHistory> FeedbackHistories { get; set; }

        //public NationalProblemsDbContext(DbContextOptions<NationalProblemsDbContext> options, 
        //    IConfiguration _configuration) : base(options)
        //{
        //    configuration = _configuration;
        //}
    }
}