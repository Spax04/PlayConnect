import React from 'react'
import { useParams } from 'react-router-dom'
import { useEffect, useState } from 'react'
import SearchBar from '../components/SearchBar'
import axios from 'axios'
import './styles/friends.css'
import FriendData from '../components/FriendData'
import { useDispatch, useSelector } from 'react-redux'
import {
  setFriends,
  setFriendsConnectionStatus
} from '../context/slices/friends'
import { Button } from 'react-bootstrap'
import { COLORS, ROUTES } from '../constants'
import { LiaUserFriendsSolid } from 'react-icons/lia'
import { BsFillPersonPlusFill } from 'react-icons/bs'
import { toast } from 'react-toastify'
import { useNavigate } from 'react-router-dom'
import { Col, Container, Row, Form, InputGroup } from 'react-bootstrap'
import './styles/chat.css'
import Message from '../components/Message'

function ChatPage () {
  const { chatterId } = useParams()

  const [messages, setMessages] = useState([])
  const [newMessage, setNewMessage] = useState('')

  const handleSendMessage = () => {
    if (newMessage) {
      setMessages([...messages, newMessage])
      setNewMessage('')
    }
  }

  return (
    // <Container>
    //   <Col md={2}>
    //     <div className='contacts'></div>
    //   </Col>
    //   <Col md={10}>
    //     <Row md={8}>
    //       <div className='chat-block'></div>
    //     </Row>
    //     <Row md={2}></Row>
    //   </Col>
    // </Container>
      <div className='chatMainBlock'>
          <Col md={9}>
            <div
              style={{
                
                border: '1px solid #ccc',
                borderRadius:'25px',
                height: '500px',
                overflowY: 'auto',
                padding: '10px',
                backgroundColor:COLORS.white
              }}
            >
              {/* {messages.map((message, index) => (
                <div key={index}>{message}</div>
              ))} */}

              <Message sender={"me"} text={"Hello"} timestamp={"11.11.2011"} isRead={true}/>
              <Message sender={"danik"} text={"How ar you"} timestamp={"11.11.2011"} isRead={true}/>

              <Message sender={"danik"} text={"Glead to see you"} timestamp={"11.11.2011"} isRead={true}/>

              <Message sender={"me"} text={"Hello"} timestamp={"11.11.2011"} isRead={true}/>
              <Message sender={"me"} text={"Hello"} timestamp={"11.11.2011"} isRead={true}/>
              <Message sender={"me"} text={"Hello"} timestamp={"11.11.2011"} isRead={true}/>
              <Message sender={"me"} text={"Hello"} timestamp={"11.11.2011"} isRead={true}/>
              <Message sender={"me"} text={"Hello"} timestamp={"11.11.2011"} isRead={true}/>


            </div>

            <Form style={{ marginTop: '10px' }}>
              <Row>
                <Col md={10}>
                  <Form.Control
                 
                    type='text'
                    placeholder='Type your message...'
                    value={newMessage}
                    onChange={e => setNewMessage(e.target.value)}cx34
                  />
                </Col>
                <Col md={2}>
                  <Button variant='warning' className='chatBtn'  onClick={handleSendMessage}>
                    Send
                  </Button>
                </Col>
              </Row>
            </Form>
          </Col>
          <Col md={3}>
          <div
              style={{
                marginLeft:'3rem',
                border: '1px solid #ccc',
                borderRadius:'25px',
                height: '400px',
                overflowY: 'auto',
                padding: '10px',
                backgroundColor:COLORS.white
              }}
            >
              
            </div>
          </Col>
      </div>
  )
}

export default ChatPage
