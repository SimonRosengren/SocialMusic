Socialmusic = {
    postWallmessage: function () {
        $('#message').submit(function (e) {
            /*Prevents the page to reaload like it normaly should*/
            e.preventDefault()
            /*Do the post through Ajax*/
            $.ajax({
                type: 'POST',
                url: '/wallmessages/PostToWall',
                data: { message: $('#input').val() }
            })
            /*Adds the new message to the html*/
            $('#newMessages').append('<li>' + $('#input').val() + '</li>')
            /*Sets the text input to empty*/
            $('#input').val('')
        })
    }
}