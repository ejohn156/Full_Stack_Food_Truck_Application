import {REFRESH_TRUCKS} from './trucks.action'

const initialState = {
    Trucks: []
}

function TruckReducer (state = initialState, action) {
   switch(action.type) {
       case REFRESH_TRUCKS: 
       return Object.assign({}, initialState, {
           Trucks : action.state
       })
   default: {
    return state
   }
}
}

export default TruckReducer