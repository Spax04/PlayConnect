import React from 'react'
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

import './styles/gameCard.css'


function GameCard({imgBg,title,description,handleShow}) {
  return (
    <Card style={{ width: '18rem',margin: '1rem' }}>
    <Card.Body>
    <Card.Img  variant="top" src={imgBg} />

      <Card.Title>{title}</Card.Title>
      <Card.Subtitle className="mb-2 text-muted"></Card.Subtitle>
      <Button className='m-1' variant="primary">Play random</Button>
      <Button className='m-1' variant="success" onClick={handleShow}>Invite friend</Button>
    </Card.Body>
  </Card>
  )
}

export default GameCard