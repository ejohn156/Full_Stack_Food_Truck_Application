import {LOG_IN, LOG_OUT, UPDATE_PROFILE} from './profile.action'

const initialState = {
    Profile: {
        id: null,
        first_Name: null,
        last_Name: null,
        email: null,
        favorites: []
    }
}

function UserReducer (state = initialState, action) {
   switch(action.type) {
       case LOG_IN: return Object.assign({}, initialState, {
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