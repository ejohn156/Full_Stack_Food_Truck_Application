import { combineReducers } from 'redux'
import Profile from './profile/profile.reducer'
import Trucks from './trucks/trucks.reducer'

export default combineReducers({
  Profile,
  Trucks
})