import {
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
  withCallbacks,
  signalMiddleware
} from 'updated-redux-signalr'
import { addMessage, setReceivedStatus } from '../slices/chat'
import { setFriends } from '../slices/friends'
import { setFriendConnected, setFriendDisconnected} from '../slices/friends'
import axios from 'axios'
import { useDispatch, useSelector } from 'react-redux'
import { EVENTS } from '../../constants'

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
    .add(EVENTS.CHAT.CLIENT.CHATTER_CONNECTED, chatterId => dispatch => {
      console.log('User has connected ' + chatterId)
      dispatch(setFriendConnected(chatterId))
    })
    .add(EVENTS.CHAT.CLIENT.CHATTER_DISCONNECTED, chatterId => dispatch => {
      dispatch(setFriendDisconnected(chatterId))
    })
    .add(EVENTS.CHAT.CLIENT.ON_GET_FRIENDS, () => dispatch => {
      console.log('get friends event')
      axios
        .get(
          `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${userid}`
        )
        .then(({ data }) => {
          console.log("On Get Friend event");
          console.log(data)
          dispatch(setFriends(data))
        })
        .catch(err => console.log(err))
    })
    .add(EVENTS.CHAT.CLIENT.RECEIVE_MESSAGE, message => dispatch => {
      console.log('Message received:' + message)
      if (!document.hasFocus()) {
        document.title = '✉ New Message'
      }
      let chatWith

      if (message.senderId === userid) {
        chatWith = message.recipientId
      } else {
        chatWith = message.senderId
      }

      dispatch(addMessage({ message: message, chatWith: chatWith }))
    })
    .add(EVENTS.CHAT.CLIENT.ON_MESSAGE_RECEIVED, message => dispatch => {
      dispatch(setReceivedStatus(message))
    })

  const signal = signalMiddleware({
    callbacks,
    connection
  })

  return { signal, connection }
}
