function AjaxGet() {
        $.ajax({
            type: "GET",
            url: '/Genres/Add',
            dataType: 'html',
            success: function(data) {
                console.log(data);
                $('#formBody').html(data);
                $('#formBody').show();
            }
        });

}

function AjaxPost() {
        $.ajax({
            url: '/Genres/Edit',
            type: 'POST',
            data: {
                Id: document.getElementById('idBox').textContent,
                Name: document.getElementById('nameBox').textContent
            },
            success: function() {
               
            }
        });
}

function AjaxDelete(id) {
        $.ajax({
            url: '/Genres/Delete',
            type: 'GET',
            data: id,
            success: function() {
               
            }
        });
}
  
