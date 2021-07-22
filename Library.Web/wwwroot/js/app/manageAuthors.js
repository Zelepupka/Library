var genreOptions = {
    table: { Id: '#author-table' },
    columns: [
        { 'data': 'id', 'name': 'Id', 'autoWidth': true },
        { 'data': 'firstName', 'name': 'First name', 'autoWidth': true },
        { 'data': 'surname', 'name': 'Surame', 'autoWidth': true },
        {
            "render": function (data, full, row) { return "<a  class='btn btn-info'  data-bs-toggle='modal' data-bs-target='#modalWindow' onclick=ajaxAuthorEditGet('" + row.id + "'); >Edit</a>"; }
        },
        {
            render: function (data, full, row) { return "<a  class='btn btn-danger' onclick=ajaxAuthorDeletePost('" + row.id + "'); >Delete</a>"; }
        }
    ],

    dataSource: {
        url: '/Authors/LoadData',
        type: 'POST',
        datatype: 'json'
    }
}

InitTable(genreOptions);

function ajaxAuthorAddGet() {
    var options =
    {
        type: 'GET',
        url: '/Authors/Add'
    }
    ajaxGet(options);
}

function ajaxAuthorEditPost() {
    var options =
    {
        table: {
            Id: '#author-table'
        },
        type: 'POST',
        url: '/Authors/Edit',
        data: $('#authorEdit').serialize()
    }
    ajaxPost(options);
}

function ajaxAuthorEditGet(authorId) {
    var options =
    {
        type: 'GET',
        url: '/Authors/Edit/' + authorId,
        data: $('#authorEdit').serialize()
    }
    ajaxGet(options);
}
function ajaxAuthorDeletePost(authorId) {

    var options =
    {
        table: {
            Id: '#author-table'
        },
        data: {
            Id: authorId
        },
        type: 'POST',
        url: '/Authors/Delete'
    }
    ajaxPost(options);
}