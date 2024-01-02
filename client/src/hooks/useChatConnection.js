import React, { useEffect, useState } from 'react'
import { useSelector } from 'react-redux/es/hooks/useSelector'
import { createChatConnection } from '../context/signalr/chatConnection'
import {
  addMiddleware,
  removeMiddleware,
  resetMiddlewares
} from 'redux-dynamic-middlewares'
import { setConnection } from '../context/slices/chat'
import { setGameServiceConnection } from '../context/slices/game'
import { useDispatch } from 'react-redux'
import { createGameConnection } from '../context/signalr/gameConnection'

function useChatConnection () {
  const [isOnline, setIsOnline] = useState(false)
  const user = useSelector(state => state.user)
  const [chatConnection, setChatConnection] = useState()
  const [gameConnection, setGameConnection] = useState()
  const dispatch = useDispatch()

  const onUserOnline = () => {
    setIsOnline(true)

    const { signal: chatSignal, connection: chatConnect } = createChatConnection()
    const { signal: gameSignal, connection: gameConnect } = createGameConnection()

    addMiddleware(chatSignal)
    addMiddleware(gameSignal)

    setChatConnection(chatConnect)
    setGameConnection(gameConnect)

    dispatch(setGameServiceConnection(gameConnect))
    dispatch(setConnection(chatConnect))
  }

  const onUserOffline = () => {
    setIsOnline(false)
    if (chatConnection) {
      chatConnection
        .stop()
        .then(() => console.log('Chat service connection stopped'))
        .catch(err => console.error(err.toString()))
    }
    if (gameConnection) {
      gameConnection
        .stop()
        .then(() => console.log('Game service connection stopped'))
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
