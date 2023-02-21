using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tasks.Api.Middlewares;
using Tasks.Application.Requests;
using Tasks.Application.Services;
using Tasks.Application.Validators;
using Tasks.Buisness;
using Tasks.DAL;

namespace Tasks.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddDbContext<TasksDbConext>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IRepository<ProjectEntity>, ProjectRepository>();
            services.AddTransient<IRepository<TaskEntity>, TaskRepository>();
            services.AddTransient<IRepository<TaskCommentEntity>, TaskCommentRepository>();
            services.AddTransient<IValidator<CreateProjectRequest>, CreateProjectRequestValidator>();
            services.AddTransient<IValidator<CreateTaskRequest>, CreateTaskRequestValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });

            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}