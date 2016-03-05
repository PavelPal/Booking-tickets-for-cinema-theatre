jQuery(function($) {
    var $bodyEl = $("body"),
        $sidedrawerEl = $("#sidedrawer");

    function showSidedrawer() {
        var options = {
            onclose: function() {
                $sidedrawerEl
                    .removeClass("active")
                    .appendTo(document.body);
            }
        };

        var $overlayEl = $(mui.overlay("on", options));

        $sidedrawerEl.appendTo($overlayEl);
        setTimeout(function() {
            $sidedrawerEl.addClass("active");
        }, 20);
    }


    function hideSidedrawer() {
        $bodyEl.toggleClass("hide-sidedrawer");
    }


    $(".js-show-sidedrawer").on("click", showSidedrawer);
    $(".js-hide-sidedrawer").on("click", hideSidedrawer);

    var $titleEls = $("strong", $sidedrawerEl);

    $titleEls
        .next()
        .hide();

    $titleEls.on("click", function() {
        $(this).next().slideToggle(200);
    });
});

$(document).ready(function() {
    var skipCinemas = 3,
        skipSessions = 3,
        inCinemaProgrss = false,
        inSessionProgrss = false;
    $("#load-more-cinemas-btn").click(function() {
        $.ajax({
            url: "/Home/LoadMoreCinemas",
            method: "GET",
            data: { 'skip': skipCinemas },
            beforeSend: function() {
                inCinemaProgrss = true;
                $("#fountainG").css({
                    '-ms-opacity': "1",
                    'opacity': "1"
                });
            },
            complete: function() {
                $("#fountainG").css({
                    '-ms-opacity': "0",
                    'opacity': "0"
                });
            }
        }).done(function(data) {
            if (data.length > 0) {
                $("#cinemas-load-box").css("display", "block");
                $.each(data, function(index, data) {
                    $("#cinemas-block").append("<div class=\"item-block\">" +
                        "<div class=\"mui-panel\">" +
                        "<div class=\"mui--text-headline\">" + data.Name + "</div>" +
                        "<div class=\"panel-block\">" +
                        "<div class=\"mui--text-body2\">Адрес: " + data.Address + "<br />" +
                        "<a class=\"mui-btn mui-btn--flat\" href=\"" + data.WebSite + " target=\"_blank\">" +
                        "сайт кинотеатра</a></div></div>" +
                        "<a href=\"Cinema/Cinema/" + data.Id + "\" class=\"mui-btn mui-btn--flat mui-btn--primary\">Подробнее</a>" + "</div></div>");
                });
                inCinemaProgrss = false;
                skipCinemas += 9;
            } else {
                $("#cinemas-load-box").css("display", "none");
            }
            if (data.length < 9) {
                $("#cinemas-load-box").css("display", "none");
            }
        });
    });
    $("#load-more-cinemas-btn").click(function() {
        $.ajax({
            url: "/Home/LoadMoreSessions",
            method: "GET",
            data: { 'skip': skipSessions },
            beforeSend: function() {
                inCinemaProgrss = true;
                $("#fountainG").css({
                    '-ms-opacity': "1",
                    'opacity': "1"
                });
            },
            complete: function () {
                $("#fountainG").css({
                    '-ms-opacity': "0",
                    'opacity': "0"
                });
            }
        }).done(function(data) {
            if (data.length > 0) {
                $("#sessions-load-box").css("display", "block");
                $.each(data, function(index, data) {
                    $("#sessions-block").append("<div class=\"item-block\">" +
                        "<div class=\"mui-panel\">" +
                        "<div class=\"mui--text-headline\">" + data.Scene.Name + "</div>" +
                        "<div class=\"panel-block\">" +
                        "<div class=\"mui--text-body2\">Время проведения: " + data.Date + "<br />" +
                        "Кинотеатр: " + data.Cinema.Name +
                        "</div></div>" +
                        "<a href=\"Session/Session/" + data.Id + "\" class=\"mui-btn mui-btn--flat mui-btn--primary\">Подробнее</a>" + "</div></div>");
                });
                inSessionProgrss = false;
                skipSessions += 9;
            } else {
                $("#sessions-load-box").css("display", "none");
            }
            if (data.length < 9) {
                $("#sessions-load-box").css("display", "none");
            }
        });
    });
});