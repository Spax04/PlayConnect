import React from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import Nav from 'react-bootstrap/Nav'
import NavDropdown from 'react-bootstrap/NavDropdown'
import './styles/navbar.css'
import { BsFillPersonFill } from 'react-icons/bs'
import { COLORS, ROUTES } from '../constants'
import { removeUser } from '../context/slices/user'
import { useDispatch } from 'react-redux'
function NavBar () {
  const navigate = useNavigate()
  const profile = <BsFillPersonFill size='2rem' color={COLORS.dark} />
  const dispatch = useDispatch()

  const logout = () => {
    dispatch(removeUser())
  }

  return (
    <div>
      <Nav
        className='navBar justify-content-between'
        variant='pills'
        activeKey='1'
      >
        <div className='logoDiv' onClick={()=>navigate(ROUTES.HOME_PAGE)}>
          <img  
            className='logo'
            alt='logo'
            src={require('../assets/logo.png')}
           
          />
        </div>
        <div className='navLinks d-flex'>
          <Nav.Item>
            <Nav.Link className='navLink' eventKey='2' title='Games'>
              Games
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link className='navLink' eventKey='2' title='Leaderboard'>
              Leaderboard
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link className='navLink' eventKey='2' title='Friends' href={ROUTES.FRIENDS_PAGE}>
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
