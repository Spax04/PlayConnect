import { applyMiddleware, configureStore } from '@reduxjs/toolkit'
import userReducer from './slices/user'
import friendsReducer from './slices/friends'
import chatReducer from './slices/chat'
import {signal} from './signalr/chatConnection'

export default configureStore({
  reducer: {
    user: userReducer,
    friends: friendsReducer,
    chat: chatReducer
  },
  middleware: applyMiddleware(signal)
})