function addComment() {
    $.ajax({
        type: 'POST',
        url: '/Books/AddComment',
        dataType: 'json',
        data: {
            content: $('#comment-text').val(),
        },
        success: function (data) {
          
        }
    });
}