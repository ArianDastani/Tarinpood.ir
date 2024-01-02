var SweetAlert_custom = {
    init: function() {
        document.querySelector('.sweet-1').onclick = function(){
            swal("سلام دنیا!");
        },  document.querySelector('.sweet-2').onclick = function(){
                swal("عنوان در اینجا!", "و متن در اینجا نوشته می شود ...");
        },  document.querySelector('.sweet-3').onclick = function(){
                swal("خوب به نظر می رسد!", "شما این دکمه را کلیک کردید!", "info");
        },  document.querySelector('.sweet-4').onclick = function(){
                swal("روی دکمه زیر یا خارج از مُدال کلیک کنید!")
                .then((value) => {
                swal(`مقدار بازگشت داده شده : ${value}`);
            });
        },  document.querySelector('.sweet-5').onclick = function(){
                swal({
                    title: "آیا مطمئن هستید؟",
                    text: "بعد از حذف شما قادر به بازگردانی فایل نخواهید بود!",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                })
                .then((willDelete) => {
                    if (willDelete) {
                        swal("اووه! شما این فایل را حذف کردید", {
                            icon: "success",
                        });
                    } else {
                        swal("شما از حذف فایل پشیمان شدید!");
                    }
                })
        },  document.querySelector('.sweet-6').onclick = function(){
                swal("خوب به نظر می رسه!", "شما این دکمه را کلیک کردید!", "warning");
        },  document.querySelector('.sweet-7').onclick = function(){
                swal("خوب به نظر می رسه!", "شما این دکمه را کلیک کردید!", "error");
        },  document.querySelector('.sweet-8').onclick = function(){
                swal("خوب به نظر می رسه!", "شما این دکمه را کلیک کردید!", "success");
        },  document.querySelector('.sweet-9').onclick = function(){
                swal("خوب به نظر می رسه!", "شما این دکمه را کلیک کردید!", "info");
        },  document.querySelector('.sweet-10').onclick = function(){
                swal("آیا از انجام این کار مطمئن هستید؟", {
                    buttons: ["اوه نه!", "اوه بله!"],
                });
        },  document.querySelector('.sweet-11').onclick = function(){
                swal("آیا از انجام این کار مطمئن هستید؟", {
                    buttons: ["اوه نه!", "اوه بله!"],
                });
        },  document.querySelector('.sweet-12').onclick = function(){
                swal("آیا شما از انجام این کار مطمئن هستید؟", {
                    buttons: {
                        cancel: "خارج شوید",
                        catch: {
                            text: "بله، انجام شود!",
                            value: "catch",
                        },
                        دریافت: true,
                    },
                })
                .then((value) => {
                    switch (value) {
                        case "دریافت":
                        swal("شما 500 امتیاز به دست آوردید");
                        break;
                        case "catch":
                        swal("خوبه! این کار انجام شد!", "موفق");
                        break;
                        default:
                        swal("شما خارج شدید!");
                    }
                });
        },  document.querySelector('.sweet-13').onclick = function(){
                swal("اینجا چیزی بنویسید:", {
                    content: "input",
                })
                .then((value) => {
                    swal(`متنی که شما نوشتید : ${value}`);
                });
        };
    }
};
(function($) {
    SweetAlert_custom.init()
})(jQuery);