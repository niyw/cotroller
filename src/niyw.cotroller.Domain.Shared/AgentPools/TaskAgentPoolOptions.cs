using System;
using System.Collections.Generic;
using System.Text;

namespace niyw.cotroller.AgentPools
{
    public enum TaskAgentPoolOptions
    {
        ElasticPool,
        None,
        PreserveAgentOnJobFailure,
        SingleUseAgents
    }
}
