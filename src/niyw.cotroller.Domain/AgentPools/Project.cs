using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace niyw.cotroller.AgentPools
{

    public class Project : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ProjectState State { get; set; }
        public int Revision { get; set; }
        public ProjectVisibility Visibility { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }


    /*
        {
            "id": "15f63b1f-65b4-4c7d-b91b-6b3b16ad02df",
            "name": "apimgt",
            "description": "api managemnt base ocelot",
            "url": "https://dev.azure.com/msnyw/_apis/projects/15f63b1f-65b4-4c7d-b91b-6b3b16ad02df",
            "state": "wellFormed",
            "revision": 109,
            "visibility": "private",
            "lastUpdateTime": "2019-07-30T07:29:14.623Z"
        }
     */
}
