import React from 'react';
import { Card,Badge } from 'react-bootstrap';

const Message = ({ text, sender, timestamp, isRead }) => {
  const isMyMessage = sender === 'You';

  return (
    <Card
      style={{
        width: 'fit-content',
        marginLeft: isMyMessage ? 'auto' : '0',
        marginRight: isMyMessage ? '0' : 'auto',
        backgroundColor: isMyMessage ? "#5A95E6" : "#B5DDA4"
      }}
    >
      <Card.Body>
          <h6 className="mb-0">
          <Badge bg={isMyMessage? "success" : "primary"}>{sender}</Badge>
          </h6>
        <Card.Text>
          {text}
        </Card.Text>
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