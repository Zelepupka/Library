var genreOptions = {
    table: '#genre-table',
    columns: [
        { 'data': 'id', 'name': 'GenreId', 'autoWidth': true },
        { 'data': 'name', 'name': 'Name', 'autoWidth': true },
        {
            "render": function (data, full, row) { return "<a  class='btn btn-info'  data-bs-toggle='modal' data-bs-target='#modalWindow' onclick=ajaxGenreEditGet('" + row.id + "'); >Edit</a>"; }
        },
        {
            render: function (data, full, row) { return "<a  class='btn btn-danger' onclick=ajaxGenreDeletePost('" + row.id + "'); >Delete</a>"; }
        }
    ],

    dataSource: {
        url: '/Genres/LoadData',
        type: 'POST',
        datatype: 'json'
    }
}
InitTable(genreOptions);

function ajaxGenreAddGet() {
    var options =
    {
        type: 'GET',
        url: '/Genres/Add',
        dataType: 'html'
    }
    ajaxGet(options);
}

function ajaxGenreEditPost() {
    var options =
    {
        type: 'POST',
        url: '/Genres/Edit',
        data: $('#genreEdit').serialize()
    }
    ajaxPost(options);
}

function ajaxGenreEditGet(genreId) {
    var options =
    {
        type: 'GET',
        url: '/Genres/Edit/' + genreId,
        datatype:'html',
        data: $('#genreEdit').serialize()
    }
    ajaxGet(options);
}
function ajaxGenreDeletePost(genreId) {

    var options =
    {
        data: {
            Id: genreId
        },
        type: 'POST',
        url: 'Genres/Delete'
    }
    ajaxPost(options);
}
