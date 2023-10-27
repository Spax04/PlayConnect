import { createSlice } from '@reduxjs/toolkit'

export const friendsSlice = createSlice({
  name: 'friends',
  initialState: sessionStorage.getItem('friends')
    ? {
        ...JSON.parse(sessionStorage.getItem('friends'))
      }
    : {
        acceptedFriends: [],
        pendingFriends: []
      },
  reducers: {
    setFriends: (state, action) => {
      state.acceptedFriends = [...action.payload.acceptedFriends]
      state.pendingFriends = [...action.payload.pendingFriends]
      console.log(action.payload)
      const friends = {
        acceptedFriends: [...action.payload.acceptedFriends],
        pendingFriends: [...action.payload.pendingFriends]
      }
      sessionStorage.setItem('friends', JSON.stringify(friends))
    },
    removeFriends: state => {
      state = []
      sessionStorage.removeItem('friends')
    },
    setFriendConnected: (state, action) => {
      console.log(action.payload)
      state.acceptedFriends.forEach(f => {
        if (f.userId === action.payload) {
          f.isConnected = true
          return
        }
      })
      
      state.pendingFriends.forEach(f => {
        if (f.userId === action.payload) {
          f.isConnected = true
          return
        }
      })
    },
    setFriendDisconnected: (state, action) => {
      state.acceptedFriends.forEach(f => {
        if (f.userId === action.payload) {
          f.isConnected = false
          return
        }
      })

      state.pendingFriends.forEach(f => {
        if (f.userId === action.payload) {
          f.isConnected = false
          return
        }
      })
    }
  }
})

export const {
  setFriends,
  removeFriends,
  setFriendConnected,
  setFriendDisconnected
} = friendsSlice.actions

export default friendsSlice.reducer
