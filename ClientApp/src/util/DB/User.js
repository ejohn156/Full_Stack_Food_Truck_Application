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
        let AuthenticatedUser = await axios.post(ApiCall, { 
            Email: userToBeAuthenticated.Email,
            Password: userToBeAuthenticated.Password })
        console.log(AuthenticatedUser);
    },
    newUserSignUp: async function (userToBeCreated) {
        const ApiCall = ApiBase + '/Signup'
        let CreatedUser = await axios.post(ApiCall,
            {

                Email: userToBeCreated.Email,
                Password: userToBeCreated.Password,
                First_Name: userToBeCreated.First_Name,
                Last_Name: userToBeCreated.Last_Name

            })
        console.log(CreatedUser)
    },
    updateUser: async function (userToBeUpdated) {
        const ApiCall = ApiBase + `/${userToBeUpdated.Id}`
        let updatedUser = (await axios.put(ApiCall, { userToBeUpdated }, config))
        return updatedUser
    },
    getAllUsers: async function () {
        const ApiCall = ApiBase
        let AllUsers = axios.get(ApiCall, config)
        return AllUsers
    },
    getUser: async function (userId) {
        const ApiCall = ApiBase + `/${userId}`
        let user = (await axios.get(ApiCall, config))
        return user
    },
    deleteUser: async function (user) {
        //user can only delete their own account
    }

}