///////////////////// myBarGraph /////////////////////

var ctx = document.getElementById('myBarGraph');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['قرمز', 'آبی', 'زرد', 'سبز', 'بنفش', 'نارنجی'],
        datasets: [{
            label: 'کارمند',
            backgroundColor: zetaAdminConfig.primary,
            data: [10, 40, 5, 38, 27, 12, 29, 17, 40],
        }, {
            label: 'مهندس',
            backgroundColor: zetaAdminConfig.secondary,
            data: [-15, -20, -5, -40, -24, -12, 25, -15, -23],
        }, {
            label: 'حراست',
            backgroundColor: zetaAdminConfig.success,
            data: [16, 25, 5, 31, 30, 12, 19, 19, 27],
        }, {
            label: 'سیاستمدار',
            backgroundColor: zetaAdminConfig.info,
            data: [-10, -15, -5, -33, -26, -12, -26, -12, -34],
        }]
    },
    options: {
        scales: {

            x: {
            },

            y: {
                beginAtZero: true,
            }
        },
        tooltips: {
            rtl: true
        },legend: {
            rtl: true
        }
    }
});


///////////////////// myGraph /////////////////////

var ctx = document.getElementById('myGraph');
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['قرمز', 'آبی', 'زرد', 'سبز', 'بنفش', 'نارنجی'],
        datasets: [{
            label: 'کارمند',
            backgroundColor: zetaAdminConfig.primary,
            data: [20,  -10, 5, -38, 27, -12, 29, -17, 40],
          
            borderColor: zetaAdminConfig.primary,
            tension: 0.5
        }, {
            label: 'حراست',
            backgroundColor: zetaAdminConfig.secondary,
            data: [16, 25, -20, 31, 30, 12, 19, 19, 27],
            borderColor: zetaAdminConfig.secondary,
            tension: 0.5

        },
        {
            label: 'سیاستمدار',
            backgroundColor: zetaAdminConfig.info,
            data: [26, 35, 15, 21, 15, 22, 19, 10, 27],
            borderColor: zetaAdminConfig.info,
        

        },

        ]
    },
    options: {
        tooltips: {
            rtl: true
        },legend: {
            rtl: true
        }
    }
});



///////////////////// myRadarGraph /////////////////////


var ctx = document.getElementById('myRadarGraph');

var myChart = new Chart(ctx, {
    type: 'radar',
    data: {
        labels: ['خوردن','نوشیدن','خوابیدن','طراحی','کد نویسی','دوچرخه سوارب','دوین'],
        datasets: [{
            label: 'اولین داده من',
            data: [65, 59, 70, 79, 56, 55, 40],
            fill: true,
            backgroundColor: 'rgba(99, 98, 231, 0.2)',
            borderColor: zetaAdminConfig.primary,
            pointBackgroundColor: zetaAdminConfig.primary,
            pointBorderColor: '#fff',
            pointHoverBackgroundColor: '#fff',
            pointHoverBorderColor: zetaAdminConfig.primary
          }, {
            label: 'دومین داده من',
            data: [28, 48, 40, 19, 76, 27, 80],
            fill: true,
            backgroundColor: 'rgba(255, 197, 0, 0.2)',
            borderColor: zetaAdminConfig.secondary,
            pointBackgroundColor:zetaAdminConfig.secondary,
            pointBorderColor: '#fff',
            pointHoverBackgroundColor: '#fff',
            pointHoverBorderColor: zetaAdminConfig.secondary
          }]    
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        elements: {
            line: {
                borderWidth: 2
            }
        },
        tooltips: {
            rtl: true
        },legend: {
            rtl: true
        }
    }
});


///////////////////// mypolarareaChart /////////////////////

var ctx = document.getElementById('mypolarareaChart');
var myChart = new Chart(ctx, {
    type: 'polarArea',
    data: {
        labels: ['قرمز', 'آبی', 'زرد', 'سبز', 'بنفش'],
        datasets: [{
            label: 'اولین داده من',
            data: [11, 16, 7, 3, 14],
            backgroundColor: [
                zetaAdminConfig.primary,
              zetaAdminConfig.secondary,
              zetaAdminConfig.success,
              zetaAdminConfig.light_1,
              zetaAdminConfig.warning   
            ]
          }]
    
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        tooltips: {
            rtl: true
        },legend: {
            rtl: true
        }
    }
});

///////////////////// myDoughnutGraph /////////////////////

	
// var ctx = document.getElementById('myDoughnutGraph');
// var myChart = new Chart(ctx, {
// 		type: 'doughnut',
// 		data: {
// 			labels: ['قرمز', 'آبی', 'زرد', 'سبز'],
// 			datasets: [{
// 				data: [300, 50, 100, 150,250],
// 				backgroundColor: ["#62C1C1","#92C348", "#EC6362", "#B4B4B5", "#BFE5E5" ],
// 				hoverBackgroundColor: [ "#62C1C1", "#92C348", "#EC6362", "#B4B4B5", "#BFE5E5" ],
// 				borderWidth: 0,
// 				borderColor: ["#62C1C1","#92C348", "#EC6362", "#B4B4B5","#BFE5E5" ],
// 				hoverBorderWidth: 2,
// 			}]
// 		},
// 		options: {
// 			responsive: true,
// 			legend: {
// 				position: 'bottom',
// 				reverse: false,
// 				labels: {
// 					padding: 25,
// 					fontSize: 12,
// 					fontColor: 'rgb(0, 0, 0)'
// 				}
// 			},
// 			tooltips: {
// 				enabled: true,
// 			},
// 			cutoutPercentage: 70,
// 			rotation: -0.5 * Math.PI,
// 			circumference: 2 * Math.PI,
// 			title: {
// 				display: true,
// 				text: 'Chart.js Doughnut Chart'
// 			},
// 			animation: {
// 				animateScale: true,
// 				animateRotate: true
// 			},
		
// 		}
//     });

var ctx = document.getElementById('myDoughnutGraph');
var myChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: [
            'قرمز','آبی','زرد','سبز', 'بنفش'],
        datasets: [{
            label: 'اولین داده من',
            data: [300, 50, 100, 250,150],
            backgroundColor: [
                zetaAdminConfig.primary,
              zetaAdminConfig.danger,
              zetaAdminConfig.success,
              zetaAdminConfig.warning,
              zetaAdminConfig.secondary   
            ]
          }]
    
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        pluginS:{
            legend: {
                position: 'bottom'
            }
        },
        tooltips: {
            rtl: true
        },legend: {
            rtl: true
        }
    }
});


///////////////////// mypolarareaChart /////////////////////

var ctx = document.getElementById('mymixchart');
var mixedChart  = new Chart(ctx, {
    type: 'bar',
    data: {
        datasets: [{
            type: 'bar',
            label: 'مجموعه داده نمودار ستونی',
            data: [10, 40, 30, 66, 20, 46, 80, 40, 70],
            backgroundColor: [
                zetaAdminConfig.primary,
              zetaAdminConfig.secondary,
              zetaAdminConfig.info,
              zetaAdminConfig.warning,
              zetaAdminConfig.secondary,
              zetaAdminConfig.success,
              zetaAdminConfig.primary,
              zetaAdminConfig.info,
              zetaAdminConfig.secondary   
            ]
        }, {
            type: 'line',
            label: 'مجموعه داده نمودار خطی',
            data: [30, 50, 60, 80, 70, 50, 90, 57,91],
            borderColor: zetaAdminConfig.primary,
            pointBackgroundColor: [zetaAdminConfig.primary],
            pointBorderColor: '#fff',
            pointHoverBackgroundColor: '#fff',
            pointHoverBorderColor: zetaAdminConfig.primary
        }],
        labels: ['دی', 'بهمن', 'اسفند', 'فروردین', 'اردیبهشت' , 'خرداد', 'تیر' , 'مرداد', 'شهریور']
    
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        tooltips: {
            rtl: true
        },legend: {
            rtl: true
        }
    }
});