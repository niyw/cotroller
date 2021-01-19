using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace niyw.cotroller.AgentPools
{
    public interface IProjectAppService: 
        ICrudAppService<ProjectDto,Guid, PagedAndSortedResultRequestDto, CreateUpdateProjectDto>
    {
    }
}
