var bookOptions = {
    table: { Id: '#book-table' },
    columns: [
        { 'data': 'id', 'name': 'Id', 'autoWidth': true },
        { 'data': 'name', 'name': 'Name', 'autoWidth': true },
        {
            'data': 'publicationDate', 'name': 'Publication date', 'autoWidth': true,
            render: function(data,full,row) { return moment(row.publicationDate).format('L'); }

        },
        { 'data': 'publisherName', 'name': 'Publisher name', 'autoWidth': true },
        {
            "render": function (data, full, row) { return "<a  class='btn btn-info'  data-bs-toggle='modal' data-bs-target='#modalWindow' onclick=ajaxBookEditGet('" + row.id + "'); >Edit</a>"; }
        },
        {
            render: function (data, full, row) { return "<a  class='btn btn-danger' onclick=ajaxBookDeletePost('" + row.id + "'); >Delete</a>"; }
        }
    ],

    dataSource: {
        url: '/Books/LoadData',
        type: 'POST',
        datatype: 'json',
        data(d) {
            d.startDate = $('#StartDate').val();
            d.endDate = $('#EndDate').val();
            d.publisherId = $('#publisherList').val();
        }
    }
}

InitTable(bookOptions);

function ajaxBookAddGet() {
    var options =
    {
        type: 'GET',
        url: '/Books/Add'
    }
    ajaxGet(options);
}

function ajaxBookEditPost() {
    var options =
    {
        table: {
            Id: '#book-table'
        },
        type: 'POST',
        url: '/Books/Edit',
        data: $('#bookEdit').serialize()
    }
    ajaxPost(options);
}

function ajaxBookEditGet(bookId) {
    var options =
    {
        type: 'GET',
        url: '/Books/Edit/' + bookId,
        data: $('#bookEdit').serialize()
    }
    ajaxGet(options);
}
function ajaxBookDeletePost(bookId) {

    var options =
    {
        table: {
            Id: '#book-table'
        },
        data: {
            Id: bookId
        },
        type: 'POST',
        url: '/Books/Delete'
    }
    ajaxPost(options);
}


