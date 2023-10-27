import { createSlice } from '@reduxjs/toolkit'
import * as signalR from '@microsoft/signalr'
import { connect, useSelector } from 'react-redux'
import {
  addMiddleware,
  removeMiddleware,
  resetMiddlewares
} from 'redux-dynamic-middlewares'
import { HubConnectionState } from 'updated-redux-signalr'
import { createChatConnection } from '../signalr/chatConnection'

export const chatSlice = createSlice({
  name: 'chat',
  initialState: {
    connection: null,
    messages: []
  },
  reducers: {
    setConnection: (state,action) => {
     state.connection = action.payload
    },
   
  }
})

export const {
  setConnection,
} = chatSlice.actions

export default chatSlice.reducer
