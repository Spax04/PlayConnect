import { createSlice } from '@reduxjs/toolkit'
import * as signalR from '@microsoft/signalr'
import { connect, useSelector } from 'react-redux'
import { useChatConnection } from '../../hooks/useChatConnection'

export const chatSlice = createSlice({
  name: 'chat',
  initialState: {
    connection: null,
    messages: []
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
     
    },
    disconnect: (state)=>{
      state.connection.stop()
      state.connection = null;
    },
    setMessage:(state,action)=>{
      
    }
  }
})

export const { setConnection ,disconnect} = chatSlice.actions

export default chatSlice.reducer
