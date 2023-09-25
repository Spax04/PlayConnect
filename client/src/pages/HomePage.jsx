import React, { useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import Nav from 'react-bootstrap/Nav'
import NavDropdown from 'react-bootstrap/NavDropdown'
import './home.css'
import { BsFillPersonFill } from 'react-icons/bs'
import { COLORS } from '../constants'

function HomePage () {
  const navigate = useNavigate()
  useEffect(() => {
    if (!localStorage.getItem('user')) {
      navigate('/login')
    }
  }, [])
  return (
    <Container className='container'>
      <Nav
        className='navBar justify-content-between'
        variant='pills'
        activeKey='1'
      >
        <div className='logoDiv'>
          <img
            className='logo'
            alt='logo'
            src={require('../assets/logo.png')}
          />
        </div>
        <div className='navLinks d-flex'>
          <Nav.Item>
            <Nav.Link eventKey='2' title='Item'>
              Games
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link eventKey='2' title='Item'>
              Leaderboard
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link eventKey='2' title='Item'>
              Friends
            </Nav.Link>
          </Nav.Item>
          <div className='d-flex'>
          <BsFillPersonFill size='2.3rem' color={COLORS.dark}/>
            <NavDropdown id='nav-dropdown'>
              <NavDropdown.Item eventKey='4.1'>Profile</NavDropdown.Item>
              <NavDropdown.Item eventKey='4.2'>Settings</NavDropdown.Item>
              <NavDropdown.Item eventKey='4.3'>
                Feedback/Support
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item eventKey='4.4'>Logout</NavDropdown.Item>
            </NavDropdown>
          </div>
        </div>
      </Nav>
    </Container>
  )
}

export default HomePage
