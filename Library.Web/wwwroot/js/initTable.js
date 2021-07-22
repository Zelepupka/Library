
function InitTable(options) {
    $(document).ready(function () {
        $(options.table.Id).DataTable({
            'processing': true,
            'serverSide': true,
            'filter': true,
            'orderMulti': false,
            'searchDelay': 1000,
            'ajax': options.dataSource,
            'columns': options.columns
        });
    });
}

