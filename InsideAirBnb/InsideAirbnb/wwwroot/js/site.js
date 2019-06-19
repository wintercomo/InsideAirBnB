// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});
function setMapFilter(map) {
    console.log("Fetching Data");
    var label = $('#map_filter :selected').parent().attr('label');
    var selectedValue = document.getElementById("map_filter").value;
    var onlyApartments = document.getElementById("apartmentFilterCheckbox").checked;
    var maxPrice = document.getElementById("multi").value;
    var minReviews = document.getElementById("numberOfReviewsSlider").value;
    var onlyHighActive = document.getElementById("onlyAvailabiltyCheckboc").checked;
    var onlyMultiListings = document.getElementById("onlyMultiListingsPerHostCheckbox").checked;
    var onlyRecentBooked = document.getElementById("onlyRecentCheckbox").checked;
    var fetchUrl = `/?${label}=${selectedValue}&ApartmentsOnly=${onlyApartments}&maxPrice=${maxPrice}&minReviews=${minReviews}&onlyHighActive=${onlyHighActive}&onlyMultiListings=${onlyMultiListings}&onlyRecentBooked=${onlyRecentBooked}`
    window.history.pushState("", "", fetchUrl);
    map.removeLayer("locations_layer");
    map.removeSource("locations_layer");
    map.addLayer({
        "id": "locations_layer",
        "type": "circle",
        "source": {
            "type": "geojson",
            "data": `/sum${fetchUrl}`,
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
}
function showTopHosts() {
    if (document.getElementById("topHostList").style.display == "block") {
        document.getElementById("topHostList").style.display = "none"
    } else {
        document.getElementById("topHostList").style.display = "block"
    }
}