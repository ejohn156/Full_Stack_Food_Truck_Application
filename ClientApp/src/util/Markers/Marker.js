
export default {
    CreateMarkers(trucks, favorites) {

        var geoJson = []
        trucks.map(truck => {
            geoJson.push(
                {
                    "coordinates": {
                        "lat" : truck.coordinates.latitude,
                        "lng": truck.coordinates.longitude
                    }
                    ,
                    "properties": {
                        "name": truck.name,
                        "truckId": truck.id,
                        "phone": truck.display_phone,
                        "image": truck.image_url,
                        "location": truck.location.address + ", " + truck.location.city,
                        "website": truck.url,
                        "rating": truck.rating,
                        "price": truck.price,
                        "categories": truck.categories
                    }
                }
            )
        })
        return geoJson
    }

}
