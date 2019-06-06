// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});
function setMapFilter(map) {
    var FilterApertmentsCheckbox = document.querySelector("input[name=filterApertmentsOnly]");
    var onlyAvailabiltyCheckbox = document.querySelector("input[name=onlyAvailabiltyCheckbox]");
    var onlyMultiListings = document.querySelector("input[name=onlyMultiListingsPerHostCheckbox]");
    var label = $('#map_filter :selected').parent().attr('label');
    var selectedValue = document.getElementById("map_filter").value;
    var filterBy = "=="
    let mapFilters = ["all"];
    switch (label) {
        case "review rating":
            filterBy = "<=";
            selectedValue = parseInt(selectedValue)
            label = "review_rating"
            mapFilters.push([filterBy, label, selectedValue])
            break;
        case "price":
            if (selectedValue == "1000+") {
                selectedValue = selectedValue.slice(0, selectedValue.length - 1);
                filterBy = ">"
            } else {
                filterBy = "<="
            }
            selectedValue = parseInt(selectedValue)
            mapFilters.push([filterBy, label, selectedValue])
            break;
        case undefined:
            break;
        default:
            mapFilters.push([filterBy, label, selectedValue])
            break;
    }
    if (FilterApertmentsCheckbox.checked) mapFilters.push(["==", "room_type", "Entire home/apt"]);
    if (onlyAvailabiltyCheckbox.checked) mapFilters.push(["==", "availabilityStatus", "HIGH"]);
    if (onlyMultiListings.checked) mapFilters.push([">", "calculated_host_listings_count", 1]);
    map.setFilter('locations_layer', mapFilters);
}
function showTopHosts() {
    var currentStyle = document.getElementById("topHostList").style.display;
    console.log(currentStyle)
    if (currentStyle == "block") {
        document.getElementById("topHostList").style.display = "none"
    } else {
        document.getElementById("topHostList").style.display = "block"
    }
}