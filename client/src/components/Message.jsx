import React from 'react'
import { Card, Badge } from 'react-bootstrap'

const Message = ({ text, sender, timestamp, isRead }) => {
  const isMyMessage = sender === 'You'

  return (
    <Card
      style={{
        width: 'fit-content',
        maxWidth: '400px',
        marginTop: '13px',
        marginBottom:'13px',
        marginLeft: isMyMessage ? 'auto' : '13px',
        marginRight: isMyMessage ? '13px' : 'auto',
        backgroundColor: isMyMessage ? '#a5ffd6' : '#ffa69e'
      }}
    >
      <Card.Body>
        <h6 className='mb-0'>
          <Badge bg={isMyMessage ? 'success' : 'primary'}>{sender}</Badge>
        </h6>
        <Card.Text>{text}</Card.Text>
        <Card.Text
          className={`text-muted ${isMyMessage ? 'text-right' : 'text-left'}`}
          style={{ fontSize: '12px' }}
        >
          {new Date(timestamp).toLocaleTimeString()}{' '}
          {isMyMessage ? isRead ? '(Read)' : '(Unread)' : <></>}
        </Card.Text>
      </Card.Body>
    </Card>
  )
}

export default Message
