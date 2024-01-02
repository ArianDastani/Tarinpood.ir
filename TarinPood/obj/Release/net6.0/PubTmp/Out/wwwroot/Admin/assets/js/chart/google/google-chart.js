google.charts.load('current', {packages: ['corechart', 'bar']});
google.charts.load('current', {'packages':['line']});
google.charts.load('current', {'packages':['corechart']});
google.charts.setOnLoadCallback(drawBasic);
function drawBasic() {
  if ($("#column-chart1").length > 0) {
      var a = google.visualization.arrayToDataTable([
        ["", "فروش     .", "مخارج    .", "سود"],
        ["1398", 1e3, 400, 250],
        ["1399", 1170, 460, 300],
        ["1400", 660, 1120, 400],
        ["1401", 1030, 540, 450]
      ]),
      b = {
        chart: {
          title: "عملکرد شرکت",
          subtitle: "فروش، هزینه ها و سود: 1398-1401"
        },
        bars: "vertical",
        vAxis: {
          format: "decimal"
        },
        height: 400,
        width:'100%',
          colors: [zetaAdminConfig.primary, zetaAdminConfig.secondary , "#51bb25"]


      },
    c = new google.charts.Bar(document.getElementById("column-chart1"));
    c.draw(a, google.charts.Bar.convertOptions(b))
  }
  if ($("#column-chart2").length > 0) {
      var a = google.visualization.arrayToDataTable([
        ["سال", "فروش     .", "مخارج      .", "سود"],
        ["1398", 1e3, 400, 250],
        ["1399", 1170, 460, 300],
        ["1400", 660, 1120, 400],
        ["1401", 1030, 540, 450]
      ]),
      b = {
        chart: {
          title: "عملکرد شرکت",
          subtitle: "فروش، هزینه ها و سود: 1398-1401"
        },
        bars: "horizontal",
        vAxis: {
          format: "decimal"
        },
        height: 400,
        width:'100%',
        colors: [zetaAdminConfig.primary, zetaAdminConfig.secondary , "#51bb25"]
      },
      c = new google.charts.Bar(document.getElementById("column-chart2"));
      c.draw(a, google.charts.Bar.convertOptions(b))
  }
  if ($("#pie-chart1").length > 0) {
      var data = google.visualization.arrayToDataTable([
        ['وظیفه', 'ساعت در روز'],
        ['کار',     5],
        ['خوردن',      10],
        ['رفت و آمد',  15],
        ['تماشای تلویزیون', 20],
        ['خوابیدن',    25]
      ]);
      var options = {
        title: 'فعالیت های روزانه من',
        width:'100%',
        height: 300,
       colors: ["#f8d62b", "#51bb25" , "#a927f9"  , zetaAdminConfig.secondary , zetaAdminConfig.primary ]
      };
      var chart = new google.visualization.PieChart(document.getElementById('pie-chart1'));
      chart.draw(data, options);
  }
  if ($("#pie-chart2").length > 0) {
      var data = google.visualization.arrayToDataTable([
        ['وظیفه', 'ساعت در روز'],
        ['کار',     5],
        ['خوردن',      10],
        ['رفت و آمد',  15],
        ['تماشای تلویزیون', 20],
        ['خوابیدن',    25]
      ]);
      var options = {
        title: 'فعالیت های روزانه من',
        is3D: true,
        width:'100%',
        height: 300,
        colors: ["#f8d62b", "#a927f9" , "#51bb25", zetaAdminConfig.secondary , zetaAdminConfig.primary ]
      };
      var chart = new google.visualization.PieChart(document.getElementById('pie-chart2'));
      chart.draw(data, options);
  }
  if ($("#pie-chart3").length > 0) {
      var data = google.visualization.arrayToDataTable([
        ['وظیفه', 'ساعت در روز'],
        ['کار',     2],
        ['خوردن',      2],
        ['رفت و آمد',  11],
        ['تماشای تلویزیون', 2],
        ['خوابیدن',    7]
      ]);
      var options = {
        title: 'فعالیت های روزانه من',
        pieHole: 0.4,
        width:'100%',
        height: 300,
        colors: ["#f8d62b", "#a927f9", "#51bb25", zetaAdminConfig.secondary , zetaAdminConfig.primary]
      };
      var chart = new google.visualization.PieChart(document.getElementById('pie-chart3'));
      chart.draw(data, options);
  }
  if ($("#pie-chart4").length > 0) {
      var data = google.visualization.arrayToDataTable([
        ['زبان', 'صحبت کنندگان (در میلیون)'],
        ['آسامی', 13],
        ['بنگالی', 83],
        ['بودو', 1.4],
        ['دوگری', 2.3],
        ['گجراتی', 46],
        ['هندی', 300],
        ['کانادایی', 38],
        ['کشمیری', 5.5],
        ['کونکانی', 5],
        ['مایتیلی', 20],
        ['مالایایی', 33],
        ['مانیپوری', 1.5],
        ['مراتی', 72],
        ['نپالی', 2.9],
        ['اوریا', 33],
        ['پنجابی', 29],
        ['سانسکریت', 0.01],
        ['سانتالی', 6.5],
        ['سندی', 2.5],
        ['تامیل', 61],
        ['تلوگو', 74],
        ['اردو', 52]
      ]);
      var options = {
        title: 'صفتفاده از زبان هندی',
        legend: 'none',
        width:'100%',
        height: 400,
        pieSliceText: 'label',
        slices: {  4: {offset: 0.2},
          12: {offset: 0.3},
          14: {offset: 0.4},
          15: {offset: 0.5},
        },
          colors: ["#dc3545", zetaAdminConfig.primary , zetaAdminConfig.secondary , "#51bb25", "#a927f9", "#f8d62b","#dc3545", zetaAdminConfig.primary , "#f8d62b", "#51bb25", zetaAdminConfig.primary , zetaAdminConfig.secondary ,"#51bb25", zetaAdminConfig.primary , "#a927f9", "#f8d62b", zetaAdminConfig.primary , zetaAdminConfig.primary, "#a927f9", zetaAdminConfig.secondary , zetaAdminConfig.primary , "#51bb25"]
        };
        var chart = new google.visualization.PieChart(document.getElementById('pie-chart4'));
        chart.draw(data, options);
  }
  if ($("#line-chart").length > 0) {
      var data = new google.visualization.DataTable();
      data.addColumn('number', 'ماه');
      data.addColumn('number', 'نگهبانان کهکشان');
      data.addColumn('number', 'انتقام جویان');
      data.addColumn('number', 'ترانسفورماتورها: عصر انقراض');
      data.addRows([
        [1,  37.8, 80.8, 41.8],
        [2,  30.9, 10.5, 32.4],
        [3,  40.4,   57, 25.7],
        [4,  11.7, 18.8, 10.5],
        [5,  20, 17.6, 10.4],
        [6,   8.8, 13.6,  7.7],
        [7,   7.6, 12.3,  9.6],
        [8,  12.3, 29.2, 10.6],
        [9,  16.9, 42.9, 14.8],
        [10, 12.8, 30.9, 11.6],
        [11,  5.3,  7.9,  4.7],
        [12,  6.6,  8.4,  5.2],
      ]);
      var options = {
        chart: {
          title: 'درآمد باکس آفیس در دو هفته اول افتتاحیه',
          subtitle: 'به میلیون دلار'
        },
        colors: [zetaAdminConfig.primary , zetaAdminConfig.secondary , "#51bb25"],
        height: 500,
        width:'100%',
      };
      var chart = new google.charts.Line(document.getElementById('line-chart'));
      chart.draw(data, google.charts.Line.convertOptions(options));
  }
  if ($("#combo-chart").length > 0) {
      var data = google.visualization.arrayToDataTable([
        ['ماه', 'بولیوی', 'اکوادور', 'ماداگاسکار', 'پاپوآ', 'رواندا', 'میانگین'],
        ['1397/05',  165,      938,         522,             998,           450,      614.6],
        ['1398/06',  135,      1120,        599,             1268,          288,      682],
        ['1399/07',  157,      1167,        587,             807,           397,      623],
        ['1400/08',  139,      1110,        615,             968,           215,      609.4],
        ['1401/09',  136,      691,         629,             1026,          366,      569.6]
      ]);
      var options = {
        title : 'تولید ماهانه قهوه به تفکیک کشور',
        vAxis: {title: 'فنجان ها'},
        hAxis: {title: 'ماه'},
        seriesType: 'bars',
        series: {5: {type: 'line'}},
        height: 500,
        width:'100%',
        colors: [zetaAdminConfig.primary, zetaAdminConfig.secondary , "#51bb25", "#a927f9", "#f8d62b"]
    };
    var chart = new google.visualization.ComboChart(document.getElementById('combo-chart'));
    chart.draw(data, options);
  }
  if ($("#area-chart1").length > 0) {
      var data = google.visualization.arrayToDataTable([
        ['سال', 'فروش', 'مخارج'],
        ['1398',  1000,      400],
        ['1399',  1170,      460],
        ['1400',  660,       1120],
        ['1401',  1030,      540]
      ]);
      var options = {
        title: 'عملکرد شرکت',
        hAxis: {title: 'سال',  titleTextStyle: {color: '#333'}},
        vAxis: {minValue: 0},
        width:'100%',
        height: 400,
        colors: [ zetaAdminConfig.primary , zetaAdminConfig.secondary ]
      };
      var chart = new google.visualization.AreaChart(document.getElementById('area-chart1'));
      chart.draw(data, options);
  }
  if ($("#area-chart2").length > 0) {
    var data = google.visualization.arrayToDataTable([
      ['سال', 'ماشین', 'کامیون' , 'هواپیما' , 'تراکتور'],
      ['1398',  100, 400, 2000, 400],
      ['1399',  500, 700, 530, 800],
      ['1400',  2000, 1000, 620, 120],
      ['1401',  120, 201, 2501, 540]
    ]);
    var options = {
      title: 'عملکرد شرکت',
      hAxis: {title: 'سال',  titleTextStyle: {color: '#333'}},
      vAxis: {minValue: 0},
      width:'100%',
      height: 400,
      colors: [zetaAdminConfig.primary , zetaAdminConfig.secondary , "#51bb25", "#f8d62b"]
    };
    var chart = new google.visualization.AreaChart(document.getElementById('area-chart2'));
    chart.draw(data, options);
  }
    if ($("#bar-chart2").length > 0) {
        var a = google.visualization.arrayToDataTable([
                ["عنصر", "تراکم", {
                    role: "style"
                }],
                ["مس", 10, "#a927f9"],
                ["نقره", 12, "#f8d62b"],
                ["طلا", 14, "#f73164"],
                ["پلاتین", 16, "color: #7366ff"]
            ]),
            d = new google.visualization.DataView(a);
        d.setColumns([0, 1, {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation"
        }, 2]);
        var b = {
                title: "چگالی فلزات گرانبها، بر حسب گرم بر سانتی متر^3",
                width:'100%',
                height: 400,
                bar: {
                    groupWidth: "95%"
                },
                legend: {
                    position: "none"
                }
            },
            c = new google.visualization.BarChart(document.getElementById("bar-chart2"));
        c.draw(d, b)
    }
}
// Gantt chart
google.charts.load('current', {'packages':['gantt']});
google.charts.setOnLoadCallback(drawChart);

function daysToMilliseconds(days) {
    return days * 24 * 60 * 60 * 1000;
}

function drawChart() {

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'شناسه وظیفه');
    data.addColumn('string', 'نام وظیفه');
    data.addColumn('string', 'منبع');
    data.addColumn('date', 'تاریخ شروع');
    data.addColumn('date', 'تاریخ پایان');
    data.addColumn('number', 'مدت زمان');
    data.addColumn('number', 'درصد تکمیل');
    data.addColumn('string', 'وابستگی ها');

    data.addRows([
        ['Research', 'منابع را بیابید', null,
            new Date(2015, 0, 1), new Date(2015, 0, 5), null,  100,  null],
        ['Write', 'کاغذ بنویس', 'نوشتن',
            null, new Date(2015, 0, 9), daysToMilliseconds(3), 25, 'Research,Outline'],
        ['Cite', 'کتابشناسی ایجاد کنید', 'نوشتن',
            null, new Date(2015, 0, 7), daysToMilliseconds(1), 20, 'Research'],
        ['Complete', 'دست در کاغذ', 'تکمیل شده',
            null, new Date(2015, 0, 10), daysToMilliseconds(1), 0, 'Cite,Write'],
        ['Outline', 'کاغذ طرح کلی', 'نوشتن',
            null, new Date(2015, 0, 6), daysToMilliseconds(1), 100, 'Research']
    ]);

    var options = {
        height: 275,
        gantt: {
            criticalPathEnabled: false, // Critical path arrows will be the same as other arrows.
            arrow: {
                angle: 100,
                width: 5,
                color: '#51bb25',
                radius: 0
            },

                palette: [
                    {
                        "color": zetaAdminConfig.primary,
                        "dark": zetaAdminConfig.secondary ,
                        "light": "#047afb"
                    }
                ]

        }
    };
    var chart = new google.visualization.Gantt(document.getElementById('gantt_chart'));

    chart.draw(data, options);
}
// word tree
google.charts.load('current1', {packages:['wordtree']});
google.charts.setOnLoadCallback(drawChart1);

function drawChart1() {
    var data = google.visualization.arrayToDataTable(
        [ ['Phrases'],
            ['گربه از بهتر سگ'],
            ['گربه غذا کیبل'],
            ['گربه از بهتر همستر'],
            ['گربه صفت عالی'],
            ['گربه صفت جاندار'],
            ['گربه غذا موش'],
            ['میو گربه'],
            ['گربه صفت زیبا'],
            ['گربه غذا موش'],
            ['گربه غذا کیبل'],
            ['گربه خواند می آواز'],
            [' گربه کند می  میو'],
            ['گربه صفت خانواده'],
            ['گربه غذا موش'],
            ['گربه صفت بازیگوش'],
            ['گربه صفت عجیب'],
            ['گربه غذا موش']
        ]
    );

    var options = {
        wordtree: {
            format: 'implicit',
            word: 'گربه'
        }

    };
    var chart = new google.visualization.WordTree(document.getElementById('wordtree_basic'));
    chart.draw(data, options);
}