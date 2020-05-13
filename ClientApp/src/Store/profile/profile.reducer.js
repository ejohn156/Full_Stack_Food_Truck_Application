import {LOG_IN, LOG_OUT, UPDATE_PROFILE} from './profile.action'

const initialState = {
    Profile: {
        Id: null,
        First_Name: null,
        Last_Name: null,
        Email: null,
        Favorites: [],
        Token: null
    }
}

function UserReducer (state = initialState, action) {
   switch(action.type) {
       case LOG_IN: 
       return Object.assign({}, initialState, {
           Profile : action.state
       })
       case LOG_OUT: return Object.assign({}, initialState, {
           Profile: null
       })
       case UPDATE_PROFILE: return Object.assign({}, initialState, {
           Profile: action.state
    })
   default: {
    return state
   }
}
}

export default UserReducer