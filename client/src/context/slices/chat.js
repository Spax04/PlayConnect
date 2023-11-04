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
    chats: []
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    },
    addMessage: (state, action) => {
      console.log(state.chats)
      console.log(action.payload)

      let isExist = false

      state.chats.forEach(c => {
        if (action.payload.chatWith === c.chatWith) {
          c.message = [...c.message, action.payload.message]
          isExist = true
        }
      })

      if (!isExist) {
        state.chats = [...state, action.payload]
      }
    },
    addChat: (state, action) => {
      console.log(action.payload)

      state.chats = [...state.chats, action.payload]
      console.log(state.chats)
    },
    setReceivedStatus: (state, action) => {
      state.chats.forEach(m => {
        if (m.messageId === action.payload.messageId) {
          m.isReceived = action.payload.status
        }
      })
    }
  }
})

export const { setConnection, addMessage, addChat } = chatSlice.actions

export default chatSlice.reducer
