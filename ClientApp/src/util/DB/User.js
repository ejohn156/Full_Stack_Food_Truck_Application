import axios from 'axios'
const ApiBase = "http://localhost:5000/api/user"
let config = {
    headers: {
      'Authorization': 'Bearer ' + 'token stored in cookie will be placed here'
    }
}
export default {
    
    AuthenticateUser: async function (userToBeAuthenticated) {
        const ApiCall = ApiBase + '/Authenticate'
        let AuthenticatedUser = await axios.post(ApiCall, userToBeAuthenticated, config)
        return AuthenticatedUser
    },
    newUserSignUp: async function(userToBeCreated){
        const ApiCall = ApiBase + '/Create'
        await axios.post(ApiCall, {userToBeCreated}, config)
    },
    updateUser: async function(userToBeUpdated){
        const ApiCall = ApiBase + `/${userToBeUpdated.Id}`
        let updatedUser = (await axios.put(ApiCall,{userToBeUpdated}, config))
        return updatedUser
    },
    getAllUsers: async function(){
        const ApiCall = ApiBase
        let AllUsers = axios.get(ApiCall, config)
        return AllUsers
    },
    getUser: async function(userId){
        const ApiCall = ApiBase + `/${userId}`
        let user = (await axios.get(ApiCall, config))
        return user
    },
    deleteUser: async function(user){
        //user can only delete their own account
    }

}