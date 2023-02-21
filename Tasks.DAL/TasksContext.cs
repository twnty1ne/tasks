using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public class TasksDbConext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TasksDbConext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<ProjectEntity> Project { get; set; }
        public DbSet<TaskCommentEntity> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ProjectEntity>()
                .HasData(new List<ProjectEntity>()
                {
                    new ProjectEntity(new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), "Project1"),
                    new ProjectEntity(new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"), "Project2"),
                    new ProjectEntity("Project3")
                });

            builder
                .Entity<ProjectEntity>()
                .Property(x => x.Name)
                .IsRequired();


            builder
                .Entity<ProjectEntity>()
                .Property(x => x.Name)
                .HasColumnType("varchar(255)");

            builder
               .Entity<ProjectEntity>()
               .Property(x => x.CreateDate)
               .IsRequired();

            builder
                .Entity<TaskEntity>()
                .HasData(new List<TaskEntity>
                {
                    new TaskEntity(new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), 
                        "Project1Task1", new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), DateTime.UtcNow, DateTime.UtcNow.AddHours(1), Encoding.ASCII.GetBytes("Task content")),

                    new TaskEntity(new Guid("cd0be526-1342-4669-b540-cf079ece407d"), 
                        "Project1Task2", new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), DateTime.UtcNow, DateTime.UtcNow, Encoding.ASCII.GetBytes("Task content")),

                    new TaskEntity("Project2Task1", new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"), null, null, Encoding.ASCII.GetBytes(string.Empty))
                });

            builder
                .Entity<TaskEntity>()
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Entity<TaskEntity>()
                .Property(x => x.CreateDate)
                .IsRequired();

            builder
               .Entity<TaskEntity>()
               .Property(x => x.Name)
               .HasColumnType("varchar(255)");

            builder
                .Entity<TaskCommentEntity>()
                .HasData(new List<TaskCommentEntity>
                {
                    new TaskCommentEntity(new Guid("cd0be526-1342-4669-b540-cf079ece407d"), 5, Encoding.ASCII.GetBytes("Task content"))
                });
        }
    }
}
