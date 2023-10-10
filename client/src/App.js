import './App.css'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import Container from 'react-bootstrap/Container'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import HomePage from './pages/HomePage'
import LoginPage from './pages/AuthPages/LoginPage'
import SigninPage from './pages/AuthPages/SigninPage'
import { ROUTES } from './constants'
import './styles/Home.css'
import NavBar from './components/NavBar'
import { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import Footer from './components/Footer'
import FriendsPage from './pages/FriendsPage'
import { setConnection } from './context/slices/chat'
import useChatConnection from './hooks/useChatConnection'

const emojiSupport = require('detect-emoji-support')

function App () {
  const [isSIgnedIn, setIsSignedIn] = useState(false)
  const user = useSelector(state => state.user)
  const dispatch = useDispatch()
  const chatConnection = useSelector(state => state.chat)
  const { connection } = useChatConnection()

  useEffect(() => {
    if (user.token) {
      setIsSignedIn(true)
      if (connection) {
        dispatch(setConnection(connection))
      }
    } else {
      setIsSignedIn(false)
    }
    console.log(user)
  }, [dispatch, user, connection])

  return (
    <BrowserRouter>
      <div className='d-flex flex-column'>
        <ToastContainer position='bottom-center' limit={1} />

        <Container className='main-content App'>
          {isSIgnedIn ? <NavBar /> : <></>}
          <main>
            <Routes>
              <Route path={ROUTES.HOME_PAGE} element={<HomePage />} />
              <Route path={ROUTES.LOGIN_PAGE} element={<LoginPage />} />
              <Route path={ROUTES.SIGNIN_PAGE} element={<SigninPage />} />
              <Route path={ROUTES.FRIENDS_PAGE} element={<FriendsPage />} />
            </Routes>
          </main>
        </Container>
      </div>
      <Footer />
    </BrowserRouter>
  )
}

export default App
