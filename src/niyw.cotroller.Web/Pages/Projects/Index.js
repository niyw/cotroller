$(function () {
    var l = abp.localization.getResource('AgentPools');

    var dataTable = $('#ProjectsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(niyw.cotroller.agentPools.project.getList),
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
                    title: l('LastUpdateTime'),
                    data: "lastUpdateTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                
                {
                    title: l('Description'),
                    data: "description"
                }
            ]
        })
    );
});
