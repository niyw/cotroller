using System;
using System.Collections.Generic;
using System.Text;

namespace niyw.cotroller.AgentPools
{
    public class CreateUpdatePoolDto
    {
        public DateTime CreatedOn { get; set; }
        public bool AutoProvision { get; set; }
        public bool AutoUpdate { get; set; }
        public bool AutoSize { get; set; }
        public int? TargetSize { get; set; }
        public int? AgentCloudId { get; set; }
        public TfsAccount CreatedBy { get; set; }
        public TfsAccount Owner { get; set; }
        public int Id { get; set; }
        public string Scope { get; set; }
        public string Name { get; set; }
        public bool IsHosted { get; set; }
        public TaskAgentPoolType PoolType { get; set; }
        public int Size { get; set; }
        public bool IsLegacy { get; set; }
        public TaskAgentPoolOptions Options { get; set; }
    }
}
