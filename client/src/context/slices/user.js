import { createSlice } from '@reduxjs/toolkit'

export const userSlice = createSlice({
  name: 'user',
  initialState: {
    token: '',
    username: '',
    email: ''
  },
  reducers: {
    setUser: (state, { token, username, email }) => {
      state.token = token
      state.username = username
      state.email = email

      localStorage.setItem('user', { token, username, email })
    },
    removeUser: state => {
        state.token = ''
        state.username = ''
        state.email = ''
        localStorage.removeItem('user')
    }
  }
})

export const {setUser,removeUser} = userSlice.actions

export default userSlice.reducer
