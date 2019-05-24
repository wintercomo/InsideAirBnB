
function createChart(map, amountApartments, amountPrivateRooms, amountSharedRooms) {
    

    if (map.areTilesLoaded()) {
        var ctx = document.getElementById('myChart').getContext('2d');
        var data = {
            labels: ["Entire home/apt", "Private room", "Shared room"],
            datasets: [{
                data: [amountApartments.length, amountPrivateRooms.length, amountSharedRooms.length],
                backgroundColor: ['#ec5242', '#3fb211', '#00bff3']
            }]
        }
        var myChart = new Chart(ctx, {
            type: 'horizontalBar',
            data: data,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            // Include a dollar sign in the ticks
                            callback: function (value, index, values) {
                                return '$' + value;
                            }
                        }

                    }]
                }
            }
        });
    }
}