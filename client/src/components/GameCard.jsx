import React,{useEffect, useState} from 'react'
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

import './styles/gameCard.css'


function GameCard({imgBg,title,handleShow,gameId}) {

  const [gameImage,setGameImage] = useState(null);

  const createImage = ()=>{
    const byteCharacters = atob(imgBg);

  // Convert the byte string to a Uint8Array
  const byteNumbers = new Uint8Array(byteCharacters.length);
  for (let i = 0; i < byteCharacters.length; i++) {
    byteNumbers[i] = byteCharacters.charCodeAt(i);
  }

  // Create a Blob object from the Uint8Array
  const byteArray = new Blob([byteNumbers], { type: 'image/jpeg' });

  // Create a data URL
  const imageUrl = URL.createObjectURL(byteArray);
  setGameImage(imageUrl)
  }
  useEffect(()=>{
    createImage();
  })

  return (
    <Card style={{ width: '18rem',margin: '1rem' }}>
    <Card.Body>
    <Card.Img  variant="top" src={gameImage} />

      <Card.Title>{title}</Card.Title>
      <Card.Subtitle className="mb-2 text-muted"></Card.Subtitle>
      <Button className='m-1' variant="primary">Play random</Button>
      <Button className='m-1' variant="success" onClick={handleShow}>Invite friend</Button>
    </Card.Body>
  </Card>
  )
}

export default GameCard