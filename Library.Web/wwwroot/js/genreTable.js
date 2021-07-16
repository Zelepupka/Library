$(document).ready(function () {
    $("#genre-table").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

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