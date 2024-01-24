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
import { gameStart } from '../slices/game'
import InvitePopup from '../../components/InvitePopup'
import { useEffect } from 'react'
import useNavigationToGamePage from '../../hooks/useNavigationToGamePage'
import GameInviteResponsePopup from '../../components/GameInviteResponsePopup.jsx'

export function createGameConnection (navigate) {
  const token = JSON.parse(localStorage.getItem('user')).token
  const userid = JSON.parse(localStorage.getItem('user')).userid

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
          autoClose: 5000,
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: 'light'
        }
      )
    })
    .add(EVENTS.GAME.CLIENT.GET_INVITE_RESPONSE, inviteResponse => dispatch => {
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
        console.log(joinedToGameResponse)
        dispatch(gameStart(joinedToGameResponse.gameSessionId))
       // window.location.replace()
       navigate(`${ROUTES.TIC_TAC_TOE_GAME_PAGE}/${joinedToGameResponse.gameSessionId}`)
        toast('Invite was accepted', {
          position: 'top-left',
          autoClose: 5000,
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: 'light'
        })
      }
    )
    .add(EVENTS.GAME.CLIENT.GAME_IS_READY, () => dispatch => {})

  const signal = signalMiddleware({
    callbacks,
    connection
  })

  return { signal, connection }
}
