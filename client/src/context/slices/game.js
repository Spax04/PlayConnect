import { createSlice } from '@reduxjs/toolkit'

export const gameSlice = createSlice({
  name: 'game',
  initialState: {
    connection: null,
    gameTypes:[],
    inGame:false,
    currentSessionId: null,
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    },
    setGameTypes : (state,action) =>{
      state.gameTypes = [state,...action.payload]
    },
    
    gameStart:(state,action)=>{
      console.log(action);
      state.inGame = state.inGame? false : true;
      state.currentSessionId = action.payload

      console.log(action.gameSessionId);
    }
  }
})

export const { setConnection : setGameServiceConnection ,setGameTypes,gameStart} = gameSlice.actions

export default gameSlice.reducer
