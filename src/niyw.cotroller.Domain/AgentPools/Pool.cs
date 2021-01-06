using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace niyw.cotroller.AgentPools
{
    public class Pool: AuditedAggregateRoot<Guid>
    {
        public DateTime CreatedOn { get; set; }
        public bool AutoProvision { get; set; }
        public bool AutoUpdate { get; set; }
        public bool AutoSize { get; set; }
        public int TargetSize { get; set; }
        public int AgentCloudId { get; set; }
        public string CreatedBy { get; set; }
        public string Owner { get; set; }
        public int PoolId { get; set; }
        public string Scope { get; set; }
        public string Name { get; set; }
        public bool IsHosted { get; set; }
        public TaskAgentPoolType PoolType { get; set; }
        public int Size { get; set; }
        public bool IsLegacy { get; set; }
        public TaskAgentPoolOptions Options { get; set; }
    }

 
}
/*
        {
            "createdOn": "2019-07-10T21:02:09.52Z",
            "autoProvision": true,
            "autoUpdate": true,
            "autoSize": true,
            "targetSize": 1,
            "agentCloudId": 1,
            "createdBy": {
                "displayName": "Microsoft.VisualStudio.Services.TFS",
                "url": "https://spsprodea1.vssps.visualstudio.com/Aa64aeb08-841a-42e6-81a5-b079c70c56be/_apis/Identities/00000002-0000-8888-8000-000000000000",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/msnyw/_apis/GraphProfile/MemberAvatars/s2s.MDAwMDAwMDItMDAwMC04ODg4LTgwMDAtMDAwMDAwMDAwMDAwQDJjODk1OTA4LTA0ZTAtNDk1Mi04OWZkLTU0YjAwNDZkNjI4OA"
                    }
                },
                "id": "00000002-0000-8888-8000-000000000000",
                "uniqueName": "00000002-0000-8888-8000-000000000000@2c895908-04e0-4952-89fd-54b0046d6288",
                "imageUrl": "https://dev.azure.com/msnyw/_apis/GraphProfile/MemberAvatars/s2s.MDAwMDAwMDItMDAwMC04ODg4LTgwMDAtMDAwMDAwMDAwMDAwQDJjODk1OTA4LTA0ZTAtNDk1Mi04OWZkLTU0YjAwNDZkNjI4OA",
                "descriptor": "s2s.MDAwMDAwMDItMDAwMC04ODg4LTgwMDAtMDAwMDAwMDAwMDAwQDJjODk1OTA4LTA0ZTAtNDk1Mi04OWZkLTU0YjAwNDZkNjI4OA"
            },
            "owner": {
                "displayName": "Microsoft.VisualStudio.Services.TFS",
                "url": "https://spsprodea1.vssps.visualstudio.com/Aa64aeb08-841a-42e6-81a5-b079c70c56be/_apis/Identities/00000002-0000-8888-8000-000000000000",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/msnyw/_apis/GraphProfile/MemberAvatars/s2s.MDAwMDAwMDItMDAwMC04ODg4LTgwMDAtMDAwMDAwMDAwMDAwQDJjODk1OTA4LTA0ZTAtNDk1Mi04OWZkLTU0YjAwNDZkNjI4OA"
                    }
                },
                "id": "00000002-0000-8888-8000-000000000000",
                "uniqueName": "00000002-0000-8888-8000-000000000000@2c895908-04e0-4952-89fd-54b0046d6288",
                "imageUrl": "https://dev.azure.com/msnyw/_apis/GraphProfile/MemberAvatars/s2s.MDAwMDAwMDItMDAwMC04ODg4LTgwMDAtMDAwMDAwMDAwMDAwQDJjODk1OTA4LTA0ZTAtNDk1Mi04OWZkLTU0YjAwNDZkNjI4OA",
                "descriptor": "s2s.MDAwMDAwMDItMDAwMC04ODg4LTgwMDAtMDAwMDAwMDAwMDAwQDJjODk1OTA4LTA0ZTAtNDk1Mi04OWZkLTU0YjAwNDZkNjI4OA"
            },
            "id": 10,
            "scope": "27d50f95-4d70-427f-b48a-3995cccdcd72",
            "name": "Azure Pipelines",
            "isHosted": true,
            "poolType": "automation",
            "size": 1,
            "isLegacy": false,
            "options": "none"
        } 

 */