'use strict';
var BootstrapNotifyDemo = function () {
    var demo = function () {
        $('#bootstrap-notify-gen-btn').click(function() {
            var content = {};
            content.message = 'سفارش جدید ثبت شد';
            if ($('#bootstrap-notify-title').prop('checked')) {
                content.title = 'عنوان اعلان';
                content.target = '_blank';
            }
            if ($('#bootstrap-notify-icon').val() != '') {
                content.icon = 'icon ' + $('#bootstrap-notify-icon').val();
            }
            if ($('#bootstrap-notify-url').prop('checked')) {
                content.url = 'http://Example.com';
                content.target = '_blank';
            }
            var notify = $.notify(content, { 
                type: $('#bootstrap-notify-state').val(),
                allow_dismiss: $('#bootstrap-notify-dismiss').prop('checked'),
                newest_on_top: $('#bootstrap-notify-top').prop('checked'),
                mouse_over:  $('#bootstrap-notify-pause').prop('checked'),
                showProgressbar:  $('#bootstrap-notify-progress').prop('checked'),
                spacing: $('#bootstrap-notify-spacing').val(),                    
                timer: $('#bootstrap-notify-timer').val(),
                placement: {
                    from: $('#bootstrap-notify-placement-from').val(), 
                    align: $('#bootstrap-notify-placement-align').val()
                },
                offset: {
                    x: $('#bootstrap-notify-offset-x').val(), 
                    y: $('#bootstrap-notify-offset-y').val()
                },
                delay: $('#bootstrap-notify-delay').val(),
                z_index: $('#bootstrap-notify-z-index').val(),
                animate: {
                    enter: 'animated ' + $('#bootstrap-notify-enter').val(),
                    exit: 'animated ' + $('#bootstrap-notify-exit').val()
                }
            });
            if ($('#bootstrap-notify-progress').prop('checked')) {
                setTimeout(function() {
                    notify.update('message', '<strong>ذخیره</strong> داده صفحه.');
                    notify.update('type', 'primary');
                    notify.update('progress', 20);
                }, 1000);
                setTimeout(function() {
                    notify.update('message', '<strong>ذخیره</strong> داده کاربر.');
                    notify.update('type', 'warning');
                    notify.update('progress', 40);
                }, 2000);
                setTimeout(function() {
                    notify.update('message', '<strong>ذخیره</strong> داده پروفایل.');
                    notify.update('type', 'danger');
                    notify.update('progress', 65);
                }, 3000);
                setTimeout(function() {
                    notify.update('message', '<strong>بررسی</strong> برای خطاها.');
                    notify.update('type', 'success');
                    notify.update('progress', 100);
                }, 4000);
            }
            var notify_content1 = "&lt;script&gt;<br>   $.notify({<br>      title:'ایمیل : نسترن شریفی',<br>      message:'سرمایه گذاری، ذینفعان تامین مالی خرد سلامت سهام بلومبرگ; تغییرات آب و هوایی شهروندان جهانی حل تغییرات اجتماعی مثبت بهداشت، فرصت چالش های غیر قابل حل.'<br>   },<br>   {<br>      type:'" + $('#bootstrap-notify-state').val() +"',<br>      allow_dismiss:"+ $('#bootstrap-notify-dismiss').prop('checked') + ",<br>      newest_on_top:" + $('#bootstrap-notify-top').prop('checked') + " ,<br>      mouse_over:" + $('#bootstrap-notify-pause').prop('checked') + ",<br>      showProgressbar:" + $('#bootstrap-notify-progress').prop('checked') + ",<br>      spacing:" + $('#bootstrap-notify-spacing').val() + ",<br>      timer:" + $('#bootstrap-notify-timer').val() + ",<br>      placement:{<br>        from:'" + $('#bootstrap-notify-placement-from').val() + "',<br>        align:'" + $('#bootstrap-notify-placement-align').val() + "'<br>      },<br>      offset:{<br>        x:" + $('#bootstrap-notify-offset-x').val() + ",<br>        y:" + $('#bootstrap-notify-offset-y').val() + "<br>      },<br>      delay:" + $('#bootstrap-notify-delay').val() +" ,<br>      z_index:" + $('#bootstrap-notify-z-index').val() + ",<br>      animate:{<br>        enter:'animated "+ $('#bootstrap-notify-enter').val()+ "',<br>        exit:'animated " + $('#bootstrap-notify-exit').val()+ "'<br>    }<br>  });<br> &lt;/script&gt;";
            $("#notify-code-show").html(notify_content1);
        });
    }
    return {
        init: function() {
            demo();
        }
    };
}();
(function($) {
    "use strict";
    BootstrapNotifyDemo.init();
    var notify_content1 = "&lt;script&gt;<br>   $.notify({<br>      title:'ایمیل : نسترن شریفی',<br>      message:'سرمایه گذاری، ذینفعان تامین مالی خرد سلامت سهام بلومبرگ; تغییرات آب و هوایی شهروندان جهانی حل تغییرات اجتماعی مثبت بهداشت، فرصت چالش های غیر قابل حل.'<br>   },<br>   {<br>      type:'" + $('#bootstrap-notify-state').val() +"',<br>      allow_dismiss:"+ $('#bootstrap-notify-dismiss').prop('checked') + ",<br>      newest_on_top:" + $('#bootstrap-notify-top').prop('checked') + " ,<br>      mouse_over:" + $('#bootstrap-notify-pause').prop('checked') + ",<br>      showProgressbar:" + $('#bootstrap-notify-progress').prop('checked') + ",<br>      spacing:" + $('#bootstrap-notify-spacing').val() + ",<br>      timer:" + $('#bootstrap-notify-timer').val() + ",<br>      placement:{<br>        from:'" + $('#bootstrap-notify-placement-from').val() + "',<br>        align:'" + $('#bootstrap-notify-placement-align').val() + "'<br>      },<br>      offset:{<br>        x:" + $('#bootstrap-notify-offset-x').val() + ",<br>        y:" + $('#bootstrap-notify-offset-y').val() + "<br>      },<br>      delay:" + $('#bootstrap-notify-delay').val() +" ,<br>      z_index:" + $('#bootstrap-notify-z-index').val() + ",<br>      animate:{<br>        enter:'animated "+ $('#bootstrap-notify-enter').val()+ "',<br>        exit:'animated " + $('#bootstrap-notify-exit').val()+ "'<br>    }<br>  });<br> &lt;/script&gt;";
    $("#notify-code-show").html(notify_content1);
})(jQuery);