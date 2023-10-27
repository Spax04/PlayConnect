import {
  applyMiddleware,
  combineReducers,
  configureStore
} from '@reduxjs/toolkit'
import userReducer from './slices/user'
import friendsReducer from './slices/friends'
import chatReducer from './slices/chat'
import { signal } from './signalr/chatConnection'
import dynamicMiddlewares from 'redux-dynamic-middlewares' 


export default configureStore({
  reducer: {
    user: userReducer,
    friends: friendsReducer,
    chat: chatReducer
  },
  middleware: [dynamicMiddlewares],
  
})