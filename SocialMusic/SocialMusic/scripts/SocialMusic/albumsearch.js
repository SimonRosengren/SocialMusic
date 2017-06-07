SocialMusic.Api = {
    //HEJSAN
    init: function (e) {
        $("#searchForm").submit(function (e) {
            e.preventDefault()
            $("#albumList").empty()
            $.get('/api/search/album?' + $("#searchForm").serialize()).done(function (data) {
                $.each(data, function (key, item) {
                    $('<li>', { text: item.Artist + " : " + item.Name }).appendTo($('#albumList'))
                })
            })
        })
    }
}
