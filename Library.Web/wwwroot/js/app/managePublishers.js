var publisherOptions = {
    columns: [
        { 'data': 'id', 'name': 'Id', 'autoWidth': true },
        { 'data': 'name', 'name': 'Name', 'autoWidth': true },
        {
            "render": function(data, full, row) {
                return "<a  class='btn btn-info'  data-bs-toggle='modal' data-bs-target='#modalWindow' onclick=ajaxPublisherEditGet('" +
                    row.id +
                    "'); >Edit</a>";
            }
        },
        {
            render: function(data, full, row) {
                return "<a  class='btn btn-danger' onclick=ajaxPublisherDeletePost('" + row.id + "'); >Delete</a>";
            }
        }
    ],

    dataSource: {
        url: '/Publishers/LoadData',
        type: 'POST',
        datatype: 'json'
    },
    table: {
        Id: '#publisher-table'
    }
}
InitTable(publisherOptions);

function ajaxPublisherAddGet() {
    var options =
    {
        type: 'GET',
        url: '/Publishers/Add',
    }
    ajaxGet(options);
}

function ajaxPublisherEditPost() {
    var options =
    {
        table: {
            Id : '#publisher-table'
        },
        type: 'POST',
        url: '/Publishers/Edit',
        data: $('#publisherEdit').serialize()
    }
    ajaxPost(options);
}

function ajaxPublisherEditGet(publisherId) {
    var options =
    {
        type: 'GET',
        url: '/Publishers/Edit/' + publisherId,
        data: $('#publisherEdit').serialize()
    }
    ajaxGet(options);
}
function ajaxPublisherDeletePost(publisherId) {

    var options =
    {
        table: {
            Id: '#publisher-table'
        },
        data: {
            Id: publisherId
        },
        type: 'POST',
        url: '/Publishers/Delete'
    }
    ajaxPost(options);
}