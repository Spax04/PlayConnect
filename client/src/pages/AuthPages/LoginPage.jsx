import React,{useState} from 'react'
import Container from 'react-bootstrap/esm/Container'
import Form from 'react-bootstrap/Form';
import './auth.css';


function LoginPage() {

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const onLogin = ()=>{

  }

  return (
    <Container className='small-container formDiv'>

      <Form onSubmit={onLogin}>
        <Form.Group className='mb-3' controlId='email'>
          <Form.Label>
            Email
          </Form.Label>
          <Form.Control onChange={e => setEmail(e.target.value)}/>
        </Form.Group>

        <Form.Group className='mb-3' controlId='password'>
          <Form.Label>
            Password
          </Form.Label>
          <Form.Control onChange={e => setPassword(e.target.value)}/>
        </Form.Group>
      </Form>
    </Container>
  )
}

export default LoginPage