import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { Scrollbar } from 'react-scrollbars-custom'
import Message from '../components/Message' // You may need to adjust the path
import { useDispatch, useSelector } from 'react-redux'
import { addChat } from '../context/slices/chat' // You may need to adjust the path
import { EVENTS } from '../constants' // You may need to adjust the path
import axios from 'axios' // You may need to adjust the path
import './styles/inGameChat.css'

function InGameChat () {
  const dispatch = useDispatch()
  const user = useSelector(state => state.user)
  const game = useSelector(state => state.game)
  const chat = useSelector(state => state.chat)

  const [messages, setMessages] = useState([])
  const [newMessage, setNewMessage] = useState('')

  useEffect(() => {
    setMessages(chat.currentGroupChat)
  }, [chat.currentGroupChat])



  const sendMessage = a => {
    a.preventDefault()
    chat.connection.invoke(EVENTS.CHAT.SERVER.SEND_GROUP_MESSAGE, {
      gameSessionId: game.currentSession.sessionId,
      senderId: user.userId,
      senderName: user.username,
      message: newMessage
    })
    setNewMessage('')
  }

  return (
    <div className='in-game-chat'>
      <Scrollbar style={{ height: '300px', width: '100%' }}>
        {messages.map((m, index) => (
          <p>{`${m.senderName}: ${m.message}`}</p>
        ))}
      </Scrollbar>
      <Form onSubmit={sendMessage}>
        <Row>
          <Col md={9}>
            <Form.Control
              type='text'
              placeholder='Type your message...'
              value={newMessage}
              onChange={e => setNewMessage(e.target.value)}
            />
          </Col>
          <Col md={3}>
            <Button variant='primary' type='submit'>
              Send
            </Button>
          </Col>
        </Row>
      </Form>
    </div>
  )
}

export default InGameChat
