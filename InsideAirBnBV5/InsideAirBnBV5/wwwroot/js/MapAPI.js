let changedFilter = () => {
    //TODO: change the header name.
    document.getElementById("filter_value").innerText = document.getElementById("map_filter").value
    //load different data
};
mapboxgl.accessToken = 'pk.eyJ1Ijoid2ludGVyY29tbyIsImEiOiJjanZncnFjdTIwYTJwM3ltajlmODQ0bWlpIn0.LbLEHOHfmrzlq6D5kLd1yQ';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/light-v10',
    zoom: 12,
    center: [4.888740, 52.381650]
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
        .setHTML("<div class='pup_up'> " +
            "<b>" + e.features[0].properties.host_name + "</b> <br>" +
            "<sub>(" + listing_ammount + ")</sub> " +
            "<hr> <p id='listing_id'>" + e.features[0].properties.id + "</p> " +
            "<p id='listingNameContainer' > " + e.features[0].properties.name + "</p> " +
            "<p id='neigbourhood'>" + e.features[0].properties.neighbourhood + "</p> " +
            "<p id='room_type' > " + e.features[0].properties.room_type + "</p> <hr> " +
            "<div class='income_section>'<p id='income'>&euro;INSERT EXPECTED INCOME</p> " +
            "<div class='listingSectionSubhead'><p id='location_price'>&euro;" + e.features[0].properties.price + "/night <br></p>" +
            "<p id='minimun_nights'>" + e.features[0].properties.minimum_nights + " nights minimum</p></div></div> " +
            "<br> <p id='nights_per_year'>(INSERT) nights per year (est.)</p> " +
            "<div class='listingSectionSubhead'><p id='occupancy_rate'>(INSERT) occupancy rate (est.)</p> " +
            "<p id='reviews_per_month'>" + e.features[0].properties.reviews_per_month + " reviews per month</p> " +
            "<p id='number_of_reviews'>" + e.features[0].properties.number_of_reviews + " reviews</p> " +
            "<p id='last_review'> last " + e.features[0].properties.last_review + " <br></p></div> " +
            "<p id='availability'>(INSERT) availability</p> " +
            "<sub id='availability_365'>" + e.features[0].properties.availability_365 + "days/year(PERCENTAGE%)</sub>  <br>" +
            "<sub id='availability_365'>click listing on map to 'pin' details</sub> " +
            "</div > ")
        .addTo(map);
};
map.on('load', function () {

    map.addLayer({
        'id': 'locations_layer',
        'type': 'circle',
        'source': {
            type: 'vector',
            url: 'mapbox://wintercomo.cjvi8k8lt03442wlm454lxe46-029u5'
        },
        'source-layer': 'listings',
        'paint': {
            // make circles larger as the user zooms from z12 to z22
            'circle-radius': {
                'base': 1,
                'stops': [[12, 2], [22, 180]]
            },
            // color circles by ethnicity, using a match expression
            // https://docs.mapbox.com/mapbox-gl-js/style-spec/#expressions-match
            //                'circle-color': [
            //                    'match',
            //                    ['get', 'ethnicity'],
            //                    'White', '#fbb03b',
            //                    'Black', '#223b53',
            //                    'Hispanic', '#e55e5e',
            //                    'Asian', '#3bb2d0',
            ///* other */ '#ccc'
            //                ]
        }
    });
    // When a click event occurs on a feature in the states layer, open a popup at the
    // location of the click, with description HTML from its properties.
    map.on('click', 'locations_layer', function (e) {
        clicked = !clicked;
        generatePopUp(e);
    });

    // Change the cursor to a pointer when the mouse is over the states layer.
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
});
