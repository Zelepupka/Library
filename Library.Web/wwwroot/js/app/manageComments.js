var model =
{
    comments: ko.observableArray()
}

function addComment() {
    $.ajax({
        type: 'POST',
        url: '/Comments/Add',
        dataType: 'json',
        data: {
            content: $('#comment-text').val(),
            bookId: $('#book-id').val()
},
        error: function (data) {
            getAllComments();
        }

    });
}

function getAllComments() {
    $.ajax({
        type: 'POST',
        url: '/Comments/LoadComments',
        dataType: 'json',
        data: {
            bookId: $('#book-id').val()
        },
        success: function (data) {
            model.comments(data);
        }
    });
}

$(document).ready(function() {
    getAllComments();
    ko.applyBindings(model);
});

