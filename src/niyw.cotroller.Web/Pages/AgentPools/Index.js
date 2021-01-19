$(function () {
    var l = abp.localization.getResource('AgentPools');

    var dataTable = $('#AgentPoolsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(niyw.cotroller.agentPools.pool.getList),
            columnDefs: [
                {
                    title: l('Id'),
                    data: "id"
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('PoolType'),
                    data: "poolType",
                    render: function (data) {
                        return l('Enum:TaskAgentPoolType:' + data);
                    }
                },
                {
                    title: l('CreatedOn'),
                    data: "createdOn",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                
                {
                    title: l('IsHosted'),
                    data: "isHosted"
                },
                {
                    title: l('IsLegacy'),
                    data: "isLegacy"
                }
            ]
        })
    );
});
