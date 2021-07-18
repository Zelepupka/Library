
function InitTable() {
    $(document).ready(function () {
        $("#genre-table").DataTable({
            "processing": true,
            "serverSide": true,
            "filter": true,
            "orderMulti": false,
            "ajax": {
                "url": "/Genres/LoadData",
                "type": "POST",
                "datatype": "json"
            },

            "columns": [
                { "data": "id", "name": "Id", "autoWidth": true },
                { "data": "name", "name": "Name", "autoWidth": true }
            ]

        });
    });
}

