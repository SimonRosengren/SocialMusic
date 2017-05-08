Socialmusic = {
    albumSearch: function () {
        $('#album').empty();
        var name = $('#albumName').val();
        $.getJSON('http://ws.audioscrobbler.com/2.0/?method=album.search&album=' + name + '&api_key=7d063e651df846f5a4c10e618858189e&format=json')
            .done(function (data) {
                var number = 0
                while (number < 5) {
                    $('<li>', { text: data.results.albummatches.album[number].name + ' - ' + data.results.albummatches.album[number].artist }).appendTo($('#album'));
                    number++;
                }            
            })
            .fail(function (jqXHR, textStatus, err) {
                $('#album').text('Error: ' + err);
            });
    }
}
