
function ajaxGet(options) {
        $.ajax({
            type: options.type,
            url: options.url,
            dataType: 'html',
            success: function (data)
            {
                $('#ajaxPart').html(data);
                $('#ajaxPart').show();
            }
        });
}

function ajaxPost(options) {
    $.ajax({
        url: options.url,
        type: options.type,
        data: options.data,
        success: function() {
            $(options.table.Id).DataTable().draw();
        }
    });
}
