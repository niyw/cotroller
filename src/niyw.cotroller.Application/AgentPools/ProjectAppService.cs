using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace niyw.cotroller.AgentPools
{
    public class ProjectAppService : 
        CrudAppService<Project, ProjectDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProjectDto>, 
        IProjectAppService
    {
        public ProjectAppService(IRepository<Project, Guid> repository)
            : base(repository)
        {

        }
    }
}
