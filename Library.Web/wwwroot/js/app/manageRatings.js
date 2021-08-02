function addRating() {
    $.ajax({
        type: 'POST',
        url: '/Ratings/Add',
        dataType: 'json',
        data: {
                bookId: $('#book-id').val(),
                value: $('#rating-range').val()
            }
    });
}

