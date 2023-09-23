import React, { useRef } from 'react';
import { useSockets } from '../context/socket.context';
import EVENTS from '../utils/events';

function Rooms() {
  const { state, dispatch } = useSockets();

  const { socket, roomId, rooms } = state;

  const newRoomName = useRef(null);

  const handleCreateRoom = () => {
    const roomName = newRoomName.current.value || '';

    if (!String(roomName).trim()) return;

    socket.emit(EVENTS.CLIENT.CREATE_ROOM, { roomName });

    newRoomName.current.value = '';
  };

  const handleJoinRoom = (key) => {
    if (key === roomId) return;

    socket.emit(EVENTS.CLIENT.JOIN_ROOM, key);
  };
  return (
    <nav>
      <div>
        <input ref={newRoomName} plaseholder="Room name" />
        <button onClick={handleCreateRoom}>Create room</button>
      </div>

      {Object.keys(rooms).map((key) => {
        return (
          <div key={key}>
            <button
              disabled={key === roomId}
              title={`Join ${rooms[key].name} room`}
              onClick={() => handleJoinRoom(key)}
            >
              {rooms[key].name}
            </button>
          </div>
        );
      })}
    </nav>
  );
}

export default Rooms;
