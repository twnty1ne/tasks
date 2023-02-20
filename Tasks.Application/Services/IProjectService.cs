using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Requests;
using Tasks.Buisness;

namespace Tasks.Application.Services
{
    public interface IProjectService
    {
        Task CreateProjectAsync(CreateProjectRequest request);
    }
}
