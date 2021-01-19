using System;
using System.Collections.Generic;
using System.Text;

namespace niyw.cotroller.AgentPools
{
    public enum ProjectState
    {
        All=0,
        CreatePending=1,
        Deleted=2,
        Deleting=3,
        New=4,
        Unchanged=5,
        WellFormed=6
    }
}
