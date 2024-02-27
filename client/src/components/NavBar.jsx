import React, { useEffect, useState } from 'react'
import { Link, useLocation, useNavigate } from 'react-router-dom'
import { Button, Container } from 'react-bootstrap'
import Nav from 'react-bootstrap/Nav'
import NavDropdown from 'react-bootstrap/NavDropdown'
import './styles/navbar.css'
import { BsFillPersonFill } from 'react-icons/bs'
import { COLORS, ROUTES } from '../constants'
import { removeUser } from '../context/slices/user'
import { removeFriends } from '../context/slices/friends'
import { useDispatch, useSelector } from 'react-redux'
import { IoNotifications } from 'react-icons/io5'

function NavBar () {
  const navigate = useNavigate()
  const dispatch = useDispatch()

  const [inGame, setInGame] = useState(false)
  const [reconnected, setReconnected] = useState(false)
  const [gamePath, setGamePath] = useState('')
  const chat = useSelector(state => state.chat)
  const user = useSelector(state => state.user)
  const game = useSelector(state => state.game)

  const location = useLocation()

  const profile = (
    <>
      <BsFillPersonFill size='2rem' color={COLORS.dark} /> {user.username}
    </>
  )
  const logout = () => {
    dispatch(removeUser())
    dispatch(removeFriends())
  }

  const detachGameRoute =  () => {
    if (game.gameTypes.length !== 0) {
      const gameTypes = game.gameTypes

      let gameName = null
      let gameRoute = null
      gameTypes.forEach(g => {
        if (game.currentSession.gameTypeId === g.id) {
          gameName = g.name.replace(/ /g, '').toLowerCase()
          switch (gameName) {
            case 'tictactoe':
              gameRoute = ROUTES.GAMES.TIC_TAC_TOE_GAME_PAGE
              return
            case 'battleship':
              gameRoute = ROUTES.GAMES.BATTLESHIP_GAME_PAGE
              return
            case 'checkers':
              gameRoute = ROUTES.GAMES.CHECKERS_GAME_PAGE
              return
            default:
              break
          }
        }
      })
      if (gameName == null || gameRoute == null) {
        return null
      }
      return `${gameRoute}/${game.currentSession.sessionId}`
    }
  }
  useEffect(() => {
    console.log(game.currentSession);
    if (game.currentSession.sessionId !== null) {
      setInGame(true)
    } else {
      setInGame(false)
    }

    const currentGamePath =  detachGameRoute()
    if (
      game.currentSession.sessionId !== null &&
      currentGamePath !== location.pathname
    ) {
      setGamePath(currentGamePath)
      setReconnected(true)
    }else if (currentGamePath === location.pathname){
      setReconnected(false)
    }
  }, [game.currentSession.sessionId, game.gameTypes,location.pathname])

  const comeBackToGame = () => {
    setReconnected(false)
    console.log(gamePath);
    navigate(gamePath)
  }

  return (
    <div>
      <Nav
        className='navBar justify-content-between'
        variant='pills'
        activeKey='1'
      >
        <div className='logoDiv' onClick={() => navigate(ROUTES.HOME_PAGE)}>
          <img
            className='logo'
            alt='logo'
            src={require('../assets/logo.png')}
          />
        </div>
        {inGame && reconnected ? (
          <Button onClick={comeBackToGame}>Come back to game</Button>
        ) : (
          <></>
        )}
        <div className='navLinks d-flex'>
          <Nav.Item>
            <Nav.Link
              className='navLink'
              eventKey='2'
              title='Games'
              onClick={() => navigate(ROUTES.GAMES_PAGE)}
            >
              Games
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link className='navLink' eventKey='2' title='Leaderboard'>
              Leaderboard
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link
              className='navLink'
              eventKey='2'
              title='Friends'
              onClick={() => navigate(ROUTES.FRIENDS_PAGE)}
            >
              Friends
            </Nav.Link>
          </Nav.Item>
          <div className='d-flex'>
            <NavDropdown title={profile} id='user-dropdown'>
              <NavDropdown.Item eventKey='4.1'>Profile</NavDropdown.Item>
              <NavDropdown.Item eventKey='4.2'>Settings</NavDropdown.Item>
              <NavDropdown.Item eventKey='4.3'>
                Feedback/Support
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item eventKey='4.4' onClick={logout}>
                Logout
              </NavDropdown.Item>
            </NavDropdown>
          </div>
        </div>
      </Nav>
    </div>
  )
}

export default NavBar
