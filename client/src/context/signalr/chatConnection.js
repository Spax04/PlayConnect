import {
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
  withCallbacks,
  signalMiddleware
} from 'updated-redux-signalr'
import { setMessage } from '../slices/chat'
import { setFriends } from '../slices/friends'
import { setFriendConnected, setFriendDisconnected } from '../slices/friends'
import axios from 'axios'
import { useDispatch, useSelector } from 'react-redux'

export function createChatConnection () {
  const token = JSON.parse(localStorage.getItem('user')).token
  const userid = JSON.parse(localStorage.getItem('user')).userid

  const connection = new HubConnectionBuilder()
    .configureLogging(LogLevel.Debug)
    .withUrl(`${process.env.REACT_APP_CHAT_SERVICE_URL}/hub?`, {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets,
      accessTokenFactory: () => token
    })
    .build()

  const callbacks = withCallbacks()
    .add('ReceiveMessage', msg => dispatch => {
      console.log(msg)
    })
    .add('ChatterConnected', chatterId => dispatch => {
      console.log('User has connected ' + chatterId)
      dispatch(setFriendConnected(chatterId))
    })
    .add('ChatterDisconnect', chatterId => dispatch => {
      dispatch(setFriendDisconnected(chatterId))
    })
    .add('onGetFriends', ()=>  dispatch => {
      console.log('get friends event')
       axios
        .get(
          `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${userid}`
        )
        .then(({ data }) => {
          console.log(data);
          dispatch(setFriends(data))
        })
        .catch(err => console.log(err))
    })

  const signal = signalMiddleware({
    callbacks,
    connection
  })

  return { signal, connection, invokeGetFriends }
}

export const invokeGetFriends = userid => (dispatch, getState, invoke) => {
  console.log('in invoke method')
  invoke('FriendRequestSended', userid)
}
