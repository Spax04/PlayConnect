import { createSlice } from '@reduxjs/toolkit'

export const gameSlice = createSlice({
  name: 'game',
  initialState: {
    connection: null,
    gameTypes:[],
    inGame:false
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    },
    setGameTypes : (state,action) =>{
      state.gameTypes = [state,...action.payload]
    },
    switchInGame :(state) =>{
      state.inGame = state.inGame? false : true
    },
  }
})

export const { setConnection : setGameServiceConnection ,setGameTypes,switchInGame} = gameSlice.actions

export default gameSlice.reducer
