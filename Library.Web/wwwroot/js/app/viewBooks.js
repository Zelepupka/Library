var model = {
    books: ko.observableArray()
}

function getAllBooks() {
    $.ajax({
        type: 'POST',
        url: '/Books/LoadBooks',
        dataType: 'json',
        data: {
            name: $('#searchInput').val(),
            startDate: $('#startDate').val(),
            endDate: $('#endDate').val(),
            publisherId : $('#publisherList').val()
        },
        success: function (data) {
            model.books.removeAll();
            for (var i = 0; i < data.length; i++) {
                model.books.push(data[i]);
            }
        }
    });
}


function clearFilters() {
    $('#startDate').val(null);
    $('#endDate').val(null);
    $('#publisherList').val(null);
    $('#searchInput').val(null);
    getAllBooks();
}


$(document).ready(function() {
    getAllBooks();
    ko.applyBindings(model);
});