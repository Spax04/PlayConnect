import { createSlice } from '@reduxjs/toolkit'

export const userSlice = createSlice({
  name: 'user',
  initialState: {
    user: {
      token: '',
      userid: '',
      username: '',
      email: ''
    }
  },
  reducers: {
    setUser: (state, action) => {
      state.user.token = action.payload.token
      state.user.userid = action.payload.userid
      state.user.username = action.payload.username
      state.user.email = action.payload.email

     
      
      const user = {
        token: action.payload.token,
        userid: action.payload.userid,
        username: action.payload.username,
        email: action.payload.email
      }
      console.log(user);
      localStorage.setItem('user', JSON.stringify(user))
    },
    removeUser: state => {
      state.user.token = ''
      state.user.userid = ''
      state.user.username = ''
      state.user.email = ''

      localStorage.removeItem('user')
    }
  }
})

export const { setUser, removeUser } = userSlice.actions

export default userSlice.reducer
