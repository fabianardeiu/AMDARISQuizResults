using AmdarisQuizResults.Models;
using AmdarisQuizResultsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResults
{
    public class AmdarisQuizContext : DbContext
    {
        private const string dbAzureConnectionString = @"Data Source=amdarisquiz.database.windows.net;Initial Catalog=quiz;User ID=Admin2019;Password=Amdaris$2019;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string dbConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuizResultsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Amdaris$2019
            //optionsBuilder.UseSqlServer(dbAzureConnectionString);
            optionsBuilder.UseSqlServer(dbConnectionString);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
