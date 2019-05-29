
function createChart(map, amountApartments, amountPrivateRooms, amountSharedRooms) {
    if (map.areTilesLoaded()) {
        var ctx = document.getElementById('myChart').getContext('2d');
        var availableChart = document.getElementById('availableChart').getContext('2d');
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
        new Chart(ctx, {
            type: 'horizontalBar',
            data: roomTypeData,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
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
        var amountMultiListings = features.filter(feature => feature.properties.calculated_host_listings_count > 1);
        var availablePieChart = document.getElementById('availablePieChart').getContext('2d');
        var listingsPerHostChart = document.getElementById('listingsPerHostChart').getContext('2d');
        var roomTypeData = {
            labels: ["HIGH", "LOW"],
            datasets: [{
                data: [amountHighAvailable.length, amountLowAvailable.length],
                backgroundColor: ['#ec5242', '#3fb211']
            }]
        }
        var listingsDataSet = {
            labels: ["1", "2", '3', '4', '5', '6', '7', '8', '10'],
            datasets: [{
                data: [features.filter(feature => feature.properties.calculated_host_listings_count === 1).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 2).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 3).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 4).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 5).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 6).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 7).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 8).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 9).length,
                    features.filter(feature => feature.properties.calculated_host_listings_count === 10).length,
                ],
            }]
        }
        new Chart(listingsPerHostChart, {
            type: 'bar',
            data: listingsDataSet,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
            }
        });
        var myChart = new Chart(availablePieChart, {
            type: 'doughnut',
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