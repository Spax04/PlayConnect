import {
  applyMiddleware,
  combineReducers,
  configureStore
} from '@reduxjs/toolkit'
import userReducer from './slices/user'
import friendsReducer from './slices/friends'
import chatReducer from './slices/chat'
import dynamicMiddlewares from 'redux-dynamic-middlewares' 
import gameReducer from './slices/game'


export default configureStore({
  reducer: {
    user: userReducer,
    friends: friendsReducer,
    chat: chatReducer,
    game: gameReducer
  },
  middleware: [dynamicMiddlewares],
  
})