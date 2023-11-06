import React, { useEffect, useState } from 'react'
import { useSelector } from 'react-redux/es/hooks/useSelector'
import { createChatConnection } from '../context/signalr/chatConnection'
import {
  addMiddleware,
  removeMiddleware,
  resetMiddlewares
} from 'redux-dynamic-middlewares'
import { setConnection } from '../context/slices/chat'
import { useDispatch } from 'react-redux'

function useChatConnection () {
  const [isOnline, setIsOnline] = useState(false)
  const user = useSelector(state => state.user)
  const [chatConnection, setChatConnection] = useState()
  const dispatch = useDispatch()


  const onUserOnline = () => {
    setIsOnline(true)
    const { signal, connection } = createChatConnection()
    addMiddleware(signal)
    setChatConnection(connection)
    dispatch(setConnection(connection))
  }

  const onUserOffline = () => {
    setIsOnline(false)
    if (chatConnection) {
      chatConnection
        .stop()
        .then(() => console.log('Connection stopped'))
        .catch(err => console.error(err.toString()))
    }
  }

  useEffect(() => {
    if (user.token) {
      onUserOnline()
    } else {
      onUserOffline()
    }
    
    console.log(user)
  }, [user])

  return { isOnline }
}

export default useChatConnection
