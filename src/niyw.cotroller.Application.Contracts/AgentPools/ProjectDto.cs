using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace niyw.cotroller.AgentPools
{
   public class ProjectDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ProjectState State { get; set; }
        public int Revision { get; set; }
        public ProjectVisibility Visibility { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
