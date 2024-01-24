import React, { useEffect, useState } from 'react'
import { useSelector } from 'react-redux/es/hooks/useSelector'
import { createChatConnection } from '../context/signalr/chatConnection'
import {
  addMiddleware,
  removeMiddleware,
  resetMiddlewares
} from 'redux-dynamic-middlewares'
import { setChatServiceConnection } from '../context/slices/chat'
import { setGameServiceConnection } from '../context/slices/game'
import { useDispatch } from 'react-redux'
import { createGameConnection } from '../context/signalr/gameConnection'
import axios from 'axios'
import {
  setFriends,
} from '../context/slices/friends'
import { useNavigate } from 'react-router-dom'

function useSocketConnection (navigate) {
  const [isOnline, setIsOnline] = useState(false)
  const user = useSelector(state => state.user)
  const [chatConnection, setChatConnection] = useState()
  const [gameConnection, setGameConnection] = useState()
  const dispatch = useDispatch()

  const navigateToGamePage = (route)=>{
    navigate(route);
  }

  const onUserOnline = async () => {
    setIsOnline(true)

    const { signal: chatSignal, connection: chatConnect } =
      createChatConnection()
    const { signal: gameSignal, connection: gameConnect } =
      createGameConnection(navigateToGamePage)

    addMiddleware(chatSignal)
    addMiddleware(gameSignal)

    setChatConnection(chatConnect)
    setGameConnection(gameConnect)

    dispatch(setGameServiceConnection(gameConnect))
    dispatch(setChatServiceConnection(chatConnect))

    await axios
      .get(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${user.userid}`
      )
      .then(({ data }) => {
        console.log(data)
        dispatch(setFriends(data))
      })
      .catch(err => {
        console.log(err)
      })
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

export default useSocketConnection
