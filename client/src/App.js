import './App.css'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import Container from 'react-bootstrap/Container'
import { BrowserRouter, Route, Routes, useNavigate } from 'react-router-dom'
import HomePage from './pages/HomePage'
import LoginPage from './pages/AuthPages/LoginPage'
import SigninPage from './pages/AuthPages/SigninPage'
import { ROUTES } from './constants'
import './styles/Home.css'
import NavBar from './components/NavBar'
import { useEffect, useState, useCallback } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import Footer from './components/Footer'
import FriendsPage from './pages/FriendsPage'
import VisibilitySensor from 'react-visibility-sensor'

import {
  addMiddleware,
  removeMiddleware,
  resetMiddlewares
} from 'redux-dynamic-middlewares'
import { HubConnectionState } from 'updated-redux-signalr'
import { createChatConnection } from './context/signalr/chatConnection'
import { setConnection } from './context/slices/chat'
import useChatConnection from './hooks/useChatConnection'
import ChatPage from './pages/ChatPage'

function App () {
  const { isOnline } = useChatConnection()
  const [isActive, setIsActive] = useState(true)
  
  useEffect(() => {}, [isOnline, isActive])

  return (
      <BrowserRouter>
        <div className='d-flex flex-column'>
          <ToastContainer position='bottom-center' limit={1} />

          <Container className='main-content App'>
            {isOnline ? <NavBar /> : <></>}
            <main>
              <Routes>
                <Route path={ROUTES.HOME_PAGE} element={<HomePage />} />
                <Route path={ROUTES.LOGIN_PAGE} element={<LoginPage />} />
                <Route path={ROUTES.SIGNIN_PAGE} element={<SigninPage />} />
                <Route path={ROUTES.FRIENDS_PAGE} element={<FriendsPage />} />
                <Route
                  path={`${ROUTES.CHAT_PAGE}/:userid`}
                  element={<ChatPage  />}
                />
              </Routes>
            </main>
          </Container>
        </div>
        <Footer />
      </BrowserRouter>
  )
}

export default App
