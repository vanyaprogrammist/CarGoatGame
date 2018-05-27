
window.onload = function () {
    $("main .jumbotron").each(function () {
        $(this).data("height", $(this).height());
    });
    $("main .jumbotron").css("height", 0);
    $("main .jumbotron").css("padding", 0);
    $("main .jumbotron").css("margin", 0);
}

$("main .table-name").each(function () {
    $(this).click(function() {
        $(this).next(".jumbotron").animate({
                height: $(this).next(".jumbotron").data("height") + 40,
                paddingRight: 60,
                paddingLeft: 60,
                paddingTop: 48,
                marginBottom: 30
            },
            250);
    });
});

$("main .jumbotron").each(function () {
    $(this).click(function () {
        $(this).animate({
            height: 0,
            padding: 0,
            margin: 0
        }, 300);
    });
});

$(".btn-play").click(function() {
    window.location.reload();
});
