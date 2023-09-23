import React, { useRef } from 'react';
import { useSockets } from '../context/socket.context';
import EVENTS from '../utils/events';

function Messages() {
  const { state, dispatch } = useSockets();
  const { socket, username, messages, roomId } = state;

  const newMessageRef = useRef(null);

  if (!roomId) {
    return <div />;
  }

  const handleSendMessage = () => {
    const message = newMessageRef.current.value;

    if (!String(message).trim()) {
      return;
    }

    socket.emit(EVENTS.CLIENT.SEND_MESSAGE, { roomId, message, username });
    const date = new Date();
    dispatch({
      type: 'SET_NEW_MESSAGE',
      payload: {
        username: 'You',
        message: message,
        time: `${date.getHours()}:${date.getMinutes()}`,
      },
    });

    newMessageRef.current.value = '';
  };
  return (
    <div>
      {messages.map(({ message }, index) => (
        <p key={index}>{message}</p>
      ))}
      <div>
        <textarea
          rows={1}
          placeholder="Write message here"
          ref={newMessageRef}
        />
        <button onClick={handleSendMessage}>SEND</button>
      </div>
    </div>
  );
}

export default Messages;
