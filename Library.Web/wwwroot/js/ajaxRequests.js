
function ajaxGet(options) {
        $.ajax({
            type: options.type,
            url: options.url,
            dataType: options.dataType,
            success: function (data)
            {
                $('#formBody').html(data);
                $('#formBody').show();
            }
        });
}

function ajaxPost(options) {
    $.ajax({
        url: options.url,
        type: options.type,
        data: options.data,
        success: function() {
            $('#genre-table').DataTable().draw();
        }
    });
}
