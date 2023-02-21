using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Exceptions;
using Tasks.Application.Requests;
using Tasks.Application.Validators;
using Tasks.Buisness;
using Tasks.DAL;

namespace Tasks.Application.Services
{
    public class ProjectService : IProjectService
    {
        private IRepository<ProjectEntity> _projectRepository;

        public ProjectService(IRepository<ProjectEntity> projectRepository)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task CreateProjectAsync(CreateProjectRequest request)
        {
            var project = new ProjectEntity(request.Name);
            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
        }
    }
}
