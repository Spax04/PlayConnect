import React from 'react';
import { Card } from 'react-bootstrap';

const Message = ({ text, sender, timestamp, isRead }) => {
  const isMyMessage = sender === 'me';

  return (
    <Card
      style={{
        width: 'fit-content',
        marginLeft: isMyMessage ? 'auto' : '0',
        marginRight: isMyMessage ? '0' : 'auto',
      }}
    >
      <Card.Body>
        <Card.Text>{text}</Card.Text>
        <Card.Text
          className={`text-muted ${isMyMessage ? 'text-right' : 'text-left'}`}
          style={{ fontSize: '12px' }}
        >
          {new Date(timestamp).toLocaleTimeString()} {isRead ? '(Read)' : '(Unread)'}
        </Card.Text>
      </Card.Body>
    </Card>
  );
};

export default Message;