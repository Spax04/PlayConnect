import React from 'react'
import Card from 'react-bootstrap/Card';
import './styles/gameCard.css'


function GameCard({imgBg,title,description}) {
  return (
    <Card style={{ width: '18rem',margin: '1rem' }}>
    <Card.Body>
    <Card.Img  variant="top" src={imgBg} />

      <Card.Title>{title}</Card.Title>
      <Card.Subtitle className="mb-2 text-muted"></Card.Subtitle>
    </Card.Body>
  </Card>
  )
}

export default GameCard