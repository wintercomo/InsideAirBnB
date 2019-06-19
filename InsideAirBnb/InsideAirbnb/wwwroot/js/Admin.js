//JS for admin page
console.log("Loaded admin JS");
var availableData = {
    labels: null,
    datasets: [{
        data: [],
        backgroundColor: ['#ec5242']
    }]
}
var data = fetch('/sumReviews')
    .then(function (response) {
        return response.json();
    })
    .then(function (myJson) {
        availableData.labels = myJson.map(a => a.x);
        availableData.datasets[0].data = myJson.map((b, index) =>
        {
            return { x:index, y:b.y }
        })
        createTrendsChart();
    });

function createTrendsChart() {
    new Chart(document.getElementById('trendsGraph').getContext('2d'), {
        type: 'line',
        data: availableData,
        options: {
            title: {
                display: true,
                text: 'Trends'
            },
            maintainAspectRatio: false,
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Ammount of reviews'
                    }
                }],
                xAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Date'
                    }
                }]
            }
        }
    });
};
