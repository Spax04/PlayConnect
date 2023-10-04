import React, { useState } from 'react'
import Container from 'react-bootstrap/esm/Container'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import axios from 'axios'
import './auth.css'
import { useNavigate } from 'react-router-dom'
import { useDispatch, useSelector } from 'react-redux'
import { setUser } from '../../context/slices/user'
import { ROUTES } from '../../constants'

function LoginPage () {
  const navigate = useNavigate()
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const user = useSelector(state => state.user.user)
  const dispatch = useDispatch()

  const onLogin = async e => {
    e.preventDefault()
    await axios
      .post(`${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/auth/login`, {
        email: email,
        password: password
      })
      .then(({ data }) => {
        if (data.isSucceed) {
          
          const user = {
            token: data.token,
            userid: data.userId,
            username: data.username,
            email: data.email
          }
          console.log("From page "+user.userId);
          dispatch(setUser(user))
        }
      })
      .catch(err => console.log(err))

    navigate(ROUTES.HOME_PAGE)
  }

  return (
    <Container className='d-flex justify-content-center align-items-center customeContainer' style={{ minHeight: '100vh' }}>
      <div className='imgDiv'>
        <img
          className='logo'
          alt='logo'
          src={require('../../assets/logo.png')}
        />
      </div>

      <div className=' formDiv'>
        <Form onSubmit={onLogin} className='formStyle'>
          <Form.Group className='mb-3' controlId='email'>
            <Form.Label>Email</Form.Label>
            <Form.Control onChange={e => setEmail(e.target.value)} />
          </Form.Group>

          <Form.Group className='mb-3' controlId='password'>
            <Form.Label>Password</Form.Label>
            <Form.Control onChange={e => setPassword(e.target.value)} />
          </Form.Group>

          <Button type='submit' variant='primary'>
            Login
          </Button>
        </Form>

        <p className='authNavText'>
          Do not have any accaount?{' '}
          <span onClick={() => navigate(ROUTES.SIGNIN_PAGE)} className='authNavLink'>
            Sing up
          </span>{' '}
        </p>
      </div>
    </Container>
  )
}

export default LoginPage
