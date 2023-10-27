import React, { useEffect, useState } from 'react'
import './styles/friendData.css'
import { Col, Row } from 'react-bootstrap'
import { PiChatCircleTextBold } from 'react-icons/pi'
import { ImDice } from 'react-icons/im'
import { RiDeleteBin2Line } from 'react-icons/ri'
import { AiOutlineUserAdd } from 'react-icons/ai'
import { COLORS, ROUTES } from '../constants'
import ReactCountryFlag from 'react-country-flag'
import axios from 'axios'
import { useSelector } from 'react-redux'
import { useNavigate } from 'react-router-dom'

function FriendData ({
  userid,
  username,
  isConnected,
  countryCode,
  favoriteGame,
  isFriend,
  isPendingList,
  getFriends,
  isRequested
}) {
  const navigate = useNavigate()
  const user = useSelector(state => state.user)
  const [requestState, setRequestState] = useState(isRequested)
  const { connection } = useSelector(state => state.chat)

  const onFriendshipRequest = async () => {
    await axios
      .post(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/add`,
        { userId1: user.userid, userId2: userid }
      )
      .then(({ data }) => {
        if (data.isSucceed) {
          getFriends()
          console.log('Friend request sended')
        }
      })
      .catch(err => console.log(err))
    connection.invoke('GetFriends', userid)
    setRequestState(true)
  }
  const onFriendshipDelete = async () => {
    await axios
      .delete(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${user.userid}/${userid}`
      )
      .then(({ data }) => {
        if (data.isSucceed) {
          getFriends()
        }
      })
      .catch(err => console.log(err))
    connection.invoke('GetFriends', userid)
  }

  const onAcceptRequest = async () => {
    await axios
      .post(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/accept`,
        { userId1: user.userid, userId2: userid }
      )
      .then(({ data }) => {
        if (data) {
          getFriends()
        }
      })
      .catch(err => console.log(err))
    connection.invoke('GetFriends', userid)
  }

  return (
    <div className='friendMainBlock'>
      <Row className='p-3'>
        <Col className='btnCol'>
          <div className='userImgDiv'>
            <img
              alt='user'
              className='userImg'
              src={'https://static.thenounproject.com/png/642902-200.png'}
            />
          </div>
          <div className='d-flex'>
            <ReactCountryFlag
              svg
              countryCode={countryCode}
              style={{
                width: '2em',
                height: '2em',
                marginRight: '0.5rem'
              }}
            />
            <h3 className='nameText'>{username}</h3>
          </div>
          {isFriend ? (
            <h5
              className='nameText'
              style={
                isConnected
                  ? { color: COLORS.darkGreen }
                  : { color: COLORS.red }
              }
            >
              {isConnected ? 'Online' : 'Offline'}
            </h5>
          ) : (
            <></>
          )}
        </Col>
        <Col>
          <Row>
            <h6>Favourite game: {favoriteGame} </h6>
            <p>Win-Lose ratio: 1.5</p>
          </Row>
          <Row>
            <h6>Reacent game: </h6>
            <p>Tic-Tac-Toe : Win</p>
          </Row>
          <Row className='mt-5'>
            <h6>You are friends since: 1.1.2000</h6>
          </Row>
        </Col>
        <Col className='btnCol'>
          {isFriend ? (
            <>
              <button
                className='interactBtn'
                style={{ backgroundColor: COLORS.yellow }}
                onClick={() =>
                  navigate(ROUTES.CHAT_PAGE, { chatterId: userid })
                }
              >
                <PiChatCircleTextBold className='icnoStyle' />
                Message
              </button>
              <button
                className='interactBtn'
                style={{ backgroundColor: COLORS.green }}
              >
                <ImDice className='icnoStyle' />
                Invite to Game
              </button>
              <button
                className='interactBtn'
                style={{ backgroundColor: COLORS.red }}
                onClick={onFriendshipDelete}
              >
                <RiDeleteBin2Line className='icnoStyle' />
                Remove
              </button>
            </>
          ) : isPendingList ? (
            <button
              className='interactBtn'
              style={{ backgroundColor: COLORS.darkGreen }}
              onClick={onAcceptRequest}
            >
              <AiOutlineUserAdd className='icnoStyle' />
              Accept
            </button>
          ) : requestState ? (
            <button
              className='interactBtn'
              style={{ backgroundColor: COLORS.dark, color: COLORS.white }}
              disabled={true}
            >
              <AiOutlineUserAdd className='icnoStyle' />
              Requested
            </button>
          ) : (
            <button
              className='interactBtn'
              style={{ backgroundColor: COLORS.darkGreen }}
              onClick={onFriendshipRequest}
            >
              <AiOutlineUserAdd className='icnoStyle' />
              Add
            </button>
          )}
        </Col>
      </Row>
    </div>
  )
}

export default FriendData
