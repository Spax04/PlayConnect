import {
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
  withCallbacks,
  signalMiddleware
} from 'updated-redux-signalr'
import axios from 'axios'
import { useDispatch, useSelector } from 'react-redux'
import { EVENTS, ROUTES } from '../../constants'
import { toast } from 'react-toastify'
import { Button } from 'react-bootstrap'
import { addParticipant, gameStart, setNewMove } from '../slices/game'
import InvitePopup from '../../components/popups/InvitePopup.jsx'
import { useEffect } from 'react'
import useNavigationToGamePage from '../../hooks/useNavigationToGamePage'
import GameInviteResponsePopup from '../../components/popups/GameInviteResponsePopup.jsx'

export function createGameConnection (navigate) {
  const token = JSON.parse(localStorage.getItem('user')).token
  const user = JSON.parse(localStorage.getItem('user'))

  const connection = new HubConnectionBuilder()
    .configureLogging(LogLevel.Debug)
    .withUrl(`${process.env.REACT_APP_GAME_SERVICE_URL}/hub?`, {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets,
      accessTokenFactory: () => token
    })
    .build()

  const callbacks = withCallbacks()
    .add(EVENTS.GAME.CLIENT.PLAYER_CONNECTED, playerId => dispatch => {
      console.log('Player has connected ' + playerId)
    })
    .add(EVENTS.GAME.CLIENT.PLAYER_DISCONNECTED, playerId => dispatch => {
      console.log('Player has disconnected ' + playerId)
    })
    .add(EVENTS.GAME.CLIENT.GET_INVITE_TO_GAME, gameInvite => dispatch => {
      console.log('Got invite')
      toast(
        <InvitePopup
          guestId={gameInvite.guestId}
          gameTypeId={gameInvite.gameTypeId}
          hostId={gameInvite.hostId}
        />,
        {
          position: 'top-left',
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: 'light'
        }
      )
    })
    .add(EVENTS.GAME.CLIENT.GET_REFUSAL_RESPONSE, () => dispatch => {
      toast.error('Invite was refused', {
        position: 'bottom-center',
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: 'light'
      })
    })
    .add(
      EVENTS.GAME.CLIENT.JOINED_TO_GAME,
      joinedToGameResponse => dispatch => {
        const user = JSON.parse(localStorage.getItem('user'))

        if (joinedToGameResponse.playerId === user.userid) {
          const gameTypes = JSON.parse(sessionStorage.getItem('gameTypes'))
          dispatch(gameStart(joinedToGameResponse))
          let gameName
          let gameRoute
          gameTypes.forEach(game => {
            if (joinedToGameResponse.gameTypeId === game.id) {
              gameName = game.name.replace(/ /g, '').toLowerCase()
              switch (gameName) {
                case 'tictactoe':
                  gameRoute = ROUTES.GAMES.TIC_TAC_TOE_GAME_PAGE
                  return
                case 'battleship':
                  gameRoute = ROUTES.GAMES.BATTLESHIP_GAME_PAGE
                  return
                case 'checkers':
                  gameRoute = ROUTES.GAMES.CHECKERS_GAME_PAGE
                  return
                default:
                  break
              }
            }
          })
          console.log(gameName)

          console.log(gameRoute)
          navigate(`${gameRoute}/${joinedToGameResponse.gameSessionId}`)
        }
      }
    )
    .add(EVENTS.GAME.CLIENT.READY_TO_GAME, response => dispatch => {
      const user = JSON.parse(localStorage.getItem('user'))

      if (response.playerId !== user.userid) {
        dispatch(
          addParticipant({
            participantId: response.playerId,
            participantName: response.playerName,
            isPlayer: response.isPlayer
          })
        )
        toast(response.message, {
          position: 'top-left',
          autoClose: 3000,
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: 'colored'
        })
      }
    })
    .add(EVENTS.GAME.CLIENT.NEW_GAME_MOVE, response => dispatch => {
      console.log(response)
      const user = JSON.parse(localStorage.getItem('user'))

      const gameMove = JSON.parse(response.gameMove)
      const moveHistory = JSON.parse(gameMove.moveHistoryJson)

      console.log('Game move: ', gameMove)
      console.log('Move history: ', moveHistory)

      dispatch(setNewMove({ moveHistory, moveNumber: gameMove.moveNumber }))

      // TODO: Need to recive an object from API and put it to history,need update to 2 users
    })

  const signal = signalMiddleware({
    callbacks,
    connection
  })

  return { signal, connection }
}
