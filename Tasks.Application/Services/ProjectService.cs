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
        private IValidator<CreateProjectRequest> _validator;

        public ProjectService(IRepository<ProjectEntity> projectRepository, IValidator<CreateProjectRequest> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task CreateProjectAsync(CreateProjectRequest request)
        {
            var valid = _validator.Valid(request);
            if (!valid) throw new InvalidRequestException();
            var project = new ProjectEntity
            {
                Name = request.Name,
                CreateDate = DateTime.UtcNow,
            };
            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
        }
    }
}
