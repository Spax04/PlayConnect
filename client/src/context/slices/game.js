import { createSlice } from '@reduxjs/toolkit'

export const gameSlice = createSlice({
  name: 'game',
  initialState: {
    connection: null,
    gameTypes:[]
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    },
    setGameTypes : (state,action) =>{
      state.gameTypes = [state,...action.payload]
    }
  }
})

export const { setConnection : setGameServiceConnection ,setGameTypes} = gameSlice.actions

export default gameSlice.reducer
