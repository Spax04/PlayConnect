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
        //? Friend object example:
        //?  {
        //?     "userId": "0b256643-ab18-4c29-a586-68e9d74d16c0",
        //?     "username": "Alex",
        //?     "email": "alex@example.com",
        //?     "token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI2MmI0YzE1Ny0yODI4LTQ3NDAtYTExZC1mODAyMTgwMjE1N2EiLCJ1c2VySWQiOiIwYjI1NjY0My1hYjE4LTRjMjktYTU4Ni02OGU5ZDc0ZDE2YzAiLCJuYW1lIjoiQWxleCIsImVtYWlsIjoiYWxleEBleGFtcGxlLmNvbSIsImV4cCI6MTczNTc0ODgyNH0.6ezYG2RIaj0PZqt5ILJeb0ngmOJ5YcFzxa5GiPO6JsFgMIAWqb2503Dywq_iFUFOWZKKjB-PITnaEjLSrNXkJA",
        //?     "refreshToken": null,
        //?     "coins": 0,
        //?     "isFriend": true,
        //?     "isRequested": false,
        //?     "isConnected": true,
        //?     "country": {
        //?         "id": "0eda96bc-4f00-445a-a1b9-1eb61086bbfe",
        //?         "code": "AM",
        //?         "name": "Armenia"
        //?     },
        //?     "isSucceed": true
        //? }
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
