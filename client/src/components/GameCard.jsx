import React, { useEffect, useState } from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Spinner from 'react-bootstrap/Spinner'
import {blobToURL} from '../utils/blobToURL'
import './styles/gameCard.css'

function GameCard ({
  imgBg,
  title,
  handleShow,
  gameTypeId,
  setCurrentGameTypeId
}) {
  const [gameImage, setGameImage] = useState(null)

  const openFriendsList = () => {
    handleShow()
    setCurrentGameTypeId(gameTypeId)
  }

  

  useEffect(() => {
    const createImage = async () => {
      const imgUrl = await blobToURL(imgBg)
      setGameImage(imgUrl)
    }
    createImage()
  }, [gameImage])

  return (
    <Card style={{ width: '18rem', margin: '1rem' }}>
      <Card.Body>
        {gameImage ? (
          <Card.Img variant='top' src={gameImage} />
        ):  (
          <Spinner animation='border' role='status'>
            <span className='visually-hidden'>Loading...</span>
          </Spinner>
        )}

        <Card.Title className='gameTitle'>{title}</Card.Title>
        <Card.Subtitle className='mb-2 text-muted'></Card.Subtitle>
        <Button className='m-1' variant='primary'>
          Play random
        </Button>
        <Button className='m-1' variant='success' onClick={openFriendsList}>
          Invite friend
        </Button>
        
      </Card.Body>
    </Card>
  )
}

export default GameCard
