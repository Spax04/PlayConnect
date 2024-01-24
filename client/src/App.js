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
import { useEffect } from 'react'
import Footer from './components/Footer'
import FriendsPage from './pages/FriendsPage'
import useSocketConnection from './hooks/useSocketConnection'
import ChatPage from './pages/ChatPage'
import GameMenuPage from './pages/GamePages/GameMenuPage'
import TicTacToeGamePage from './pages/GamePages/TicTacToeGamePage'

function App () {
  const navigate = useNavigate()
  const { isOnline } = useSocketConnection(navigate)

  useEffect(() => {}, [isOnline])

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
              <Route path={ROUTES.GAMES_PAGE} element={<GameMenuPage />} />
              <Route
                path={`${ROUTES.CHAT_PAGE}/:userid`}
                element={<ChatPage />}
              />
              <Route
                path={`${ROUTES.TIC_TAC_TOE_GAME_PAGE}/:sessionId`}
                element={<TicTacToeGamePage />}
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
