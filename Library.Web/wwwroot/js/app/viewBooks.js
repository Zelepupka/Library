var model = {
    books: ko.observableArray()
}

function getAllBooks() {
    $.ajax({
        type: 'GET',
        url: '/Books/LoadBooks',
        dataType: 'json',
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                model.books.push(data[i]);
            }
        }
    });
}

$(document).ready(function() {
    getAllBooks();
    ko.applyBindings(model);
});