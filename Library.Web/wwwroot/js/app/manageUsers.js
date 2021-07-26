var userOptions = {
    columns: [
        { 'data': 'id', 'name': 'Id', 'autoWidth': true },
        { 'data': 'username', 'name': 'UserName', 'autoWidth': true },
        { 'data': 'email', 'name': 'Email', 'autoWidth': true },
        { 'data': 'roles', 'name': 'Roles', 'autoWidth': true },
        {
            "render": function (data, full, row) {
                return "<a  class='btn btn-info'  data-bs-toggle='modal' data-bs-target='#modalWindow' onclick=ajaxUserEditGet('" + row.id + "'); >Edit</a>";
            }
        },
        {
            render: function (data, full, row) {
                return "<a  class='btn btn-danger' onclick=ajaxUserDeletePost('" + row.id + "'); >Delete</a>";
            }
        }
    ],

    dataSource: {
        url: '/Users/LoadData',
        type: 'POST',
        datatype: 'json'
    },
    table: {
        Id: '#user-table'
    }
}
InitTable(userOptions);

//function ajaxUserAddGet() {
//    var options =
//    {
//        type: 'GET',
//        url: '/Users/Add',
//    }
//    ajaxGet(options);
//}

function ajaxUserEditPost() {
    var options =
    {
        table: {
            Id: '#user-table'
        },
        type: 'POST',
        url: '/Users/Edit',
        data: $('#userEdit').serialize()
    }
    ajaxPost(options);
}

function ajaxUserEditGet(userId) {
    var options =
    {
        type: 'GET',
        url: '/Users/Edit/' + userId,
        data: $('#userEdit').serialize()
    }
    ajaxGet(options);
}
function ajaxUserDeletePost(userId) {

    var options =
    {
        table: {
            Id: '#user-table'
        },
        data: {
            Id: userId
        },
        type: 'POST',
        url: '/Users/Delete'
    }
    ajaxPost(options);
}