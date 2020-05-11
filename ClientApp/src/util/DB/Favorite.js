import axios from 'axios'
const ApiBase = "http://localhost:5000/api/favorite"

export default {
    updateFavorite: async function (favoriteToBeUpdated, token) {
        const ApiCall = ApiBase + `/${favoriteToBeUpdated.Id}`
        let updatedFavorite = (await axios.put(ApiCall, { favoriteToBeUpdated }, {
            header: {
                Authorization: 'Bearer ' + token
            }
        }))
        return updatedFavorite
    },
    getAllFavorites: async function (token) {
        const ApiCall = ApiBase
        let AllFavorites = await axios.get(ApiCall, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        })
        return AllFavorites
    },
    getFavorite: async function (favoriteId, token) {
        const ApiCall = ApiBase + `/${favoriteId}`
        let favorite = (await axios.get(ApiCall, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        })
        )
        return favorite
    },
    deleteFavorite: async function (favorite, token) {
        //Favorite can only delete their own account
    }

}