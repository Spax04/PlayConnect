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
  const friends = useSelector(state => state.friends)
  const [messages, setMessages] = useState([])
  const [newMessage, setNewMessage] = useState('')
  const [currentFriend, setCurrentFriend] = useState({})
  const [tabIsActive, setTabIsActive] = useState(true)

  const getFriendById = () => {
    friends.acceptedFriends.forEach(f => {
      if (f.userId === userid) {
        setCurrentFriend(f)
      }
    })
  }
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
          const chatMessages = data.sort(
            (a, b) => new Date(a.sentAt) - new Date(b.sentAt)
          )
          dispatch(addChat({ message: chatMessages, chatWith: userid }))
          setMessages(data)
        })
        .catch(err => {
          console.log(err)
        })
    }
  }

  const checkMessageReceived = async () => {
    let messagesList = []

    messages.forEach(m => {
      if (m.isReceived === false && m.recipientId === user.userid) {
        messagesList = [...messagesList, m.messageeId]
        //  m.isReceived = true
      }
    })
    if (messagesList.length !== 0) {
      document.title = 'PlayConnect'
      messagesList.forEach(m => {
        chat.connection.invoke(EVENTS.CHAT.SERVER.MESSAGE_RECEIVED, {
          senderId: userid,
          receiverId: user.userid,
          messageId: m
        })
      })
      //}
    }
  }

  useEffect(() => {
    const handleFocus = () => {
      setTabIsActive(true)
      console.log('Tab is active')
    }

    const handleBlur = () => {
      setTabIsActive(false)
      console.log('Tab is not active')
    }

    window.addEventListener('focus', handleFocus)
    window.addEventListener('blur', handleBlur)

    return () => {
      window.removeEventListener('focus', handleFocus)
      window.removeEventListener('blur', handleBlur)
    }
  }, [])

  useEffect(() => {
    if (user.token === '') {
      navigate(ROUTES.LOGIN_PAGE)
    }

    getChatHistory()
    getFriendById()
  }, [chat.chats, messages, tabIsActive])

  useEffect(() => {
    if (tabIsActive) {
      checkMessageReceived()
    }
  }, [tabIsActive])

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
                sender={
                  message.senderId === user.userid
                    ? 'You'
                    : currentFriend.username
                }
                text={message.newMessage}
                timestamp={message.sentAt}
                isRead={message.isReceived}
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
