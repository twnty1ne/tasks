using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public class TasksDbConext : DbContext
    {
        public TasksDbConext()
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<ProjectEntity> Project { get; set; }
        public DbSet<TaskCommentEntity> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=DESKTOP-HFEPFQ9\SQLEXPRESS;Database=Task;Trusted_Connection=True")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ProjectEntity>()
                .HasData(new List<ProjectEntity>()
                {
                    new ProjectEntity
                    {
                        Id = new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"),
                        Name = "Project1",
                        CreateDate = DateTime.UtcNow
                    },
                    new ProjectEntity
                    {
                        Id = new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"),
                        Name = "Project2",
                        CreateDate = DateTime.UtcNow,
                    },
                    new ProjectEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project3",
                        CreateDate = DateTime.UtcNow
                    }
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
                    new TaskEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project1Task1",
                        ProjectId =  new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"),
                        CreateDate = DateTime.UtcNow,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddHours(1),

                    },
                    new TaskEntity
                    {
                        Id = new Guid("cd0be526-1342-4669-b540-cf079ece407d"),
                        Name = "Project1Task2",
                        ProjectId =  new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"),
                        CreateDate = DateTime.UtcNow,
                        StartDate = DateTime.UtcNow,
                    },

                    new TaskEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project2Task1",
                        CreateDate = DateTime.UtcNow,
                        ProjectId = new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a")
                    },
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
                    new TaskCommentEntity
                    {
                        Id = Guid.NewGuid(),
                        CommentType = 5,
                        TaskId = new Guid("cd0be526-1342-4669-b540-cf079ece407d"),
                        Content = Encoding.ASCII.GetBytes("Task content")
                    },
                });
        }
    }
}
