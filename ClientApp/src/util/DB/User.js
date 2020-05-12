import axios from 'axios'
const ApiBase = "http://localhost:5000/api/user"

export default {
    AuthenticateUser: async function (userToBeAuthenticated) {
        const ApiCall = ApiBase + '/Authenticate'
        let AuthenticatedUser = await axios.post(ApiCall, {
            Email: userToBeAuthenticated.Email,
            Password: userToBeAuthenticated.Password
        })
        return AuthenticatedUser
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
        return CreatedUser
    },
    updateUser: async function (userToBeUpdated, token) {
        console.log(token)
        console.log(userToBeUpdated)
        const ApiCall = ApiBase + `/${userToBeUpdated.Id}`
        await axios.put(ApiCall, {
            First_Name: userToBeUpdated.First_Name,
            Last_Name: userToBeUpdated.Last_Name,
            Email: userToBeUpdated.Email,
            Password: userToBeUpdated.Password
        }, {
            headers: {
                Authorization: 'Bearer ' + token
            }

        })
    },
    getAllUsers: async function (token) {
        const ApiCall = ApiBase
        let AllUsers = await axios.get(ApiCall, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        })
        return AllUsers
    },
    getUser: async function (userId, token) {
        const ApiCall = ApiBase + `/${userId}`
        let user = (await axios.get(ApiCall, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        })
        )
        return user
    },
    deleteUser: async function (user, token) {
        //user can only delete their own account
    }

}