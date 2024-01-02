
//DateRange Picker
(function($) {
    "use strict";
    $(function() {
        $('input[name="daterange"]').daterangepicker();
    });
//Date and Time
    $(function() {
        $('input[name="daterange2"]').daterangepicker({
            timePicker: true,
            timePickerIncrement: 30,
            locale: {
                format: 'MM/DD/YYYY h:mm A'
            }
        });
    });
// Single Date Picker
    $(function() {
        $('input[name="birthdate"]').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true
            },
            function(start, end, label) {
                var years = moment().diff(start, 'years');
                alert("شما در " + years + " سال قبل هستید.");
            });
    });


//Predefined Ranges
    $(function() {

        var start = moment().subtract(29, 'days');
        var end = moment();

        function cb(start, end) {
            $('#reportrange span').html(start.format('YYYY MMMM D') + ' - ' + end.format('YYYY MMMM D'));
        }

        $('#reportrange').daterangepicker({
            startDate: start,
            endDate: end,
            ranges: {
                'امروز': [moment(), moment()],
                'دیروز': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                '7 روز گذشته': [moment().subtract(6, 'days'), moment()],
                '30 روز گذشته': [moment().subtract(29, 'days'), moment()],
                'این ماه': [moment().startOf('month'), moment().endOf('month')],
                'ماه قبل': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            }
        }, cb);

        cb(start, end);

    });
//Input Initially Empty
    $(function() {

        $('input[name="datefilter"]').daterangepicker({
            autoUpdateInput: false,
            locale: {
                cancelLabel: 'Clear'
            }
        });

        $('input[name="datefilter"]').on('apply.daterangepicker', function(ev, picker) {
            $(this).val(picker.startDate.format('YYYY/DD/MM') + ' - ' + picker.endDate.format('YYYY/DD/MM'));
        });

        $('input[name="datefilter"]').on('cancel.daterangepicker', function(ev, picker) {
            $(this).val('');
        });

    });

})(jQuery);