import React from 'react'
import './styles/friendData.css'
import { Col, Row } from 'react-bootstrap'
import { PiChatCircleTextBold } from 'react-icons/pi'
import { ImDice } from 'react-icons/im'
import { RiDeleteBin2Line } from 'react-icons/ri'
import {AiOutlineUserAdd} from 'react-icons/ai'
import { COLORS } from '../constants'
import ReactCountryFlag from 'react-country-flag'

function FriendData ({
  username,
  isOnline,
  countryCode,
  favoriteGame,
  isFriend
}) {
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
          {isFriend ? (<>
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
          ) : (
            <button
              className='interactBtn'
              style={{ backgroundColor: COLORS.darkGreen }}
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
