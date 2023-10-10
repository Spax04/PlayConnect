import {
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
  withCallbacks,
  signalMiddleware
} from 'updated-redux-signalr'
import { setMessage } from '../slices/chat'
const connection = new HubConnectionBuilder()
  .configureLogging(LogLevel.Debug)
  .withUrl(
    `${process.env.REACT_APP_CHAT_SERVICE_URL}/hub`,
    {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets
    }
  )
  .build()

const callbacks = withCallbacks().add('ReceiveMessage', msg => dispatch => {
  dispatch(setMessage(msg))
})

export const signal = signalMiddleware({
    callbacks,
    connection,
  });
