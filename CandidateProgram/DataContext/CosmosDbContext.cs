using CandidateProgram.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CandidateProgram.DataContext
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Programs> Programs { get; set; }
        public DbSet<PersonalInfoField> PersonalInfoField { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<CandidateResponse> CandidateResponse { get; set; }

        public DbSet<Answers> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);


            modelBuilder.HasDefaultContainer("Programs");

            modelBuilder.Entity<Programs>()
                .HasNoDiscriminator()
                .HasPartitionKey(x => x.ProgramName)
                .HasKey(x => x.ProgramId);

            modelBuilder.Entity<PersonalInfoField>()
               .HasNoDiscriminator()
               .ToContainer("PersonalInfoField")
               .HasPartitionKey(x => x.ProgramId)
               .HasKey(x => x.PersonalID);

            modelBuilder.Entity<Question>()
               .HasNoDiscriminator()
               .ToContainer("Question")
               .HasPartitionKey(x => x.ProgramId)
               .HasKey(x => x.QuestionID);

            modelBuilder.Entity<CandidateResponse>()
              .HasNoDiscriminator()
              .ToContainer("CandidateResponse")
              .HasPartitionKey(x => x.ProgramId)
              .HasKey(x => x.ResponseID);

            modelBuilder.Entity<Answers>()
              .HasNoDiscriminator()
              .ToContainer("Answers")
              .HasPartitionKey(x => x.ResponseID)
              .HasKey(x => x.AnswerID );
        }
    }
}
