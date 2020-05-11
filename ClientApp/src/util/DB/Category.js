import axios from 'axios'
const ApiBase = "http://localhost:5000/api/category"

export default {
    updateCategory: async function (categoryToBeUpdated, token) {
        const ApiCall = ApiBase + `/${categoryToBeUpdated.Id}`
        let updatedCategory = (await axios.put(ApiCall, { categoryToBeUpdated }, {
            header: {
                Authorization: 'Bearer ' + token
            }
        }))
        return updatedCategory
    },
    getAllCategorys: async function (token) {
        const ApiCall = ApiBase
        let AllCategories = await axios.get(ApiCall, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        })
        return AllCategories
    },
    getCategory: async function (categoryId, token) {
        const ApiCall = ApiBase + `/${categoryId}`
        let category = (await axios.get(ApiCall, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        })
        )
        return category
    },
    deleteCategory: async function (Category, token) {
        //Category can only delete their own account
    }

}