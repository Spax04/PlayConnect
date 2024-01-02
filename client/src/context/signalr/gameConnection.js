import {
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
  withCallbacks,
  signalMiddleware
} from 'updated-redux-signalr'
import axios from 'axios'
import { useDispatch, useSelector } from 'react-redux'
import { EVENTS } from '../../constants'

export function createGameConnection () {
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
    .add(EVENTS.GAME.CLIENT.GET_INVITE_TO_GAME, () => dispatch => {})
    .add(EVENTS.GAME.CLIENT.GET_INVITE_RESPONSE, () => dispatch => {})
    .add(EVENTS.GAME.CLIENT.JOINED_TO_GAME, () => dispatch => {})
    .add(EVENTS.GAME.CLIENT.GAME_IS_READY, () => dispatch => {})

  const signal = signalMiddleware({
    callbacks,
    connection
  })

  return { signal, connection }
}
