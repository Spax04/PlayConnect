import { configureStore } from '@reduxjs/toolkit'
import userReducer from './slices/user'
import friendsReducer from './slices/friends'

export default configureStore({
  reducer: {
    user: userReducer,
    friends: friendsReducer
  }
})