import { createSlice } from '@reduxjs/toolkit'

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

      if (action.payload.status === true) {
        state.chats.forEach(c => {
          if (c.chatWith === action.payload.receiverId) {
            c.message.forEach(m => {
              if (m.messageId === action.payload.messageeId) {
                m.isReceived = action.payload.status
              }
            })
          }
        })
      }
    }
  }
})

export const { setConnection, addMessage, addChat, setReceivedStatus } =
  chatSlice.actions

export default chatSlice.reducer
