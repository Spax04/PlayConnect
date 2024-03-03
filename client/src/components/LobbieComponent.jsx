import React, { useEffect, useState } from 'react'
import { blobToURL } from '../utils/blobToURL'
import { useSelector } from 'react-redux'
import { Button, Card } from 'react-bootstrap'
import { Col, Row } from 'react-bootstrap'
import { PiChatCircleTextBold } from 'react-icons/pi'
import { ImDice } from 'react-icons/im'
import { RiDeleteBin2Line } from 'react-icons/ri'
import { AiOutlineUserAdd } from 'react-icons/ai'
import { COLORS, ROUTES } from '../constants'
import ReactCountryFlag from 'react-country-flag'
import axios from 'axios'
import { useNavigate } from 'react-router-dom'
import Spinner from 'react-bootstrap/Spinner'
import './styles/lobbyComponent.css'
import { LuGamepad2 } from 'react-icons/lu'

const LobbyComponent = ({ lobby }) => {
  const [gameImage, setGameImage] = useState(null)
  const [gameName, setGameName] = useState(null)
  const [loading, setLoading] = useState(true) // State to track loading status
  const game = useSelector(state => state.game)

  useEffect(() => {
    const getGameData = () => {
      return new Promise((resolve, reject) => {
        const gameType = game.gameTypes.find(g => g.id === lobby.gameTypeId)
        if (gameType) {
          resolve(gameType)
        } else {
          reject(new Error('Game type not found'))
        }
      })
    }

    const createImage = () => {
      getGameData()
        .then(gameType => {
          setGameName(gameType.name)
          return blobToURL(gameType.image)
        })
        .then(imgUrl => {
          setGameImage(imgUrl)
          setLoading(false)
        })
        .catch(error => {
          console.error('Error fetching game data:', error)
          setLoading(false)
        })
    }
    createImage()
  }, [lobby.gameTypeId]) // Trigger effect when lobby.gameTypeId changes

  useEffect(() => {}, [])

  return (
    <div className='gameLobbyMainBlock'>
      {loading ? (
        <Spinner animation='border' role='status'></Spinner>
      ) : (
        <Row className='p-3'>
          <Col className='imgCol'>
            <div>
              <h3 className='nameText'>{gameName}</h3>
              <div className='gameImgDiv'>
                <img alt='gameImage' className='gameImage' src={gameImage} />
              </div>{' '}
            </div>
          </Col>
          <Col>
            <Row>
              <div className='d-flex'>
                <ReactCountryFlag
                  svg
                  countryCode={lobby.countryCode}
                  style={{
                    width: '2em',
                    height: '2em',
                    marginRight: '0.5rem'
                  }}
                />
                <h6 className='hostName'>
                  {' '}
                  {lobby.hostName} <span id='hostLevel'>{lobby.hostLvl}</span>
                </h6>
              </div>
            </Row>
          </Col>
          <Col className='d-flex align-items-center justify-content-center'>
            <Button
              variant='warning'
              style={{ fontSize: '1.3rem', fontWeight: '600' }}
            >
              {
                <LuGamepad2
                  style={{ fontSize: '1.5rem', paddingRight: '6px' }}
                />
              }
              Join
            </Button>
          </Col>
        </Row>
      )}
    </div>
  )
}

export default LobbyComponent
