var hubConnection = new signalR.HubConnectionBuilder()
            .configureLogging(signalR.LogLevel.Debug)
            .withUrl("https://localhost:5001/hub")
            .build();

hubConnection.on('SendComment',
    function(data) {
        model.comments.push(data);
    });

function signalComment() {
    addComment();
    var comment = {
        content: $('#comment-text').val(),
        user: {
            username: $('#user-name').val()
        }   
    }
    try {
        hubConnection.invoke('SendComment', comment);
    } catch (err) {
        console.error(err);
    }
}

hubConnection.start().then(function() {
    console.log('Connected!');
}).catch(function(err) {
    return console.error(err.toString());
});