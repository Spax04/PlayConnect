import React, { useEffect, useState } from 'react'
import Container from 'react-bootstrap/esm/Container'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import axios from 'axios'
import './auth.css'
import { useNavigate } from 'react-router-dom'
import { useDispatch, useSelector } from 'react-redux'
import { setUser } from '../../context/slices/user'
import { ROUTES } from '../../constants'
import { toast } from 'react-toastify'

function SigninPage () {
  const navigate = useNavigate()
  const [username, setUsername] = useState('')
  const [countries, setCountries] = useState([])

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')
  const [selectedOption, setSelectedOption] = useState('')

  const user = useSelector(state => state.user.user)
  const dispatch = useDispatch()

  useEffect(() => {
    const getCountries = async () => {
      await axios
        .get(`${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/country/`)
        .then(({ data }) => {
          setCountries(data)
        })
        .catch(err => console.log(err))
    }
    getCountries()
  }, [])

  const onSignIn = async e => {
    e.preventDefault()

    if (password != confirmPassword) {
      toast.error('Wrong confirm password', {
        position: 'bottom-center',
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: 'light'
      })
    } else {
      let toastId = toast.loading('Loading please wait...')
      await axios
        .post(
          `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/auth/register`,
          {
            username: username,
            email: email,
            password: password,
            countryId: selectedOption
          }
        )
        .then(({ data }) => {
          if (data.isSucceed) {
            const user = {
              token: data.token,
              userid: data.userId,
              username: data.username,
              email: data.email,
              coins: data.coins,
              country: {
                id: data.country.id,
                code: data.country.code,
                name: data.country.name
              }
            }
            dispatch(setUser(user))
          }
          toast.update(toastId, {
            render: 'All is good',
            type: toast.TYPE.SUCCESS,
            autoClose: 3000,
            closeButton: true,
            isLoading: false
          })

          navigate(ROUTES.HOME_PAGE)
        })
        .catch(err =>
          toast.update(toastId, {
            render: 'Some error',
            type: toast.TYPE.ERROR,
            autoClose: 3000,
            closeButton: true,
            isLoading: false
          })
        )
    }
  }

  const handleSelectChange = event => {
    // Step 3: Update the state variable with the selected option value
    setSelectedOption(event.target.value)
  }

  return (
    <Container
      className='d-flex justify-content-center align-items-center customeContainer'
      style={{ minHeight: '100vh' }}
    >
      <div className='imgDiv'>
        <img
          className='logo'
          alt='logo'
          src={require('../../assets/logo.png')}
        />
      </div>

      <div className='formDiv'>
        <Form onSubmit={onSignIn} className='formStyle'>
          <Form.Group className='mb-3' controlId='username'>
            <Form.Label>Username</Form.Label>
            <Form.Control
              type='text'
              onChange={e => setUsername(e.target.value)}
            />
          </Form.Group>

          <Form.Group className='mb-3' controlId='email'>
            <Form.Label>Email</Form.Label>
            <Form.Control
              type='email'
              onChange={e => setEmail(e.target.value)}
            />
          </Form.Group>

          <Form.Group className='mb-3' controlId='country'>
            <Form.Label>Country</Form.Label>
            <Form.Select value={selectedOption} onChange={handleSelectChange}>
              <option>Select your country</option>
              {countries ? (
                countries.map(country => (
                  <option key={country.id} value={country.id}>
                    {country.name}
                  </option>
                ))
              ) : (
                <></>
              )}
            </Form.Select>
          </Form.Group>
          <Form.Group className='mb-3' controlId='password'>
            <Form.Label>Password</Form.Label>
            <Form.Control
              type='password'
              onChange={e => setPassword(e.target.value)}
            />
          </Form.Group>

          <Form.Group className='mb-3' controlId='confirmPassword'>
            <Form.Label>Confirm password</Form.Label>
            <Form.Control
              type='password'
              onChange={e => setConfirmPassword(e.target.value)}
            />
          </Form.Group>

          <Button type='submit' variant='primary'>
            Sign in
          </Button>
        </Form>

        <p className='authNavText'>
          Already have an account?{' '}
          <span
            onClick={() => navigate(ROUTES.LOGIN_PAGE)}
            className='authNavLink'
          >
            Login
          </span>{' '}
        </p>
      </div>
    </Container>
  )
}

export default SigninPage
