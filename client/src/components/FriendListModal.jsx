import React, { useEffect, useState } from 'react'
import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { useDispatch, useSelector } from 'react-redux'
import './styles/friendListModal.css'
import { EVENTS } from '../constants'

function FriendListModal ({ show, handleClose, currentGameTypeId }) {
  const [friendList, setFriendList] = useState([])
  const friends = useSelector(state => state.friends)
  const game = useSelector(state => state.game)
  const user = useSelector(state => state.user)

  const inviteFriendToGame = friendId => {

    const inviteRequest = {
      hostId: user.userid,
      guestId: friendId,
      gameTypeId: currentGameTypeId
    }

    console.log(inviteRequest);
    game.connection.invoke(EVENTS.GAME.SERVER.INVITE_FRIEND_TO_GAME,inviteRequest)
  }

  useEffect(() => {
    setFriendList(friends.acceptedFriends)
  }, [])

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Friends list</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {friendList.map(f => (
          <div key={f.userId} className='userBlock'>
            <div>
              <h5>{f.username}</h5>
              <p>{f.isConnected ? 'Online' : 'Offline'}</p>
            </div>
            <Button onClick={() => inviteFriendToGame(f.userId)}>Invite</Button>
          </div>
        ))}
      </Modal.Body>
    </Modal>
  )
}

export default FriendListModal
