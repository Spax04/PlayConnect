import { createSlice } from '@reduxjs/toolkit'

export const chatSlice = createSlice({
  name: 'chat',
  initialState: {
    connection: null,
    chats: [],
    currentGroupChat: [] // {senderName:"",message:""}
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    },
    addMessage: (state, action) => {
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
      state.chats = [...state.chats, action.payload]
    },
    setReceivedStatus: (state, action) => {
      //! O(n^2), need to find a better way
      console.log('Set received status: ' + action.payload.status)
      if (action.payload.status === true) {
        state.chats.forEach(c => {
          if (c.chatWith === action.payload.chatterId) {
            c.message.forEach(m => {
              if (m.messageId === action.payload.messageeId) {
                m.isReceived = action.payload.status
              }
            })
          }
        })
      }
    },
    addGroupeMessage: (state, action) => {
      const groupeMessage = {
        senderName: action.payload.senderName,
        message: action.payload.message
      }
      state.currentGroupChat = [...state.currentGroupChat, groupeMessage]
    },
    connectedToGroupeChat: (state, action) => {
      const groupeMessage = {
        senderName: action.payload.senderName,
        message: `${action.payload.senderName} has connected to game chat`
      }
      state.currentGroupChat = [...state.currentGroupChat, groupeMessage]
    },
    clearGroupeChat: (state, action) => {
      state.currentGroupChat = []
    }
  }
})

export const {
  setConnection: setChatServiceConnection,
  addMessage,
  addChat,
  setReceivedStatus,
  addGroupeMessage,
  connectedToGroupeChat,
  clearGroupeChat
} = chatSlice.actions

export default chatSlice.reducer
