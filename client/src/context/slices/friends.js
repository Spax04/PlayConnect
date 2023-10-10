import { createSlice } from '@reduxjs/toolkit'

export const friendsSlice = createSlice({
  name: 'friends',
  initialState: localStorage.getItem('friends')
    ? {
        ...JSON.parse(localStorage.getItem('friends'))
      }
    : { acceptedFriends: [], pendingFriends: [] },
  reducers: {
    setFriends: (state, action) => {
      state.acceptedFriends = [...action.payload.acceptedFriends]
      state.pendingFriends = [...action.payload.pendingFriends]

      const friends = {
        acceptedFriends: [...action.payload.acceptedFriends],
        pendingFriends: [...action.payload.pendingFriends]
      }
      localStorage.setItem('friends', JSON.stringify(friends))
    },
    removeFriends: state => {
      //   state = []
      //   localStorage.removeItem('friends')
    },
    //!!!
    // setFromPendingToAccept: (state, action) => { 
    //   const userId = action.payload.userid
    //   let user = state.pendingFriends.find(f => f.userid === userId)
    //   user.isFriend = true;
    //   state.friends = [...state.friends,user]
    //   state.pendingFriends = [...state.pendingFriends.filter(f=> f.userid !== userId)]
    // }
  }
})

export const { setFriends, removeFriends } = friendsSlice.actions

export default friendsSlice.reducer
