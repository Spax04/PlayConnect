import { createSlice } from '@reduxjs/toolkit'
import { act } from 'react-dom/test-utils'

export const gameSlice = createSlice({
  name: 'game',
  initialState: {
    connection: null,
    gameTypes: [],
    inGame: false,
    gameResults: [],
    currentSession: {
      sessionId: null,
      participants: [], // {participantId:"",participantName:"", isPlayer:true}
      gameTypeId: null,
      gameTypeStats: { gameLvl: null, gamePoints: null },
      isMyTurn: false,
      isPlayer: false,
      gameHistory: [],
      moveNumber: null
    }
  },
  reducers: {
    setConnection: (state, action) => {
      state.connection = action.payload
    },
    setGameTypes: (state, action) => {
      state.gameTypes = [...action.payload]
      sessionStorage.setItem('gameTypes', JSON.stringify(action.payload))
    },

    gameStart: (state, action) => {
      state.inGame = true
      state.currentSession.sessionId = action.payload.gameSessionId
      state.currentSession.gameTypeId = action.payload.gameTypeId
      state.currentSession.isMyTurn = action.payload.isMyTurn
      state.currentSession.isPlayer = action.payload.isPlayer
      state.currentSession.gameTypeStats.gameLvl = action.payload.gameLevel
      state.currentSession.gameTypeStats.gamePoints = action.payload.gamePoints
    },

    addParticipant: (state, action) => {
      const participant = state.currentSession.participants.find(
        p => p.participantId === action.payload.participantId
      )
      console.log(participant)

      if (!participant) {
        state.currentSession.participants = [
          ...state.currentSession.participants,
          action.payload
        ] // {participantId:"",participantName:"", isPlayer:true}
        console.log('Current participants: ', state.currentSession.participants)
      }
    },
    setNewMove: (state, action) => {
      state.currentSession.gameHistory = action.payload.moveHistory // {participantId:"",participantName:"", isPlayer:true}

      state.currentSession.moveNumber = action.payload.moveNumber
      state.currentSession.isMyTurn = !state.currentSession.isMyTurn
    },
    setGameOver: (state, action) => {
      state.inGame = false
      state.currentSession.sessionId = null
      state.currentSession.gameTypeId = null
      state.currentSession.isMyTurn = false
      state.currentSession.isPlayer = false
      state.currentSession.gameTypeStats.gameLvl = null
      state.currentSession.gameTypeStats.gamePoints = null
      state.currentSession.participants = []
      state.currentSession.moveNumber = null
      state.currentSession.gameHistory = []
    },
    setGameResults: (state, action) => {
      state.gameResults = action.payload
    }
  }
})

export const {
  setConnection: setGameServiceConnection,
  setGameTypes,
  gameStart,
  addParticipant,
  setNewMove,
  setGameResults,
  setGameOver
} = gameSlice.actions

export default gameSlice.reducer
