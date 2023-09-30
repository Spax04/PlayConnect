import { createSlice } from '@reduxjs/toolkit'

export const userSlice = createSlice({
  name: 'user',
  initialState: localStorage.getItem('user')
    ? {
        token: JSON.parse(localStorage.getItem('user')).token,
        userid: JSON.parse(localStorage.getItem('user')).userid,
        username: JSON.parse(localStorage.getItem('user')).username,
        email: JSON.parse(localStorage.getItem('user')).email
      }
    : {
        token: '',
        userid: '',
        username: '',
        email: ''
      },
  reducers: {
    setUser: (state, action) => {
      state.token = action.payload.token
      state.userid = action.payload.userid
      state.username = action.payload.username
      state.email = action.payload.email

      const user = {
        token: action.payload.token,
        userid: action.payload.userid,
        username: action.payload.username,
        email: action.payload.email
      }
      console.log(user)
      localStorage.setItem('user', JSON.stringify(user))
    },
    removeUser: state => {
      state.token = ''
      state.userid = ''
      state.username = ''
      state.email = ''

      localStorage.removeItem('user')
    }
  }
})

export const { setUser, removeUser } = userSlice.actions

export default userSlice.reducer
