
function createChart(map, amountApartments, amountPrivateRooms, amountSharedRooms) {
    if (map.areTilesLoaded()) {
        var roomTypeData = {
            labels: ["Entire home/apt", "Private room", "Shared room"],
            datasets: [{
                data: [amountApartments.length, amountPrivateRooms.length, amountSharedRooms.length],
                backgroundColor: ['#ec5242', '#3fb211', '#00bff3']
            }]
        }
        var availableData = {
            labels: ["number of days available in year"],
            datasets: [{
                data: [],
                backgroundColor: ['#ec5242']
            }]
        }
        new Chart(document.getElementById('myChart').getContext('2d'), {
            type: 'horizontalBar',
            data: roomTypeData,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
            }
        });
        new Chart(document.getElementById('availableChart').getContext('2d'), {
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
        var roomTypeData = {
            labels: ["HIGH", "LOW"],
            datasets: [{
                data: [features.filter(feature => feature.properties.availabilityStatus == "HIGH").length, features.filter(feature => feature.properties.availabilityStatus == "LOW").length],
                backgroundColor: ['#B4B4B4', '#CCCCCC']
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
        new Chart(document.getElementById('listingsPerHostChart').getContext('2d'), {
            type: 'bar',
            data: listingsDataSet,
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
            }
        });
        new Chart(document.getElementById('availablePieChart').getContext('2d'), {
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