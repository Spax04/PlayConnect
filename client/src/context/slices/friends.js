import { createSlice } from '@reduxjs/toolkit'

export const friendsSlice = createSlice({
  name: 'friends',
  initialState: localStorage.getItem('friends')
    ? {
        friends: [...JSON.parse(localStorage.getItem('friends')).accepted],
        pending: [...JSON.parse(localStorage.getItem('friends')).pending]
    }
    : {
        friends:[],
        pending:[]
    },
  reducers: {
    setFriends: (state, action) => {
    //   const friends = [...action.payload]
    //   state = friends
    //   console.log(friends)
    //   localStorage.setItem('friends', JSON.stringify(friends))
    },
    removeFriends: state => {
    //   state = []

    //   localStorage.removeItem('friends')
    }
  }
})

export const { setFriends, removeFriends } = friendsSlice.actions

export default friendsSlice.reducer
