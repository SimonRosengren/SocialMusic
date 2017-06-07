var SocialMusic = {
    init: function () {
        for (var prop in SocialMusic) {
            let child = SocialMusic[prop];
            if (typeof child === 'object' && child.hasOwnProperty('init')) {
                child.init();
            }
        }

        //SocialMusic.Api.init()
    }
}

$(document).ready(function () {
    SocialMusic.init();
    console.log("ready");
})