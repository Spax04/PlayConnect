import React, { useState } from 'react'
import Container from 'react-bootstrap/esm/Container'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import axios from 'axios'
import './auth.css'
import { useNavigate } from 'react-router-dom'

function SigninPage () {
  const navigate = useNavigate()
  const [username, setUsername] = useState('')

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const onSignIn = async e => {
    e.preventDefault()
    await axios
      .post(`${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/Auth/register`, {
        username: username,
        email: email,
        password: password
      })
      .then(({ data }) => {
        if (data.isSucceed) {
          console.log(data)
          // REDUX SIGNIN
        }
      })
      .catch(err => console.log(err))
  }

  return (
    <Container className='justify-content-center align-items-center container'>
      <div className='imgDiv'>
        <img
          className='logo'
          alt='logo'
          src={require('../../assets/logo.png')}
        />
      </div>

      <div className=' formDiv'>
        <Form onSubmit={onSignIn} className='formStyle'>
          <Form.Group className='mb-3' controlId='username'>
            <Form.Label>Username</Form.Label>
            <Form.Control onChange={e => setUsername(e.target.value)} />
          </Form.Group>

          <Form.Group className='mb-3' controlId='email'>
            <Form.Label>Email</Form.Label>
            <Form.Control onChange={e => setEmail(e.target.value)} />
          </Form.Group>

          <Form.Group className='mb-3' controlId='password'>
            <Form.Label>Password</Form.Label>
            <Form.Control onChange={e => setPassword(e.target.value)} />
          </Form.Group>

          <Button type='submit' variant='primary'>
            Sign in
          </Button>
        </Form>

        <p className='authNavText'>
          Already have an account?{' '}
          <span onClick={() => navigate('/login')} className='authNavLink'>
            Login
          </span>{' '}
        </p>
      </div>
    </Container>
  )
}

export default SigninPage
