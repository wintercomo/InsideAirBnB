
function createChart(map, amountApartments, amountPrivateRooms, amountSharedRooms) {
    

    if (map.areTilesLoaded()) {
        var ctx = document.getElementById('myChart').getContext('2d');
        var availableChart = document.getElementById('availableChart').getContext('2d');
        var availablePieChart = document.getElementById('availablePieChart').getContext('2d');
        var roomTypeData = {
            labels: ["Entire home/apt", "Private room", "Shared room"],
            datasets: [{
                data: [amountApartments.length, amountPrivateRooms.length, amountSharedRooms.length],
                backgroundColor: ['#ec5242', '#3fb211', '#00bff3']
            }]
        }
        var availableData = {
            labels: ["number of days availavle in year"],
            datasets: [{
                data: [{
                    x: 1,
                    y:1
                },{
                    x: 2,
                    y:2
                },{
                    x: 3,
                    y:3
                },
                ],
                backgroundColor: ['#ec5242']
            }]
        }
        var myChart = new Chart(ctx, {
            type: 'horizontalBar',
            data: roomTypeData,
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

        new Chart(availableChart, {
            type: 'line',
            data: availableData,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
            }
        });
    }
}

function createAvailableCharts(map, features) {
    if (map.areTilesLoaded()) {
        var amountHighAvailable = features.filter(feature => feature.properties.availabilityStatus == "HIGH");
        var amountLowAvailable = features.filter(feature => feature.properties.availabilityStatus == "LOW");
        var availablePieChart = document.getElementById('availablePieChart').getContext('2d');
        var roomTypeData = {
            labels: ["HIGH", "LOW"],
            datasets: [{
                data: [amountHighAvailable.length, amountLowAvailable.length],
                backgroundColor: ['#ec5242', '#3fb211']
            }]
        }
        
        var myChart = new Chart(availablePieChart, {
            type: 'pie',
            data: roomTypeData,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
            }
        });
    }
}