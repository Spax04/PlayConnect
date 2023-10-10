import React from 'react'
import './styles/friendData.css'
import { Col, Row } from 'react-bootstrap'
import { PiChatCircleTextBold } from 'react-icons/pi'
import { ImDice } from 'react-icons/im'
import { RiDeleteBin2Line } from 'react-icons/ri'
import { AiOutlineUserAdd } from 'react-icons/ai'
import { COLORS } from '../constants'
import ReactCountryFlag from 'react-country-flag'
import axios from 'axios'
import { useSelector } from 'react-redux'

function FriendData ({
  userid,
  username,
  isOnline,
  countryCode,
  favoriteGame,
  isFriend,
  isPendingList,
  getFriends
}) {
  const user = useSelector(state => state.user)
  const friends = useSelector(state => state.friends)
  
  const onFriendshipRequest = async () => {}

  const onAcceptRequest = async () => {
   
    await axios
      .post(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/accept`,
        { userId1: user.userid, userId2: userid }
      )
      .then(({ data }) => {
        if(data){
          getFriends()
        }
      })
      .catch(err => console.log(err))
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
          <h5
            className='nameText'
            style={
              isOnline ? { color: COLORS.darkGreen } : { color: COLORS.red }
            }
          >
            {isOnline ? 'Online' : 'Offline'}
          </h5>
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
