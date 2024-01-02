import { createSlice } from '@reduxjs/toolkit'

export const gameSlice = createSlice({
  name: 'game',
  initialState: {
    connection: null
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    }
  }
})

export const { setConnection : setGameServiceConnection } = gameSlice.actions

export default gameSlice.reducer
