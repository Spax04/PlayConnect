import React from 'react'
import { useParams } from 'react-router-dom'
import { useEffect, useState } from 'react'
import SearchBar from '../components/SearchBar'
import axios from 'axios'
import './styles/friends.css'
import { useDispatch, useSelector } from 'react-redux'
import {
  setFriends,
  setFriendsConnectionStatus
} from '../context/slices/friends'
import { Button } from 'react-bootstrap'
import { COLORS, EVENTS, ROUTES } from '../constants'
import { LiaUserFriendsSolid } from 'react-icons/lia'
import { BsFillPersonPlusFill } from 'react-icons/bs'
import { toast } from 'react-toastify'
import { useNavigate } from 'react-router-dom'
import { Col, Container, Row, Form, InputGroup } from 'react-bootstrap'
import './styles/chat.css'
import Message from '../components/Message'
import { addChat } from '../context/slices/chat'

function ChatPage () {
  const navigate = useNavigate()
  const { userid } = useParams()
  const dispatch = useDispatch()
  const chat = useSelector(state => state.chat)
  const user = useSelector(state => state.user)
  const [messages, setMessages] = useState([])
  const [newMessage, setNewMessage] = useState('')

  //! Check it
  const getChatHistory = async () => {
    let isExist = false
    chat.chats.forEach(c => {
      if (c.chatWith === userid) {
        setMessages(c.message)
        isExist = true
      }
    })

    if (!isExist) {
      await axios
        .get(
          `${process.env.REACT_APP_CHAT_SERVICE_URL}/api/message?chatterId1=${user.userid}&chatterId2=${userid}`
        )
        .then(({ data }) => {
          console.log(data)
          dispatch(addChat({ message: data, chatWith: userid }))
          setMessages(data)
        })
        .catch(err => {
          console.log(err)
        })
    }
  }
  useEffect(() => {
    getChatHistory()
    if (user.token === '') {
      navigate(ROUTES.LOGIN_PAGE)
    }
  }, [chat.chats])

  const sendMessage = () => {
    chat.connection.invoke(EVENTS.CHAT.SERVER.SEND_MESSAGE, {
      senderId: user.userid,
      recipientId: userid,
      newMessage: newMessage
    })
    setNewMessage('')
  }
  return (
    <div className='chatMainBlock'>
      <Col md={9}>
        <div
          style={{
            border: '1px solid #ccc',
            borderRadius: '25px',
            height: '500px',
            overflowY: 'auto',
            padding: '10px',
            backgroundColor: COLORS.white
          }}
        >
          {messages ? (
            messages.map((message, index) => (
              <Message
                key={index}
                sender={message.senderId === user.userid ? 'You' : 'Friend'}
                text={message.newMessage}
                timestamp={message.sentAt}
                isRead={true}
              />
            ))
          ) : (
            <></>
          )}
        </div>

        <Form style={{ marginTop: '10px' }}>
          <Row>
            <Col md={10}>
              <Form.Control
                type='text'
                placeholder='Type your message...'
                value={newMessage}
                onChange={e => setNewMessage(e.target.value)}
              />
            </Col>
            <Col md={2}>
              <Button
                variant='warning'
                className='chatBtn'
                onClick={sendMessage}
              >
                Send
              </Button>
            </Col>
          </Row>
        </Form>
      </Col>
      <Col md={3}>
        <div
          style={{
            marginLeft: '3rem',
            border: '1px solid #ccc',
            borderRadius: '25px',
            height: '400px',
            overflowY: 'auto',
            padding: '10px',
            backgroundColor: COLORS.white
          }}
        ></div>
      </Col>
    </div>
  )
}

export default ChatPage
