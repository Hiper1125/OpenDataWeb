var map;

function CreateMap() {
    map = new ol.Map({
        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([12.56738, 41.87194]),
            zoom: 6
        })
    });
}

function DrawMap(lat, lon) {

    var layer = new ol.layer.Tile({
        source: new ol.source.OSM()
    })

    map.addLayer(layer);
    

    map.setView(new ol.View({
        center: ol.proj.fromLonLat([lon, lat]),
        zoom: 12
    }));
}


function SetPos(nome, lat, lon) {

    let latStr = lat.toString();
    lat = latStr.substr(0, 2) + "." + latStr.substr(2, latStr.length - 2);

    let lonStr = lon.toString();

    if (lonStr.substr(0, 2) > 20) {
        lon = lonStr.substr(0, 1) + "." + lonStr.substr(1, lonStr.length - 1);
    }
    else {
        lon = lonStr.substr(0, 2) + "." + lonStr.substr(2, lonStr.length - 2);
    }

    map.setLayerGroup(new ol.layer.Group());

    DrawMap(lat, lon);

    var layer = new ol.layer.Vector({
        source: new ol.source.Vector({
            features: [
                new ol.Feature({
                    geometry: new ol.geom.Point(ol.proj.fromLonLat([lon, lat]))
                })
            ]
        })
    });
    map.addLayer(layer);

    var container = document.getElementById('popup');
    var content = document.getElementById('popup-content');
    var closer = document.getElementById('popup-closer');

    var overlay = new ol.Overlay({
        element: container,
        autoPan: true,
        autoPanAnimation: {
            duration: 250
        }
    });
    map.addOverlay(overlay);

    map.on('singleclick', function (event) {
        if (map.hasFeatureAtPixel(event.pixel) === true) {
            var coordinate = event.coordinate;

            content.innerHTML = '<div class="loc-generated"><b>Generated Location</b><br/>' + nome + '</div>';
            overlay.setPosition(coordinate);
        } else {
            overlay.setPosition(undefined);
            closer.blur();
        }
    });

    content.innerHTML = '<div class="loc-generated"><b>Generated Location</b><br/>' + nome + '</div>';
    overlay.setPosition(ol.proj.fromLonLat([lon, lat]));

    closer.onclick = function () {
        overlay.setPosition(undefined);
        closer.blur();
        return false;
    };

    map.setView(new ol.View({
        center: ol.proj.fromLonLat([lon, lat]),
        zoom: 12
    }));
}