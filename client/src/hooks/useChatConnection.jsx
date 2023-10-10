import React, { useEffect, useState } from 'react'
import * as signalR from '@microsoft/signalr'
import { useDispatch, useSelector } from 'react-redux'
import { EVENTS } from '../constants'
import { setConnection, setMessage } from '../context/slices/chat'

function useChatConnection () {
  const user = useSelector(state => state.user)
  const chat = useSelector(state => state.chat)
  const [connection, setConnection] = useState(null)

  
  useEffect(() => {
    if (!connection) {
      let hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(
          `${process.env.REACT_APP_CHAT_SERVICE_URL}/hub?userIdentifier=${user.userid}`
        )
        .build()

      setConnection(hubConnection)

      hubConnection.start()
      .then(() => {
        hubConnection.on('ReceiveUpdate', message => {
          // Handle the update received from the server
          console.log(`Received update: ${message}`)
        })
      })
      .catch(err => console.log(err))
    }
  }, [connection])

  return { connection }
}

export default useChatConnection
