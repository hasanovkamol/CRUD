using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrasture.Context
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
              .HasMany(x => x.Subjects)
              .WithMany(x => x.Students)
              .UsingEntity<StudentSubject>(
                x => x.HasOne(x=>x.Subject)
                .WithMany().HasForeignKey(x=>x.SubjectId),
                x=>x.HasOne(x=>x.Student)
                .WithMany().HasForeignKey(x=>x.StudentId)
                );

            base.OnModelCreating(builder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}