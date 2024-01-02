(function ($) {
    "use strict";
    // for sticky navbar
    $(window).scroll(function () {
        if ($(window).scrollTop() > 120) {
            $(".navbar-area").addClass("sticky");
        } else {
            $(".navbar-area").removeClass("sticky");
        }
    });

    $(window).on("load", function (event) {
        $("#pre-loader").delay(800).fadeOut(500);
    });

    // popup button
    $('.popup-button').click(function () {
        $('.popup').css('visibility', 'visible');
        $('.popup-content').addClass('hi');
    })
    $('#popup-close').click(function () {
        $('.popup').css('visibility', 'hidden');
        $('.popup-content').removeClass('hi');
    })


    // Mean Menu
    $(".mean-menu").meanmenu({
        meanScreenWidth: "991",
    });

    $(".banner-img-slider-area").owlCarousel({
        autoplayHoverPause: true,
        autoplaySpeed: 2000,
        autoplay: true,
        loop: true,
        dots: true,
        items: 1,
        rtl: true,
    });

    $(".testimonial-slider-area").owlCarousel({
        autoplayHoverPause: true,
        autoplaySpeed: 2000,
        autoplay: true,
        loop: true,
        dots: true,
        margin: 30,
        rtl: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1100: {
                items: 3,
            },
        }
    });

    $(".home-banner-slider-area").owlCarousel({
        autoplayHoverPause: true,
        autoplaySpeed: 3000,
        autoplay: true,
        loop: true,
        dots: true,
        items: 1,
        rtl: true,
        autoHeight: true,
        animateOut: 'zoomOut',
        animateIn: 'zoomIn',
    });

    // Index 02 Service Slider
    $(".service-slider-area-2").owlCarousel({
        autoplayHoverPause: true,
        autoplaySpeed: 2000,
        autoplay: true,
        loop: true,
        dots: true,
        margin: 30,
        rtl: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1100: {
                items: 3,
            },
        }
    });

    // Index 02 Service Slider
    $(".team-slider-area-2").owlCarousel({
        autoplayHoverPause: true,
        autoplaySpeed: 2000,
        autoplay: true,
        loop: true,
        dots: true,
        margin: 30,
        rtl: true,
        responsive: {
            0: {
                items: 1,
                center: true,
            },
            600: {
                items: 2,
            },
            1100: {
                items: 3,
                center: true,
            },
        }
    });

    // Index 02 Testimonials Slider
    $(".testimonial-slider-area-2").owlCarousel({
        autoplayHoverPause: true,
        autoplaySpeed: 2000,
        autoplay: true,
        loop: true,
        dots: true,
        margin: 30,
        rtl: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1100: {
                items: 3,
            },
        }
    });

    // Index 03 banner Slider
    const swiper = new Swiper('.swiper', {
        // Optional parameters
        loop: true,effect: "creative",
        creativeEffect: {
        prev: {
            shadow: true,
            translate: [0, 0, -400],
        },
        next: {
            translate: ["100%", 0, 0],
        },
        },
        grabCursor: true,
        speed: 1000,
        autoplay: {
            delay: 5000,
            pauseOnMouseEnter: true,
        },
        // If we need pagination
        pagination: {
            el: '.swiper-pagination',
            type: "fraction",
        }
    });

     // Range Slider
    $( "#range-slider" ).slider({
        range: true,
        min: 50,
        max: 400,
        values: [100, 200],
        slide: function( event, ui ) {
            $( "#price-amount" ).val( ui.values[ 0 ] + "تومان - " + ui.values[ 1 ] + "تومان" );
        }
    });
    $( "#price-amount" ).val( $( "#range-slider" ).slider( "values", 0 ) + "تومان - " +
    $( "#range-slider" ).slider( "values", 1 ) + "تومان");  

    // Video PopUp
    $(".video-popup").magnificPopup({
        type: "iframe",
    });
    
    // language select
    $("select").niceSelect();

    // Input Plus & Minus Number JS
    $('.input-counter').each(function() {
        var spinner = jQuery(this),
        input = spinner.find('input[type="text"]'),
        btnUp = spinner.find('.plus-btn'),
        btnDown = spinner.find('.minus-btn'),
        min = input.attr('min'),
        max = input.attr('max');
        
        btnUp.on('click', function() {
            var oldValue = parseFloat(input.val());
            if (oldValue >= max) {
                var newVal = oldValue;
            } else {
                var newVal = oldValue + 1;
            }
            spinner.find("input").val(newVal);
            spinner.find("input").trigger("change");
        });

        btnDown.on('click', function() {
            var oldValue = parseFloat(input.val());
            if (oldValue <= min) {
                var newVal = oldValue;
            } else {
                var newVal = oldValue - 1;
            }
            spinner.find("input").val(newVal);
            spinner.find("input").trigger("change");
        });
    }); 

    // Subscribe form
	$(".newsletter-form").validator().on("submit", function (event) {
		if (event.isDefaultPrevented()) {
			// handle the invalid form...
			formErrorSub();
			submitMSGSub(false, "لطفا ایمیل خود را به درستی وارد کنید.");
		} else {
			// everything looks good!
			event.preventDefault();
		}
	});
	function callbackFunction (resp) {
		if (resp.result === "success") {
			formSuccessSub();
		}
		else {
			formErrorSub();
		}
	}
	function formSuccessSub(){
		$(".newsletter-form")[0].reset();
		submitMSGSub(true, "با تشکر از شما برای اشتراک!");
		setTimeout(function() {
			$("#validator-newsletter").addClass('hide');
		}, 4000)
	}
	function formErrorSub(){
		$(".newsletter-form").addClass("animated shake");
		setTimeout(function() {
			$(".newsletter-form").removeClass("animated shake");
		}, 1000)
	}
	function submitMSGSub(valid, msg){
		if(valid){
			var msgClasses = "validation-success";
		} else {
			var msgClasses = "validation-danger";
		}
		$("#validator-newsletter").removeClass().addClass(msgClasses).text(msg);
	}
	$(".newsletter-form").ajaxChimp({
		url: "https://envytheme.us20.list-manage.com/subscribe/post?u=60e1ffe2e8a68ce1204cd39a5&amp;id=42d6d188d9", // Your url MailChimp
		callback: callbackFunction
	});

    // Go to Top
    var progressPath = document.querySelector('.progress-wrap path');
		var pathLength = progressPath.getTotalLength();
		progressPath.style.transition = progressPath.style.WebkitTransition = 'none';
		progressPath.style.strokeDasharray = pathLength + ' ' + pathLength;
		progressPath.style.strokeDashoffset = pathLength;
		progressPath.getBoundingClientRect();
		progressPath.style.transition = progressPath.style.WebkitTransition = 'stroke-dashoffset 10ms linear';		
		var updateProgress = function () {
			var scroll = $(window).scrollTop();
			var height = $(document).height() - $(window).height();
			var progress = pathLength - (scroll * pathLength / height);
			progressPath.style.strokeDashoffset = progress;
		}
		updateProgress();
		$(window).scroll(updateProgress);	
		var offset = 50;
		var duration = 50;
		jQuery(window).on('scroll', function() {
			if (jQuery(this).scrollTop() > offset) {
				jQuery('.progress-wrap').addClass('active-progress');
			} else {
				jQuery('.progress-wrap').removeClass('active-progress');
			}
		});				
    jQuery('.progress-wrap').on('click', function (event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    });
    
    $('.js-tilt').tilt({
        perspective: 1500,
    })

    $(".odometer").appear(function (e) {
        var odo = $(".odometer");
        odo.each(function () {
            var countNumber = $(this).attr("data-count");
            $(this).html(countNumber);
        });
    });

    // WOW Animation JS
    if ($(".wow").length) {
        var wow = new WOW({
            mobile: false,
        });
        wow.init();
    }

})(jQuery);