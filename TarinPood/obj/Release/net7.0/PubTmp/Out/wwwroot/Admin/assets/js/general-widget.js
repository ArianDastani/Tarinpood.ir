"use strict";
var general_widget = {
    init: function() {
        $('#owl-carousel-testimonial').owlCarousel({
            loop:true,
            margin:10,
            items:1,
            nav:false,
            dots:false
        });
        const months = ["دی", "بهمن", "اسفند", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر"]
        const now = new Date()
        $('#monthDay').append(`${now.getDate()+10} ${months[now.getMonth()]}`);
        $('#year').append(`${now.getFullYear()-621}`);
        $(function() {
            setInterval( function() {
                var seconds = new Date().getSeconds();
                var sdegree = seconds * 6;
                var srotate = "rotate(" + sdegree + "deg)";
                $("#sec").css({ "transform": srotate });
            }, 1000 );
            setInterval( function() {
                var hours = new Date().getHours();
                var mins = new Date().getMinutes();
                var hdegree = hours * 30 + (mins / 2);
                var hrotate = "rotate(" + hdegree + "deg)";
                $("#hour").css({ "transform": hrotate});
            }, 1000 );
            setInterval( function() {
                var mins = new Date().getMinutes();
                var mdegree = mins * 6;
                var mrotate = "rotate(" + mdegree + "deg)";
                $("#min").css({ "transform" : mrotate });

            }, 1000 );
        }); 
    }
};
(function($) {
    "use strict";
    general_widget.init();
})(jQuery);