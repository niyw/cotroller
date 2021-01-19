using System;
using System.Collections.Generic;
using System.Text;

namespace niyw.cotroller.AgentPools
{
    public class CreateUpdateProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ProjectState State { get; set; }
        public int Revision { get; set; }
        public ProjectVisibility Visibility { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
