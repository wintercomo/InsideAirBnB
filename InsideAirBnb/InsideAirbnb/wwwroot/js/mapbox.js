document.addEventListener('DOMContentLoaded', function () {
    mapboxgl.accessToken = 'pk.eyJ1Ijoid2ludGVyY29tbyIsImEiOiJjanZncnFjdTIwYTJwM3ltajlmODQ0bWlpIn0.LbLEHOHfmrzlq6D5kLd1yQ';
    var map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/wintercomo/cjvz2001z0wl51cox3kaalny4',
        center: [4.893, 52.373],
        zoom: 12,
        maxZoom: 15,
    });
    let popup = new mapboxgl.Popup({ closeOnClick: false });
    let clicked = false;
    popup.on("close", () => {
        clicked = false;
    });
    const generatePopUp = (e) => {
        let listingAmmout = e.features[0].properties.calculated_host_listings_count;
        let listing_ammount = "";
        if (listingAmmout - 1 <= 0) {
            listing_ammount = "No listings known"
        } else {
            listing_ammount = e.features[0].properties.calculated_host_listings_count + " other listings known";
        }
        popup.setLngLat(e.lngLat)
            .setHTML(`<div class='pup_up'>
                <a href='http://www.airbnb.com/users/show/${e.features[0].properties.host_id}'><b>${e.features[0].properties.host_name}</b></a> <br>
                <sub>(${listing_ammount}
                <hr class='separator'><a href='http://www.airbnb.com/rooms/${e.features[0].properties.id}'> <b id='listing_id'>${e.features[0].properties.id}</b>
                <p id='listingNameContainer' >${e.features[0].properties.name}</p></a>
                <b id='neigbourhood'>${e.features[0].properties.neighbourhood}</b> 
                <p id='room_type'> ${e.features[0].properties.room_type}</p> <hr class='separator'> 
                <b id='income'>&euro;INSERT EXPECTED INCOME</b>
                <p id='location_price'>&euro;${e.features[0].properties.price}/night <br></p>
                <p id='minimun_nights'>${e.features[0].properties.minimum_nights} nights minimum</p>
                <p id='reviews_per_month'>${e.features[0].properties.reviews_per_month} reviews per month</p>
                <p id='number_of_reviews'>${e.features[0].properties.number_of_reviews}reviews</p>
                <p id='last_review'> last review on ${e.features[0].properties.last_review}<br></p>
                <p id='availability'>${e.features[0].properties.availabilityStatus} availability</p> 
                <sub id='availability_365'>${e.features[0].properties.availability_365}days/year(PERCENTAGE%)</sub>  <br>
                <sub>click listing on map to 'pin' details</sub>
                </div >`)
            .addTo(map);
    };
    // Event listeners
    document.getElementById("multi").addEventListener('change', function () {
        document.getElementById("maxPriceTag").innerHTML = document.getElementById("multi").value;
        setMapFilter(map);
    });
    document.getElementById("numberOfReviewsSlider").addEventListener('change', function () {
        document.getElementById("minReviewTag").innerHTML = document.getElementById("numberOfReviewsSlider").value;
        setMapFilter(map);
    });
    document.querySelector("input[name=filterApertmentsOnly]").addEventListener('change', function () {
        setMapFilter(map);
    });
    document.getElementById("onlyRecentCheckbox").addEventListener('change', function () {
        setMapFilter(map);
    });
    document.querySelector("input[name=onlyAvailabiltyCheckbox]").addEventListener('change', function () {
        setMapFilter(map);
    });
    document.getElementById("map_filter").addEventListener("change", () => {
        setMapFilter(map);
    });
    document.getElementById("onlyMultiListingsPerHostCheckbox").addEventListener("change", () => {
        setMapFilter(map);
    });
    map.on('load', function () {
        map.addLayer({
            "id": "locations_layer",
            "type": "circle",
            "source": {
                "type": "geojson",
                "data": '/sum',
            },
            'paint': {
                'circle-radius': {
                    'base': 1.75,
                    'stops': [[12, 2], [22, 180]]
                },
                // color circles by ethnicity, using a match expression
                // https://docs.mapbox.com/mapbox-gl-js/style-spec/#expressions-match
                'circle-color': [
                    'match',
                    ['get', 'room_type'],
                    'Entire home/apt', '#ec5242',
                    'Private room', '#3fb211',
                    'Shared room', '#00bff3',
            /* other */ '#ccc'
                ]
            }
        });
        map.addControl(new mapboxgl.NavigationControl());
        map.on('click', 'locations_layer', function (e) {
            clicked = !clicked;
            generatePopUp(e);
        });
        map.on('mouseenter', 'locations_layer', function (e) {
            map.getCanvas().style.cursor = 'pointer';
            if (!clicked) {
                generatePopUp(e);
            }
        });

        // Change it back to a pointer when it leaves.
        map.on('mouseleave', 'locations_layer', function (e) {
            map.getCanvas().style.cursor = '';
            if (!clicked) {
                popup.remove();
            }
        });
        // When markers are made create the chart
        map.on('sourcedata', () => {
            var features = map.queryRenderedFeatures({ layers: ['locations_layer'] })
            var amountApartments = features.filter(feature => feature.properties.room_type == "Entire home/apt")
            var amountPrivateRooms = features.filter(feature => feature.properties.room_type == "Private room")
            var amountSharedRooms = features.filter(feature => feature.properties.room_type == "Shared room")
            //amount makers availability
            UpdateUI(features, amountApartments, amountPrivateRooms, amountSharedRooms);
            createChart(map, amountApartments, amountPrivateRooms, amountSharedRooms);
            createAvailableCharts(map, features);
        });
    });
    
}, false);

function UpdateUI(features, amountApartments, amountPrivateRooms, amountSharedRooms) {
    var amountHighAvailable = features.filter(feature => feature.properties.availabilityStatus == "HIGH");
    var amountLowAvailable = features.filter(feature => feature.properties.availabilityStatus == "LOW");
    var amountMultiListings = features.filter(feature => feature.properties.calculated_host_listings_count > 1);
    //Get average
    var availabilityAverage = CalcAverage(features);
    var apartmentsAverage = CalcAveragePrice(amountApartments);
    var nightsPerYearAverage = CalcAverageNightsPYear(features);
    var reviewListingsPerMonth = CalcAverageReviewsPerMonth(features);
    var totalReviews = getTotalReviews(features);
    //get percentage
    var apartmentsPercentage = ((amountApartments.length / features.length) * 100).toFixed(1);
    var privatePercentage = ((amountPrivateRooms.length / features.length) * 100).toFixed(1);
    var sharedPercentage = ((amountSharedRooms.length / features.length) * 100).toFixed(1);
    var highAvailablePercentage = ((amountHighAvailable.length / features.length) * 100).toFixed(1);
    var lowAvailablePercentage = ((amountLowAvailable.length / features.length) * 100).toFixed(1);
    var availabilitiAveragePercentage = ((availabilityAverage / 365) * 100).toFixed(1);
    var nightsPerYearPercentage = ((nightsPerYearAverage / 365) * 100).toFixed(1);
    var multiListingPercentage = ((amountMultiListings.length / features.length) * 100).toFixed(1);
    //Update UI
    document.getElementById("number_listings_loaded").innerText = features.length;
    document.getElementById("priceTagApertments").innerText = apartmentsAverage.toFixed(1);
    document.getElementById("entireHomeApartmentsPercentage").innerText = apartmentsPercentage + "%";
    document.getElementById("EntireHomeCount").innerText = amountApartments.length + " (" + apartmentsPercentage + "%)";
    document.getElementById("sharedRoomsCount").innerText = amountSharedRooms.length + " (" + sharedPercentage + "%)";
    document.getElementById("privateRoomCount").innerText = amountPrivateRooms.length + " (" + privatePercentage + "%)";
    //activity tab
    document.getElementById("nightsPerYearAverage").innerText = nightsPerYearAverage.toFixed(1) + ` (${nightsPerYearPercentage}%)`;
    document.getElementById("reviewListingPerMonth").innerText = reviewListingsPerMonth.toFixed(1);
    document.getElementById("totalReviewsPerMonth").innerText = totalReviews;
    //available tab
    document.getElementById("highAvailablityPercentage").innerText = highAvailablePercentage + "%";
    document.getElementById("amountHighAvailability").innerText = amountHighAvailable.length + " (" + highAvailablePercentage + "%)";
    document.getElementById("amountLowAvailability").innerText = amountLowAvailable.length + " (" + lowAvailablePercentage + "%)";
    document.getElementById("availabilityAverage").innerText = availabilityAverage.toFixed(1) + " (" + availabilitiAveragePercentage + "%)";
    //listings tab
    document.getElementById("multiListingPercentage").innerText = multiListingPercentage + "%";
    document.getElementById("singleListingPercentage").innerText = (features.length - amountMultiListings.length) + " (" + (100 - multiListingPercentage) + "%)";
    document.getElementById("amountMultiListings").innerText = amountMultiListings.length + " (" + multiListingPercentage + "%)";
}
function getTotalReviews(features) {
    var sum = 0;
    for (var i = 0; i < features.length; i++) {
        sum += isNaN(features[i].properties.reviews_per_month) ? 0 : features[i].properties.reviews_per_month;
    }
    return sum;

}
function CalcAverage(features) {
    var sum = 0;
    for (var i = 0; i < features.length; i++) {
        sum += features[i].properties.availability_365;
    }
    var availabilityAverage = sum / features.length;
    return availabilityAverage;
}
function CalcAveragePrice(features) {
    var sum = 0;
    for (var i = 0; i < features.length; i++) {
        sum += features[i].properties.price;
    }
    var average = sum / features.length;
    return average;
}
function CalcAverageNightsPYear(features) {
    var sum = 0;
    for (var i = 0; i < features.length; i++) {
        sum += (365 - features[i].properties.price);
    }
    var average = sum / features.length;
    return average;
}
function CalcAverageReviewsPerMonth(features) {
    var sum = 0;
    for (var i = 0; i < features.length; i++) {
        sum += isNaN(features[i].properties.reviews_per_month) ? 0 : features[i].properties.reviews_per_month;
    }
    var average = sum / features.length;
    return average;
}