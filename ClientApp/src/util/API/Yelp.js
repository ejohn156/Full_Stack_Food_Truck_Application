import axios from 'axios'

export default {
    searchTrucks: async function (entry) {
        
        var queryUrl = "https://api.yelp.com/v3/businesses/search?"
        var searchParams = {
            term: entry,
            categories: "foodtrucks",
            location: "Charlotte, NC",
            limit: 50
        }
        var foodtrucks = await axios.get(`${'https://cors-anywhere.herokuapp.com/'}` + queryUrl, {
            headers: {
                Authorization: `Bearer f-JYAyEnLLbaO2pkyaLg8WQqcq7puzzchmTNmHC-2fVLhWXoMszhCZhRSv-8G50R0zNcB6rfc2kX30bxNRYUQPfg_dh1btpOlI7O-enve-bjnkGje7tWQ10GhS35XHYx`
            },
            params: searchParams
        })
        console.log(foodtrucks)
       
}
}