$(document).ready(function () {
    $('.acc-box, .acc-arrow').hide();
    $('.notif-box, .notif-arrow').hide();
    $('.acc-box, .acc-arrow, .notif-box, .notif-arrow').removeClass('hidex');
});
//acc-box

$(function () {
    $('.options, #role').on("click", function (e) {
        $('.acc-box, .acc-arrow').fadeToggle(1);
    });
    $(document).on("click", function (e) {
        if ($(e.target).is('.options, #role, .acc-box, .acc-arrow, .acc-box>ul>li>a') === false) {
            $('.acc-box, .acc-arrow').fadeOut(1);
        }
    });
});

//notif-box

$(function () {
    $('.i-globe').on("click", function (e) {
        $('.notif-box, .notif-arrow').fadeToggle(1);
    });
    $(document).on("click", function (e) {
        if ($(e.target).is('.i-globe, .notif-box, .notif-arrow, .notif-box>ul>li>a') === false) {
            $('.notif-box, .notif-arrow').fadeOut(1);
        }
    });
});

//search-modal
$('.i-search, #search').click(function () {
    $('#modal-container').removeAttr('class').addClass('one');
    $('body').addClass('modal-active');
});

$('#modal-close').click(function () {
    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');
});

//hamburgers.js
var forEach = function (t, o, r) {
    if ("[object Object]" === Object.prototype.toString.call(t))
        for (var c in t) Object.prototype.hasOwnProperty.call(t, c) && o.call(r, t[c], c, t);
    else
        for (var e = 0, l = t.length; l > e; e++) o.call(r, t[e], e, t);
};

var hamburgers = document.querySelectorAll(".hamburger");
if (hamburgers.length > 0) {
    forEach(hamburgers, function (hamburger) {
        hamburger.addEventListener("click", function () {
            this.classList.toggle("is-active");
        }, false);
    });
}
