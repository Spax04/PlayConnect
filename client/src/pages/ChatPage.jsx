import React from 'react'
import { useParams } from 'react-router-dom'
import { useEffect, useState, useRef } from 'react'
import axios from 'axios'
import './styles/friends.css'
import { useDispatch, useSelector } from 'react-redux'
import { Button } from 'react-bootstrap'
import { COLORS, EVENTS, ROUTES } from '../constants'
import { useNavigate } from 'react-router-dom'
import { Col, Row, Form } from 'react-bootstrap'
import './styles/chat.css'
import Message from '../components/Message'
import { addChat } from '../context/slices/chat'
import { Scrollbar } from 'react-scrollbars-custom'

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


  useEffect(() => {
    const handleFocus = () => {
      setTabIsActive(true)
      console.log("tab active");
    }

    const handleBlur = () => {
      setTabIsActive(false)
            console.log("tab is not active");

    }

    window.addEventListener('focus', handleFocus)
    window.addEventListener('blur', handleBlur)

    return () => {
      window.removeEventListener('focus', handleFocus)
      window.removeEventListener('blur', handleBlur)
    }
  }, [])
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

    
console.log("Tying to check for unreaded messages");
    let messagesList = []
   
    messages.forEach(m => {
      if (m.isReceived === false && m.recipientId === user.userid) {
        messagesList = [...messagesList, m.messageeId]
      }
    })
    console.log(messagesList);
    if (messagesList.length !== 0) {
      document.title = 'PlayConnect'
      messagesList.forEach(m => {
        chat.connection.invoke(EVENTS.CHAT.SERVER.MESSAGE_RECEIVED, {
          senderId: userid,
          receiverId: user.userid,
          messageId: m
        })
      })
    }
  }

  useEffect(() => {
    if (user.token === '') {
      navigate(ROUTES.LOGIN_PAGE)
    }

    getChatHistory()
    getFriendById()
    console.log("Now the tab is  activ in useEffect" );
    if (tabIsActive) {
      
      checkMessageReceived()
    }
    scrollToBottom()
  }, [chat.chats, messages, tabIsActive])

  const sendMessage = () => {
    chat.connection.invoke(EVENTS.CHAT.SERVER.SEND_MESSAGE, {
      senderId: user.userid,
      recipientId: userid,
      newMessage: newMessage
    })
    setNewMessage('')
  }

  

  const handleKeyDown = e => {
    if (e.key === 'Enter') {
      e.preventDefault() // Prevent the default behavior (e.g., line break in the input field)
      sendMessage()
    }
  }

  const messagesContainerRef = useRef()

  const scrollToBottom = () => {
    const scrollHeight = messagesContainerRef.current.scrollHeight;

    // Set the scrollTop to the maximum possible value to scroll to the end
    messagesContainerRef.current.scrollTop = scrollHeight;
  }
  return (
    <div className='chatMainBlock'>
      <Col md={9}>
        <Scrollbar
          style={{
            border: '1px solid #ccc',
            borderRadius: '25px',
            height: '500px',
            overflowY: 'auto',
            padding: '10px',
            backgroundColor: COLORS.white
          }}
          ref={messagesContainerRef}
        >
          <div >
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
        </Scrollbar>
        <Form style={{ marginTop: '10px' }}>
          <Row>
            <Col md={10}>
              <Form.Control
                type='text'
                placeholder='Type your message...'
                value={newMessage}
                onChange={e => setNewMessage(e.target.value)}
                onKeyDown={handleKeyDown}
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
