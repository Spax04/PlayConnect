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

  // const blobToURL = (imageBg) => {
  //   const promise = new Promise(async resolve => {
  //     const byteCharacters = atob(imageBg)

  //     // Convert the byte string to a Uint8Array
  //     const byteNumbers = new Uint8Array(byteCharacters.length)
  //     for (let i = 0; i < byteCharacters.length; i++) {
  //       byteNumbers[i] = byteCharacters.charCodeAt(i)
  //     }

  //     // Create a Blob object from the Uint8Array
  //     const byteArray = new Blob([byteNumbers], { type: 'image/jpeg' })

  //     // Create a data URL
  //     const imageUrl = URL.createObjectURL(byteArray)
  //     resolve(imageUrl)
  //   })

  //   return promise
  // }

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

        <Card.Title>{title}</Card.Title>
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
