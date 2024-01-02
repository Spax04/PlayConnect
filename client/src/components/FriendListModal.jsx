import React, { useEffect, useState } from 'react'
import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { useDispatch, useSelector } from 'react-redux'
import './styles/friendListModal.css'

function FriendListModal ({ show, handleClose }) {
  const [friendList, setFriendList] = useState([])
  const friends = useSelector(state => state.friends)

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
          <div className='userBlock'>
            <div>
              <h5>{f.username}</h5>
              <p>{f.isConnected ? 'Online' : 'Offline'}</p>
            </div>
            <Button>Invite</Button>
          </div>
        ))}
      </Modal.Body>
    </Modal>
  )
}

export default FriendListModal
